using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AperionStudios
{
    [RequireComponent(typeof(Throwable))]
    public class Explodable : MonoBehaviour
    {
        public enum ExplodeType
        {
            TimedExplosion,
            OnCollisionExplosion
        }

        [Header("Explodable Settings")]
        public ExplodeType explodeType;
        public GameObject explodeEffectPrefab;

        [Space(5)]
        public float explodeRadius = 0.5F;
        public float explodeForce = 500;        
        
        [HideInInspector]
        public float explodeTime = 2F;

        private Throwable throwable;
        private float explodeCounter;
        private bool hasExploded;

        private void Awake()
        {
            throwable = GetComponent<Throwable>();
        }

        public virtual void Start()
        {           
            explodeCounter = explodeTime;
        }

         void Update()
        {
            if (explodeType == ExplodeType.TimedExplosion)
            {
                if (throwable.isThrown && !hasExploded)
                {
                    explodeCounter -= Time.deltaTime;
                    if (explodeCounter <= 0)
                    {
                        Explode();
                    }
                }              
            }                           
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (explodeType == ExplodeType.OnCollisionExplosion && !hasExploded && throwable.isThrown)
            {
                Explode();
            }
        }

        public void Explode()
        {
            hasExploded = true;

            AdjustExplosion();

            ExplodeEffect();
            CollisionEffect();

            Destroy(gameObject);
        }

        private void CollisionEffect()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explodeRadius);

            foreach (var c in colliders)
            {
                Rigidbody rb = c.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explodeForce, transform.position, explodeRadius);
                }
            }
        }

        //----- Adjuts explosion force / radius based on velocity
        private void AdjustExplosion()
        {
            float smoothing = 0.25F;
            var rb = throwable.rb;

            explodeForce *= rb.velocity.magnitude * smoothing;
            explodeRadius *= rb.velocity.magnitude * smoothing;
        }

        private void ExplodeEffect()
        {
            Instantiate(explodeEffectPrefab, transform.position, transform.rotation);
        }
    }  
}


