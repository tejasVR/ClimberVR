using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AperionStudios
{
    public class Inventory : MonoBehaviour
    {
        public InventoryItem[] inventoryItems;

        private void OnTriggerStay(Collider other)
        {
            InventoryItem inventoryItem = other.GetComponent<InventoryItem>();
            //Throwable throwItem = other.GetComponent<Throwable>();

            if (inventoryItem != null)// && throwItem != null)
            {
                //if (throwItem.isGrabbed)
                //{
                    inventoryItem.SetHoveringOverInventory(true);
                    // wait until the grabbed object is ungrabbed

                    //if (!throwItem.isGrabbed)
                    //{
                    //    inventoryItem.SetHoveringOverInvetory(true);
                    //    throwItem.AdjustPhysics(true, false);
                    //}
                //}                
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var inventoryItem = other.GetComponent<InventoryItem>();
            //var throwItem = other.GetComponent<Throwable>();

            if (inventoryItem != null)// && throwItem != null)
            {
                //if (throwItem.isGrabbed)
                //{
                    inventoryItem.SetHoveringOverInventory(false);
                    
                    //inventoryItem.SetHoveringOverInvetory(false);
                    //throwItem.AdjustPhysics(true, false);
                //}
            }
        }


    }    
}

