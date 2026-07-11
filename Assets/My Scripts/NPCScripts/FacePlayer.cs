using UnityEngine;

namespace MyScripts.NPCScripts
{
    public class NPCLookAtPlayer : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float rotationSpeed = 5f;

        private Transform targetToLookAt;
        private bool shouldLook = false;

        void Update()
        {
            if (shouldLook && targetToLookAt != null)
            {
                FaceTargetSmoothly();
            }
        }

        private void FaceTargetSmoothly()
        {
            // Calculate direction to the target from this body's position
            Vector3 direction = targetToLookAt.position - transform.position;
            
            // Keep the NPC upright on the Y axis
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }

        // Call this from the detection script to start looking
        public void StartLooking(Transform player)
        {
            targetToLookAt = player;
            shouldLook = true;
        }

        // Call this from the detection script to stop looking
        public void StopLooking()
        {
            shouldLook = false;
            targetToLookAt = null;
        }
    }
}