using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AperionStudios
{
    public class AttachToBody : MonoBehaviour
    {
        private Transform body;

        void Start()
        {
            body = Player.instance.playerCamera.transform;
        }

        private void Update()
        {
            transform.localPosition = body.localPosition;
            transform.localRotation = body.localRotation;
        }
    }
}


