using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AperionStudios
{
    public class Player : MonoBehaviour
    {
        public static Player instance = null;
        
        public GameObject playerCamera;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            // will save this for later, not needed now
            //DontDestroyOnLoad();
        }
    }
}

