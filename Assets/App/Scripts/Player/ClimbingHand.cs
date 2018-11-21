using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ClimbingHand : MonoBehaviour {

    [HideInInspector]
    public Hand hand;

    [HideInInspector]
    public Vector3 prevPos;

    public bool canClimb;

    private void Awake()
    {
        if (hand == null)
            hand = this.GetComponent<Hand>();
    }

    // Update is called once per frame
    void Update () {
        prevPos = transform.localPosition;
    }

    public void SetCanClimb(bool boo)
    {
        canClimb = boo;
    }
}
