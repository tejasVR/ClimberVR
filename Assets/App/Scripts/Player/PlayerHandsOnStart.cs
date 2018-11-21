using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayerHandsOnStart : MonoBehaviour {

    public enum ControllerVisibility
    {
        ShowControllers,
        HideControllers
    }

    public enum SkeletonVisibility
    {
        ShowSkeleton,
        HideSkeleton
    }

    public enum SkeletonAnimation
    {
        AnimateHandWithController,
        AnimateHandWithoutController
    }

    [Header("Hand Objects")]
    public Hand leftHand;
    public Hand rightHand;

    [Space(10)]

    public ControllerVisibility controllerVisibility;
    //public SkeletonVisibility skeletonVisibility;
    public SkeletonAnimation skeletonAnimation;

    private void Start()
    {
        StartCoroutine(SetControllerProperties());
    }

    IEnumerator SetControllerProperties()
    {
        yield return new WaitForSeconds(1F);

        switch (controllerVisibility)
        {
            case ControllerVisibility.ShowControllers:
                ShowController();
                break;

            case ControllerVisibility.HideControllers:
                HideController();
                break;
        }

        switch (skeletonAnimation)
        {
            case SkeletonAnimation.AnimateHandWithController:
                AnimateHandWithController();
                break;

            case SkeletonAnimation.AnimateHandWithoutController:
                AnimateHandWithoutController();
                break;
        }      
    }


    public void AnimateHandWithController()
    {
        for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
        {
            Hand hand = Player.instance.hands[handIndex];
            if (hand != null)
            {
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
            }
        }
    }

    public void AnimateHandWithoutController()
    {
        for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
        {
            Hand hand = Player.instance.hands[handIndex];
            if (hand != null)
            {
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithoutController);
            }
        }
    }

    public void ShowController()
    {
        for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
        {
            Hand hand = Player.instance.hands[handIndex];
            if (hand != null)
            {
                hand.ShowController(true);
            }
        }
    }

    public void HideController()
    {
        for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
        {
            Hand hand = Player.instance.hands[handIndex];
            if (hand != null)
            {
                hand.HideController(true);
            }
        }
    }
}
