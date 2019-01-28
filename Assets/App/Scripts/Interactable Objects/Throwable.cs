//======= Copyright (c) Aperion Studios, All rights reserved. ===============
//
// Purpose: Creates a basic throwable object
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

namespace AperionStudios
{
    [RequireComponent(typeof(Rigidbody))]
    public class Throwable : Grabbable
    {

        [Header("Throwable Settings")]        
        public bool isThrown = false;        
        public bool isActive = true;
        public float velocityMultiplier = 1F;

        private Grabbable grabbable;
        private float throwVelocityThreshold = 2F;

        public override void Awake()
        {
            base.Awake();
          
        }

        public override void GrabObject(Hand hand)
        {
            base.GrabObject(hand);

            PickUp();
        }

        public override void UngrabObject(Hand hand)
        {
            base.UngrabObject(hand);

            if (CheckIfThrown(hand))
            {
                Throw(hand);
            }
        }

        private void PickUp()
        {
            isThrown = false;
        }

        private void Throw(Hand hand)
        {
            ApplyDetachVelocity(hand);
            isThrown = true;
        }

        
        private bool CheckIfThrown(Hand hand)
        {
            if (hand.GetHandVelocity().magnitude * velocityMultiplier < throwVelocityThreshold)
            {
                return false;
            }

            return true;
        }

        private void ApplyDetachVelocity(Hand hand)
        {                       
            rb.velocity = hand.GetHandVelocity() * velocityMultiplier;
            rb.angularVelocity = hand.GetHandAngularVelocity();           
        }
    }
}

