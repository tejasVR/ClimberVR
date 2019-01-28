using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace AperionStudios.ClimberVR
{
    public class ClimbAbility : MonoBehaviour
    {
        public SteamVR_Action_Boolean climbAction;

        public ClimbingHand leftHand;
        public ClimbingHand rightHand;
        public GameObject playerBody;

        public float velocityFlingMultiplier;

        private ClimbingHand currentlyGrabbingHand;

        private void Awake()
        {
            if (climbAction == null)
            {
                Debug.LogError("No climb action assigned");
                return;
            }
          
        }

        private void FixedUpdate()
        {           
            if (leftHand.canClimb && climbAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                currentlyGrabbingHand = leftHand;
            }
            else if (rightHand.canClimb && climbAction.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                currentlyGrabbingHand = rightHand;
            }


            if (currentlyGrabbingHand == leftHand)
            {
                Climb(leftHand);
                BodyPhysics.SetBodyPhysics(false, true);

                if (climbAction.GetStateUp(SteamVR_Input_Sources.LeftHand))
                {
                    if (rightHand.canClimb && climbAction.GetState(SteamVR_Input_Sources.RightHand))
                    {
                        currentlyGrabbingHand = rightHand;                     
                    }
                    else
                    {
                        ClimbEndVelocity(leftHand);

                        if (currentlyGrabbingHand == leftHand)
                            currentlyGrabbingHand = null;

                        BodyPhysics.SetBodyPhysics(true, false);
                    }                    
                }
            }        
            else if (currentlyGrabbingHand == rightHand)
            {
                Climb(rightHand);
                BodyPhysics.SetBodyPhysics(false, true);

                if (climbAction.GetStateUp(SteamVR_Input_Sources.RightHand))
                {
                    if (leftHand.canClimb && climbAction.GetState(SteamVR_Input_Sources.LeftHand))
                    {
                        currentlyGrabbingHand = leftHand;                       
                    }
                    else
                    {
                        ClimbEndVelocity(rightHand);

                        if (currentlyGrabbingHand == rightHand)
                            currentlyGrabbingHand = null;

                        BodyPhysics.SetBodyPhysics(true, false);
                    }                    
                }
            }          
            else
            {
                BodyPhysics.SetBodyPhysics(true, false);
            }

            UpdateHandPreviousPosition();
        }

        private void Climb(ClimbingHand climbingHand)
        {
            playerBody.transform.position += (climbingHand.prevPos - climbingHand.transform.localPosition);      
        }

        private void ClimbEndVelocity(ClimbingHand climbingHand)
        {
            BodyPhysics.SetBodyVelocity((climbingHand.prevPos - climbingHand.transform.localPosition) * velocityFlingMultiplier / Time.deltaTime);
        }

        private void UpdateHandPreviousPosition()
        {
            leftHand.prevPos = leftHand.transform.localPosition;
            rightHand.prevPos = rightHand.transform.localPosition;
        }

        private void ResetCurrenltyGrabbingHand()
        {
            if (currentlyGrabbingHand != null)
                currentlyGrabbingHand = null;
        }
    }
}
