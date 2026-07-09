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
        [HideInInspector] public NavMeshAgent agent;
        [HideInInspector] public Animator animator;

        private void Start()
        {
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
            agent = Agent;
            animator = Animator;
        }

        public float currentSpeed
        {
            get { return Agent.velocity.magnitude; }
        }
    }
}
