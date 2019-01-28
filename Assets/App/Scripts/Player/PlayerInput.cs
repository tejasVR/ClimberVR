using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

namespace AperionStudios
{
    // This script houses all player input events and mappings

    public class PlayerInput : MonoBehaviour
    {
        #region Player Events

        // LEFT HAND
        public static UnityAction LeftGrabPinchDownCallback;
        public static UnityAction LeftGrabPinchUpCallback;
        public static UnityAction LeftGrabPinchPressedCallback;

        public static UnityAction LeftGrabGripDownCallback;
        public static UnityAction LeftGrabGripUpCallback;
        public static UnityAction LeftGrabGripPressedCallback;

        public static UnityAction LeftSqueezedCallback;

        // RIGHT HAND
        public static UnityAction RightGrabPinchDownCallback;
        public static UnityAction RightGrabPinchUpCallback;
        public static UnityAction RightGrabPinchPressedCallback;

        public static UnityAction RightGrabGripDownCallback;
        public static UnityAction RightGrabGripUpCallback;
        public static UnityAction RightGrabGripPressedCallback;

        public static UnityAction RightSqueezedCallback;

        #endregion

        #region SteamVR Actions

        public SteamVR_Action_Single squeezeAction;

        #endregion
        

        void Update()
        {
            #region LEFT HAND

            // Pinch

            if (SteamVR_Actions.default_GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabPinchDownCallback?.Invoke();
                print("Left Grab Pinch Down");
            }

            if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabPinchUpCallback?.Invoke();
                print("Left Grab Pinch Up");
            }

            if (SteamVR_Actions.default_GrabPinch.GetState(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabPinchPressedCallback?.Invoke();
                print("Left Grab Pinch Pressed");
            }

            // Grip
            if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabGripDownCallback?.Invoke();
                print("Left Grab Grip Down");
            }

            if (SteamVR_Actions.default_GrabGrip.GetStateUp(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabGripUpCallback?.Invoke();
                print("Left Grab Grip Up");
            }

            if (SteamVR_Actions.default_GrabGrip.GetState(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabGripPressedCallback?.Invoke();
                print("Left Grab Grip Pressed");
            }

            // Squeeze
            if (SteamVR_Actions.default_Squeeze.GetAxis(SteamVR_Input_Sources.LeftHand) > 0.8F)
            {
                LeftSqueezedCallback?.Invoke();
                print("Left Squeezed Pressed");
            }

            #endregion

            #region RIGHT HAND

            // Pinch
            if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                RightGrabPinchDownCallback?.Invoke();
                print("Right Grab Pinch Down");
            }

            if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                RightGrabPinchUpCallback?.Invoke();
                print("Right Grab Pinch Up");
            }

            if (SteamVR_Actions.default_GrabPinch.GetState(SteamVR_Input_Sources.RightHand))
            {
                RightGrabPinchPressedCallback?.Invoke();
                print("Right Grab Pinch Pressed");
            }

            // Grip
            if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                RightGrabGripDownCallback?.Invoke();
                print("Right Grab Grip Down");
            }

            if (SteamVR_Actions.default_GrabGrip.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                RightGrabGripUpCallback?.Invoke();
                print("Right Grab Grip Up");
            }

            if (SteamVR_Actions.default_GrabGrip.GetState(SteamVR_Input_Sources.RightHand))
            {
                RightGrabGripPressedCallback?.Invoke();
                print("Right Grab Grip Pressed");
            }

            // Squeeze
            if (SteamVR_Actions.default_Squeeze.GetAxis(SteamVR_Input_Sources.RightHand) > 0.8F)
            {
                LeftSqueezedCallback?.Invoke();
                print("Right Squeezed Pressed");
            }

            #endregion
        
         
        }
        
    }
}


