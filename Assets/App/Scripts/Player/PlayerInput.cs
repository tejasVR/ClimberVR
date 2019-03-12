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

        public bool printDebugLogs;
        

        void Update()
        {
            #region LEFT HAND

            // Pinch

            if (SteamVR_Actions.default_GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabPinchDownCallback?.Invoke();

                if (printDebugLogs)
                    print("Left Grab Pinch Down");
            }

            if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabPinchUpCallback?.Invoke();

                if (printDebugLogs)
                    print("Left Grab Pinch Up");
            }

            if (SteamVR_Actions.default_GrabPinch.GetState(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabPinchPressedCallback?.Invoke();

                if (printDebugLogs)
                    print("Left Grab Pinch Pressed");
            }

            // Grip
            if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabGripDownCallback?.Invoke();

                if (printDebugLogs)
                    print("Left Grab Grip Down");
            }

            if (SteamVR_Actions.default_GrabGrip.GetStateUp(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabGripUpCallback?.Invoke();

                if (printDebugLogs)
                    print("Left Grab Grip Up");
            }

            if (SteamVR_Actions.default_GrabGrip.GetState(SteamVR_Input_Sources.LeftHand))
            {
                LeftGrabGripPressedCallback?.Invoke();

                if (printDebugLogs)
                    print("Left Grab Grip Pressed");
            }

            // Squeeze
            if (SteamVR_Actions.default_Squeeze.GetAxis(SteamVR_Input_Sources.LeftHand) > 0.8F)
            {
                LeftSqueezedCallback?.Invoke();

                if (printDebugLogs)
                    print("Left Squeezed Pressed");
            }

            #endregion

            #region RIGHT HAND

            // Pinch
            if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                RightGrabPinchDownCallback?.Invoke();

                if (printDebugLogs)
                    print("Right Grab Pinch Down");
            }

            if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                RightGrabPinchUpCallback?.Invoke();

                if (printDebugLogs)
                    print("Right Grab Pinch Up");
            }

            if (SteamVR_Actions.default_GrabPinch.GetState(SteamVR_Input_Sources.RightHand))
            {
                RightGrabPinchPressedCallback?.Invoke();

                if (printDebugLogs)
                    print("Right Grab Pinch Pressed");
            }

            // Grip
            if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                RightGrabGripDownCallback?.Invoke();

                if (printDebugLogs)
                    print("Right Grab Grip Down");
            }

            if (SteamVR_Actions.default_GrabGrip.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                RightGrabGripUpCallback?.Invoke();

                if (printDebugLogs)
                    print("Right Grab Grip Up");
            }

            if (SteamVR_Actions.default_GrabGrip.GetState(SteamVR_Input_Sources.RightHand))
            {
                RightGrabGripPressedCallback?.Invoke();

                if (printDebugLogs)
                    print("Right Grab Grip Pressed");
            }

            // Squeeze
            if (SteamVR_Actions.default_Squeeze.GetAxis(SteamVR_Input_Sources.RightHand) > 0.8F)
            {
                LeftSqueezedCallback?.Invoke();

                if (printDebugLogs)
                    print("Right Squeezed Pressed");
            }

            #endregion
        
         
        }
        
    }
}


