using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AperionStudios
{
    [RequireComponent(typeof(InteractableObject))]
    public class InventoryArea : MonoBehaviour
    {
        public GameObject objToAcivate;

        private InteractableObject interactableObject;

        private void Awake()
        {
            interactableObject = GetComponent<InteractableObject>();
        }

        private void Start()
        {
            DeactivateObject();
        }

        private void OnEnable()
        {
            interactableObject.ObjectUsedCallback += ObjectUsed;
        }

        private void OnDisable()
        {
            interactableObject.ObjectUsedCallback -= ObjectUsed;
        }

        protected void ObjectUsed(Hand hand)
        {
            StartCoroutine(ToggleObject(hand));
        }

        IEnumerator ToggleObject(Hand handToFollow)
        {
            if (objToAcivate.activeInHierarchy)
            {
                objToAcivate.transform.parent = transform;

                yield return new WaitForEndOfFrame();

                objToAcivate.SetActive(false);             
            }
            else
            {
                objToAcivate.transform.parent = null;

                yield return new WaitForEndOfFrame();

                objToAcivate.SetActive(true);
            }

            if (objToAcivate.GetComponent<TransformFollow>())
                objToAcivate.GetComponent<TransformFollow>().SetTransformFollow(handToFollow.transform);
        }

        private void ActiveObject()
        {
            objToAcivate.transform.parent = null;
            objToAcivate.SetActive(true);
        }

        private void DeactivateObject()
        {
            objToAcivate.transform.parent = transform;
            objToAcivate.SetActive(false);
        }
    }
}


