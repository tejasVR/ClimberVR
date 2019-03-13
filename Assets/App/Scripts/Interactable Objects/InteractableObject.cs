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

        public delegate void InteractAction();

        public InteractAction HandEnterCallback;
        public InteractAction HandExitCallback;
        public InteractAction ObjectUsedCallback;
        public InteractAction ObjectUnusedCallback;

        protected virtual void OnHandEnter()
        {
            HandEnterCallback?.Invoke();
        }

        protected virtual void OnHandExit()
        {
            HandExitCallback?.Invoke();
        }

        protected virtual void OnObjectUsed()
        {
            ObjectUnusedCallback?.Invoke();
        }

        protected virtual void OnObjectUnused()
        {
            ObjectUnusedCallback?.Invoke();
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
            OnHandEnter();
        }

        public virtual void HandExitObject(Hand hand)
        {
            OnHandExit();
        }

        public virtual void ObjectUsed(Hand hand)
        {
            OnObjectUnused();
        }

        public virtual void ObjectUnused(Hand hand)
        {
            OnObjectUnused();
        }

        public void AdjustPhysics(bool isK, bool useG)
        {
            rb.isKinematic = isK;
            rb.useGravity = useG;
        }
    }
}


