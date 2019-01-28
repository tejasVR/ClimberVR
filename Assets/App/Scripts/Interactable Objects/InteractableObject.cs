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
    
        protected virtual void OnHandEnterCallback()
        {
            HandEnterCallback?.Invoke();
        }

        protected virtual void OnHandExitCallback()
        {
            HandExitCallback?.Invoke();
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
            OnHandEnterCallback();
        }

        public virtual void HandExitObject(Hand hand)
        {
            OnHandExitCallback();
        }
     
        public void AdjustPhysics(bool isK, bool useG)
        {
            rb.isKinematic = isK;
            rb.useGravity = useG;
        }
    }
}


