using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AperionStudios
{
    [RequireComponent(typeof(InteractableObject))]
    public class InventoryItem : MonoBehaviour
    {
        private Grabbable grabbable;
        private bool hoveringOverInventory = false;


        private void Awake()
        {
            grabbable = GetComponent<Grabbable>();
        }

        //private void OnEnable()
        //{
        //    grabbable.ObjectUsedCallback += Grabbed;
        //    grabbable.ObjectUnusedCallback += Ungrabbed;
        //}

        //private void OnDestroy()
        //{
        //    grabbable.ObjectUsedCallback -= Grabbed;
        //    grabbable.ObjectUnusedCallback -= Ungrabbed;
        //}

        void Start()
        {

        }

        void Update()
        {

        }

        private void Grabbed()
        {
            if (hoveringOverInventory)
            {
                //interactableObject.isActive = true;
                grabbable.AdjustPhysics(false, true);
            }
        }

        private void Ungrabbed()
        {
            if (hoveringOverInventory)
            {
                //interactableObject.isActive = false;
                grabbable.AdjustPhysics(true, false);
            }
        }

        public void SetHoveringOverInventory(bool boo)
        {
            hoveringOverInventory = boo;
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.CompareTag("Inventory"))
        //    {
        //        hoveringOverInventory = true;
        //        throwObject.isActive = false;
        //    }
        //}

        //private void OnCollisionExit(Collision collision)
        //{
        //    if (collision.gameObject.CompareTag("Inventory"))
        //    {
        //        hoveringOverInventory = false;
        //    }
        //}



        //private void OnTriggerStay(Collider other)
        //{
        //    if (other.CompareTag("Inventory"))
        //    {
        //        hoveringOverInventory = true;
        //    }
        //}

        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.CompareTag("Inventory"))
        //    {
        //        hoveringOverInventory = false;
        //    }
        //}
    }
}

