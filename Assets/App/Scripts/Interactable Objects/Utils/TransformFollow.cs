using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AperionStudios
{
    public class TransformFollow : MonoBehaviour
    {        
        public Transform followTransform;

        [Space(5)]
        public bool shouldMove;
        public bool shouldRotate;

        void Update()
        {
            if (followTransform != null)
            {
                if (shouldMove)
                    transform.position = Vector3.Lerp(transform.position, followTransform.position, Time.deltaTime * 15F);

                if (shouldRotate)
                    transform.rotation = Quaternion.Slerp(transform.rotation, followTransform.rotation, Time.deltaTime * 15F);
            }           
        }

        public static Vector3 FollowPosition(Transform currentTransform, Transform transformToFollow, float moveSpeed)
        {
                return Vector3.Lerp(currentTransform.position, transformToFollow.position, Time.deltaTime * moveSpeed);
        }

        public static Quaternion FollowRotation(Quaternion currentRotation, Quaternion rotationToFollow, float rotateSpeed)
        {
            return Quaternion.Slerp(currentRotation, rotationToFollow, Time.deltaTime * rotateSpeed);
        }

        public void SetTransformFollow(Transform transformToFollow)
        {
            followTransform = transformToFollow;
        }
    }
}


