using UnityEngine;

namespace MyScripts.NPCScripts
{
    public class NPCAnimator : NPCComponent
    {
        private const string SpeedParameterName = "Speed";

        private void Update()
        {
           

            npc.Animator.SetFloat("Speed", npc.currentSpeed);
        }
    }
}