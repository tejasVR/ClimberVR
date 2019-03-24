using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AperionStudios
{
    [RequireComponent(typeof(InteractableObject))]
    public class InventoryArea : MonoBehaviour
    {
        public Grabbable objToAcivate;

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
            if (objToAcivate.gameObject.activeInHierarchy)
            {
                objToAcivate.AttachToHand(handToFollow);
                handToFollow.AttachObjectToHand(objToAcivate);

                yield return new WaitForEndOfFrame();

                objToAcivate.gameObject.SetActive(false);             
            }
            else
            {
                objToAcivate.transform.parent = transform;

                //objToAcivate.
                handToFollow.DetachObjectFromHand();

                yield return new WaitForEndOfFrame();

                objToAcivate.gameObject.SetActive(true);
            }

            if (objToAcivate.GetComponent<TransformFollow>())
                objToAcivate.GetComponent<TransformFollow>().SetTransformFollow(handToFollow.transform);
        }

        private void ActiveObject()
        {
            objToAcivate.transform.parent = null;
            objToAcivate.gameObject.SetActive(true);
        }

        private void DeactivateObject()
        {
            objToAcivate.transform.parent = transform;
            objToAcivate.gameObject.SetActive(false);
        }
    }
}


