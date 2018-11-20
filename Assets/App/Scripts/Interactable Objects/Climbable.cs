//======= Copyright (c) Aperion Studios, All rights reserved. ===============
//
// Purpose: Creates a basic climable objects for players to climb 
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace AperionStudios.ClimberVR
{
    [RequireComponent(typeof(Interactable))]
    [RequireComponent(typeof(Rigidbody))]
    public class Climbable : MonoBehaviour
    {
        [HideInInspector]
        public Interactable interactable;

        protected void Awake()
        {
            interactable = GetComponent<Interactable>();
        }

        protected virtual void OnAttachedToHand(Hand hand)
        {
            Debug.Log("A hand interacted with a climable object");
        }

        protected virtual void OnHandHoverBegin(Hand hand)
        {
            //Debug.Log("A hand hovers over a with a climable object");
            if (hand.GetComponent<PlayerClimb>() != null)
            {               
                hand.GetComponent<PlayerClimb>().SetCanClimb(true);               
            }            
        }

        protected virtual void OnHandHoverEnd(Hand hand)
        {
            //Debug.Log("A hand hovers over a with a climable object");
            if (hand.GetComponent<PlayerClimb>() != null)
            {
                hand.GetComponent<PlayerClimb>().SetCanClimb(false);
            }
        }
    }
}


