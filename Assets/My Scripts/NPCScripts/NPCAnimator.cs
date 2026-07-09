using UnityEngine;

namespace MyScripts.NPCScripts
{
    public class NPCAnimator : NPCComponent
    {
        private const string SpeedParameterName = "Speed";

        private void Update()
        {
            if (npc == null || npc.Agent == null || npc.Animator == null)
            {
                return;
            }

            float normalizedSpeed = Mathf.Clamp01(npc.Agent.velocity.magnitude / Mathf.Max(0.0001f, npc.Agent.speed));
            npc.Animator.SetFloat(SpeedParameterName, normalizedSpeed);
        }
    }
}