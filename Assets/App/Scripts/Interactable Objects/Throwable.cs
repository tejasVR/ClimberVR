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

        public override void ObjectUsed(Hand hand)
        {
            base.ObjectUsed(hand);

            PickUp();
        }

        public override void ObjectUnused(Hand hand)
        {
            base.ObjectUnused(hand);

            Throw(hand);            
        }

        private void PickUp()
        {
            isThrown = false;
        }

        private void Throw(Hand hand)
        {
            ApplyDetachVelocity(hand);

            if (CheckIfThrown(hand))
                isThrown = true;
        }

        
        private bool CheckIfThrown(Hand hand)
        {
            if (hand.GetHandVelocity().magnitude * velocityMultiplier < throwVelocityThreshold)
            {
                Debug.Log("Object was not thrown becuase throw velocity was " + hand.GetHandVelocity().magnitude * velocityMultiplier);
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

