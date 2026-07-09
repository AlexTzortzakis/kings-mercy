using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class NPC : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent Agent;
    [HideInInspector] public Animator Animator;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator animator;

    public float currentSpeed
    {
        get { return Agent.velocity.magnitude; }
    }

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
        agent = Agent;
        animator = Animator;
    }

}
