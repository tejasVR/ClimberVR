using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

namespace AperionStudios
{
    [RequireComponent(typeof(Rigidbody))]
    public class Hand : MonoBehaviour
    {     
        #region STEAM ACTION MAPPING

        public SteamVR_Action_Boolean grabAction;

        #endregion

        #region ACTIONS

        public static UnityAction GrabDownCallback;
        public static UnityAction GrabUpCallback;

        #endregion

        public SteamVR_Input_Sources thisHand;
       
        private SteamVR_Behaviour_Pose trackedObject;
        private InteractableObject interactingObject;        
        private Grabbable grabbedObject;        
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            trackedObject = GetComponent<SteamVR_Behaviour_Pose>();
        }

        void Update()
        {
            if (grabAction.GetStateUp(thisHand) && grabbedObject != null)
            {             
                grabbedObject.UngrabObject(this);              
                DetachObjectFromHand();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            InteractableObject iO = other.GetComponent<InteractableObject>();

            if (iO != null)
            {
                interactingObject = iO;
                iO.HandEnterObject(this);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            //print("Hovering over something");

            Grabbable gO = other.GetComponent<Grabbable>();

            if (gO != null)
            {
                if (grabAction.GetStateDown(thisHand) && grabbedObject == null)
                {
                    grabbedObject = gO;
                    gO.GrabObject(this);
                }

                //print("Hovering over throwable object");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            InteractableObject iO = other.GetComponent<InteractableObject>();

            if (iO != null)
            {
                interactingObject = null;
                iO.HandExitObject(this);
            }
        }

        public void DetachObjectFromHand()
        {
            grabbedObject = null;
        }

        public void SetInteractingObject(InteractableObject iO)
        {
            interactingObject = iO;
        }

        public Vector3 GetHandVelocity()
        {
            return trackedObject.GetVelocity();
        }

        public Vector3 GetHandAngularVelocity()
        {
            return trackedObject.GetAngularVelocity();
        }
    }
}


