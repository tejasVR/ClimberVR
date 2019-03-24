using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AperionStudios
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class InteractableObject : MonoBehaviour
    {
        #region EVENT SETUP

        public delegate void InteractAction(Hand hand);

        public InteractAction HandEnterCallback;
        public InteractAction HandExitCallback;
        public InteractAction ObjectUsedCallback;
        public InteractAction ObjectUnusedCallback;

        protected virtual void OnHandEnter(Hand hand)
        {
            HandEnterCallback?.Invoke(hand);
        }

        protected virtual void OnHandExit(Hand hand)
        {
            HandExitCallback?.Invoke(hand);
        }

        protected virtual void OnObjectUsed(Hand hand)
        {
            ObjectUsedCallback?.Invoke(hand);
        }

        protected virtual void OnObjectUnused(Hand hand)
        {
            ObjectUnusedCallback?.Invoke(hand);
        }
       
        #endregion

        [HideInInspector]
        public Rigidbody rb;

        public virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public virtual void Start()
        {

        }

        public virtual void HandEnterObject(Hand hand)
        {
            OnHandEnter(hand);
        }

        public virtual void HandExitObject(Hand hand)
        {
            OnHandExit(hand);
        }

        public virtual void ObjectUsed(Hand hand)
        {
            OnObjectUsed(hand);
        }

        public virtual void ObjectUnused(Hand hand)
        {
            OnObjectUnused(hand);
        }
    }
}


