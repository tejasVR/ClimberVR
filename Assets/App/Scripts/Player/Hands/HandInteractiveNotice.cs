using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AperionStudios
{
    public class HandInteractiveNotice : MonoBehaviour
    {
        public GameObject grabSphere;
        public Material grabSphereNormalMat;
        public Material grabSphereHighlightMat;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<InteractableObject>())
            {
                Renderer rend = grabSphere.GetComponent<Renderer>();
                rend.sharedMaterial = grabSphereHighlightMat;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<InteractableObject>())
            {
                Renderer rend = grabSphere.GetComponent<Renderer>();
                rend.sharedMaterial = grabSphereNormalMat;
            }
        }
    }
}

