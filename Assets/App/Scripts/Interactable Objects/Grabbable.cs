using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AperionStudios
{
    public class Grabbable : InteractableObject
    {
        #region EVENT SETUP

        public delegate void GrabAction();

        public event GrabAction GrabbedCallback;
        public event GrabAction UngrabbedCallback;

        protected virtual void OnGrabbedCallback()
        {
            GrabbedCallback?.Invoke();
        }

        protected virtual void OnUngrabbedCallback()
        {
            UngrabbedCallback?.Invoke();
        }

        #endregion

        public enum SecondHandInteraction
        {
            None,
            SwitchHands
        }

        public enum GrabType
        {
            Free,
            FixedPoint,            
        }

        [Header("Grabbable Settings")]
        public SecondHandInteraction secondHandInteraction;
        public GrabType grabType;
        public Transform grabPoint;
        public bool isGrabbed = false;

        protected Transform cachedTransform;

        private Hand handAttachedTo;

        public virtual void GrabObject(Hand hand)
        {
            OnGrabbedCallback();

            AttachToHand(hand);
        }

        public virtual void UngrabObject(Hand hand)
        {
            OnUngrabbedCallback();

            DetachFromHand(hand);

        }

        public void AttachToHand(Hand hand)
        {
            bool shouldReturn = false;

            switch (grabType)
            {
                case GrabType.Free:
                    transform.parent = hand.transform;
                    break;

                case GrabType.FixedPoint:

                    if (grabPoint == null)
                    {
                        Debug.LogError("grabPoint Transform on " + gameObject.name + " not defined");
                        break;
                    }
                    else
                    {
                        
                        //transform.position = grabPoint.position;
                        //transform.rotation = grabPoint.rotation;

                        //transform.parent = hand.grabAttachPoint;

                        cachedTransform.SetParent(hand.grabAttachPoint);

                        cachedTransform.rotation = hand.transform.rotation;
                        cachedTransform.Rotate(grabPoint.rotation.eulerAngles);
                        cachedTransform.position = hand.grabAttachPoint.position;
                        cachedTransform.Translate(grabPoint.position, Space.Self);

                        //transform = cachedTransform;

                    }                
                    break;
            }

            if (handAttachedTo != null && hand != handAttachedTo)
            {
                switch (secondHandInteraction)
                {
                    case SecondHandInteraction.None:
                        shouldReturn = true;
                        break;

                    case SecondHandInteraction.SwitchHands:
                        SwitchHands(hand);
                        break;
                }
            }

            if (shouldReturn)
            {                
                return;
            }

            AdjustPhysics(true, false);

            handAttachedTo = hand;

            isGrabbed = true;
            handAttachedTo.SetInteractingObject(this);
        }

        public void DetachFromHand(Hand hand)
        {
            AdjustPhysics(false, true);

            transform.parent = null;
            handAttachedTo = null;

            isGrabbed = false;
        }

        private void SwitchHands(Hand handToSwitchTo)
        {
            if (handAttachedTo != null)
            {
                handAttachedTo.DetachObjectFromHand();
            }
        }
    }
}

