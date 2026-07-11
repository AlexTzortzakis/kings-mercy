using UnityEngine;

namespace MyScripts.NPCScripts
{
    public class Wander : NPCComponent
    {
        
        public Area area;
        public bool isTalking = false;

        private void Start()
        {
            PickRandomPosition();
        }

        private void Update()
        {
            if (IsAtDestination())
            {
                PickRandomPosition();
            }
        }

        bool IsAtDestination()
        {
            if (npc == null || npc.Agent == null)
            {
                return false;
            }

            return !npc.Agent.pathPending && npc.Agent.remainingDistance <= npc.Agent.stoppingDistance;
        }


        void PickRandomPosition()
        {
            if (npc == null || npc.Agent == null)
            {
                Debug.LogWarning($"{GetType().Name} cannot pick a destination because NPC or NavMeshAgent is missing.", this);
                return;
            }

            if (area == null)
            {
                Debug.LogWarning($"{GetType().Name} needs an Area reference to wander.", this);
                return;
            }

            npc.Agent.SetDestination(area.GetRandomPointInArea());
        }

        public void OnFootstep()
        {
    
        }
    }
}
