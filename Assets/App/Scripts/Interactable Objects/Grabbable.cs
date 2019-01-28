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

        [Header("Grabbable Settings")]
        public SecondHandInteraction secondHandInteraction;
        public bool isGrabbed = false;

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
                print("returning function");
                return;
            }

            AdjustPhysics(true, false);

            transform.parent = hand.transform;
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

