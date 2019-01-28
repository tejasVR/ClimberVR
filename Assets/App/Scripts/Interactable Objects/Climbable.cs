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

namespace AperionStudios
{
    [RequireComponent(typeof(Rigidbody))]
    public class Climbable : InteractableObject
    {
        public override void HandEnterObject(Hand hand)
        {
            base.HandEnterObject(hand);
            //print("the player's hand is over a climable object");
        }
    }
}


