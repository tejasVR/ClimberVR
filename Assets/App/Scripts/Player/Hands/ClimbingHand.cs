using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace AperionStudios.ClimberVR
{
    public class ClimbingHand : MonoBehaviour
    {
        //public SteamVR_Action_Boolean climbAction;

        [HideInInspector]
        public Vector3 prevPos;

        [HideInInspector]
        public bool canClimb;
            
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Climable"))
            {
                canClimb = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Climable"))
            {
                canClimb = false;
            }
        }            
    }
}
