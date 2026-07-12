using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyScripts.NPCScripts
{
    public class PlayerDetection : MonoBehaviour
    {
        private bool playerDetected = false;
        private bool isDialogueActive = false;
        private Coroutine typingCoroutine;

        private Transform playerTransform;

        public TextMeshProUGUI dialogueText;
        public string[] dialogue;
        private int index;

        public float wordSpeed = 0.002f;

        void Update()
        {
            if (playerDetected && Keyboard.current.fKey.wasPressedThisFrame)
            {
                if (!isDialogueActive)
                {
                    
                    StartDialogue();
                    WinScreen.Instance.HideFButton();
                }
                else if (dialogueText.text == dialogue[index])
                {
                    NextLine();
                }
            }

            
        }

        private void StartDialogue()
        {
            isDialogueActive = true;
            WinScreen.Instance.ShowDialogue();
            index = 0;
            dialogueText.text = "";
            typingCoroutine = StartCoroutine(TypeDialogue());
        }

        IEnumerator TypeDialogue()
        {
            dialogueText.text = "";
            foreach (char letter in dialogue[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }
        }

        public void NextLine()
        {
            if (index < dialogue.Length - 1)
            {
                index++;
                if (typingCoroutine != null) StopCoroutine(typingCoroutine);
                typingCoroutine = StartCoroutine(TypeDialogue());
            }
           
        }

        

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerDetected = true;

                if (GetComponentInParent<NPC>() is NPC npc && npc.Agent != null)
                {
                    npc.Agent.isStopped = true;
                }
                WinScreen.Instance.FButton.SetActive(true);
                Debug.Log("Player detected. NPC stopped.");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerDetected = false;

                if (GetComponentInParent<NPC>() is NPC npc && npc.Agent != null)
                {
                    npc.Agent.isStopped = false;
                }
                WinScreen.Instance.HideAll();
            }
        }
    }
}