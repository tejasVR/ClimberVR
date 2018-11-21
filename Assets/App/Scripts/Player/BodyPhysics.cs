using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AperionStudios.ClimberVR
{
    [RequireComponent(typeof(Rigidbody))]
    public class BodyPhysics : MonoBehaviour
    {
        public static Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public static void SetBodyPhysics(bool useGravity, bool isKinematic)
        {
            rb.useGravity = useGravity;
            rb.isKinematic = isKinematic;
        }

        public static void SetBodyVelocity(Vector3 velocity)
        {
            rb.velocity = velocity;
        }

        public static void SetBodyMass(float mass, float drag, float angularDrag)
        {
            rb.mass = mass;
            rb.drag = drag;
            rb.angularDrag = angularDrag;
        }
    }
}
