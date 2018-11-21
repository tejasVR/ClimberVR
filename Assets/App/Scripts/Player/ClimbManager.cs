using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace AperionStudios.ClimberVR
{
    public class ClimbManager : MonoBehaviour
    {
        public SteamVR_Action_Boolean climbAction;

        public ClimbingHand leftHand;
        public ClimbingHand rightHand;

        public GameObject playerBody;
        Rigidbody playerRb;

        private void Awake()
        {
            playerRb = playerBody.GetComponent<Rigidbody>();

            if (climbAction == null)
            {
                Debug.LogError("No climb action assigned");
                return;
            }

            // USED TO SUBSCRIBE BUTTON PRESSES TO METHODS
            //climbAction.AddOnChangeListener(OnClimbActionChange, hand.handType);
        }
      

        void FixedUpdate()
        {
            if (leftHand.canClimb && climbAction.GetState(leftHand.hand.handType))
            {
                Climb(leftHand);
                BodyPhysics.SetBodyPhysics(false, true);
            }
            else if (climbAction.GetStateUp(leftHand.hand.handType))
            {
                ClimbEndVelocity(leftHand);
                BodyPhysics.SetBodyPhysics(true, false);
            }
            else if (rightHand.canClimb && climbAction.GetState(rightHand.hand.handType))
            {
                Climb(rightHand);
                BodyPhysics.SetBodyPhysics(false, true);
            }
            else if (climbAction.GetStateUp(rightHand.hand.handType))
            {
                ClimbEndVelocity(rightHand);
                BodyPhysics.SetBodyPhysics(true, false);
            }
            else
            {
                BodyPhysics.SetBodyPhysics(true, false);
                
            }
        }


        private void Climb(ClimbingHand climbingHand)
        {
            playerBody.transform.position += (climbingHand.prevPos - climbingHand.hand.transform.localPosition);
            //climbingHand.hand.SetAnimationState(2);
        }

        private void ClimbEndVelocity(ClimbingHand climbingHand)
        {
            BodyPhysics.SetBodyVelocity((climbingHand.prevPos - climbingHand.transform.localPosition) / Time.deltaTime);
            //climbingHand.hand.SetAnimationState(0);
        }
    }
}
