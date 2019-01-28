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
            //transform.localPosition = new Vector3(body.localPosition.x, body.localPosition.y + transform.localPosition.y, body.localPosition.z);
            transform.localPosition = body.localPosition;
        }
    }
}


