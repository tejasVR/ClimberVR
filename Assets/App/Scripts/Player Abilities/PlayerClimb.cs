using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace AperionStudios.ClimberVR
{
    public class PlayerClimb : MonoBehaviour
    {

        public SteamVR_Action_Boolean climbAction;
        public Hand hand;

        public GameObject playerBody;

        private Vector3 prevPos;

        private bool canClimb;

        private void Awake()
        {
            if (hand == null)
                hand = this.GetComponent<Hand>();

            if (climbAction == null)
            {
                Debug.LogError("No climb action assigned");
                return;
            }

            //climbAction.AddOnChangeListener(OnClimbActionChange, hand.handType);
        }

        void Start()
        {
            prevPos = transform.localPosition;
        }

        void Update()
        {
            if (canClimb)
            {
                if (climbAction.GetState(hand.handType))
                {
                    Climb();
                }
            }

        }

        //private void OnClimbActionChange(SteamVR_Action_In actionIn)
        //{
        //    if (climbAction.GetState(hand.handType))
        //    {
        //        Climb();
        //    }
        //}

        private void Climb()
        {
            playerBody.transform.position += (prevPos - transform.localPosition);
            prevPos = transform.localPosition;
        }

        public void SetCanClimb(bool boo)
        {
            canClimb = boo;
        }
    }
}
