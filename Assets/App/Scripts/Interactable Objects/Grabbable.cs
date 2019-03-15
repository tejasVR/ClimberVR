using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AperionStudios
{
    public class Grabbable : InteractableObject
    {
        #region EVENT SETUP

        //public delegate void GrabAction();

        //public event GrabAction GrabbedCallback;
        //public event GrabAction UngrabbedCallback;

        //protected virtual void OnGrabbedCallback()
        //{
        //    GrabbedCallback?.Invoke();
        //}

        //protected virtual void OnUngrabbedCallback()
        //{
        //    UngrabbedCallback?.Invoke();
        //}

        #endregion

        public enum SecondHandInteraction
        {
            None,
            SwitchHands
        }

        public enum GrabType
        {
            Free,
            Follow,
            FixedPoint,            
        }

        public enum UngrabType
        {
            Anywhere,
            Inventory
        }

        [Header("Grabbable Settings")]
        public SecondHandInteraction secondHandInteraction;
        public GrabType grabType;
        public UngrabType ungrabType;

        public Transform grabPoint;

        public Grabbable objToGrab;

        protected Transform cachedTransform;

        private bool isGrabbed = false;
        private bool isFollowingHand = false;
        private Hand handAttachedTo;
        private InteractableObject interactableObject;

        public override void Awake()
        {
            base.Awake();
        }

        public override void ObjectUsed(Hand hand)
        {
            base.ObjectUsed(hand);

            AttachToHand(hand);
        }

        public override void ObjectUnused(Hand hand)
        {
            base.ObjectUnused(hand);

            DetachFromHand(hand);
        }

        private void Update()
        {
            if (isGrabbed & isFollowingHand && handAttachedTo != null)
            {
                FollowHand(handAttachedTo);
            }
        }

        private void FollowHand(Hand hand)
        {                  
            transform.position = TransformFollow.FollowPosition(transform, hand.transform, 20F);
            transform.rotation = TransformFollow.FollowRotation(transform, hand.transform, 20F);
        }

        public virtual void AttachToHand(Hand hand)
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

                case GrabType.Follow:
                    isFollowingHand = true;
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

        protected virtual void DetachFromHand(Hand hand)
        {
            if (ShouldDetach())
            {
                hand.DetachObjectFromHand();

                AdjustPhysics(false, true);

                transform.parent = null;
                handAttachedTo = null;

                isGrabbed = false;
            }            
        }

        private bool ShouldDetach()
        {
            switch (ungrabType)
            {
                case UngrabType.Anywhere:
                    return true;
                    
                case UngrabType.Inventory:
                    return IfNearInventory();
            }

            return false;
        }

        private bool IfNearInventory()
        {
            RaycastHit hit;
            LayerMask inventoryLayer = LayerMask.NameToLayer("Inventory");
           
            Collider[] cols = Physics.OverlapSphere(transform.position, 1F, ~inventoryLayer, QueryTriggerInteraction.Collide);

            foreach (var c in cols)
            {
                if (c != null)
                    return true;
            }

            return false;
        }

        private void SwitchHands(Hand handToSwitchTo)
        {
            if (handAttachedTo != null)
            {
                handAttachedTo.DetachObjectFromHand();
            }
        }

        protected virtual void AdjustPhysics(bool isK, bool useG)
        {
            rb.isKinematic = isK;
            rb.useGravity = useG;
        }
    }
}

