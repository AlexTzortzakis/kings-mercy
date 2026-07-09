using UnityEngine;

namespace MyScripts.NPCScripts
{


    public class NPCComponent : MonoBehaviour
    {
    
        protected NPC npc;


        protected virtual void Awake()
        {
            npc = GetComponentInParent<NPC>();
            
        }
    }

}
