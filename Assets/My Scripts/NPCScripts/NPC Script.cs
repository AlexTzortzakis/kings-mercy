using UnityEngine;
using UnityEngine.AI;

namespace MyScripts.NPCScripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class NPC : MonoBehaviour
    {
        [HideInInspector] public NavMeshAgent Agent;
        [HideInInspector] public Animator Animator;
        internal bool isTalking;

        private void Start()
        {
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
            Agent.isStopped = false;
            
        }

        public float currentSpeed
        {
            get { return Agent.velocity.magnitude; }
        }
    }
}
