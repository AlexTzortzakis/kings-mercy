using UnityEngine;
using UnityEngine.InputSystem;

namespace MyScripts.NPCScripts
{
    public class PlayerDetection : MonoBehaviour
    {
        bool playerDetected = false;
        

        // Update is called once per frame
        void Update()
        {
            if (playerDetected && Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame && !PlayerMovement.dialogueActive)
            {
                PlayerMovement.dialogueActive = true;
                Debug.Log("Player detected and F pressed");
            }
        }

        void newDialogue(string dialogue)
        {
            // Implement your dialogue system here
            Debug.Log("Starting dialogue: " + dialogue);

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerDetected = true;
                Debug.Log("Player detected");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerDetected = false;
                Debug.Log("Player lost");
            }
        }
    }
}
