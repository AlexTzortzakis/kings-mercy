using UnityEngine;
using UnityEngine.AI;

namespace MyScripts.NPCScripts
{
    public class Area : MonoBehaviour
    {
        public float areaRadius = 30f;

    

        public Vector3 GetRandomPointInArea()
        {
            Vector3 randomDirection = Random.insideUnitSphere * areaRadius;
            randomDirection.y = 0f; // Keep the point on the same horizontal plane

            Vector3 randomPoint = transform.position + randomDirection;

            NavMeshHit hit;
            Vector3 finalPosition = transform.position;
            
            if (NavMesh.SamplePosition(randomPoint, out hit, 2f, 1))
            {
                finalPosition = hit.position;
            }
            return finalPosition;
        }
    }
}