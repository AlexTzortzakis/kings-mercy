using UnityEngine;
using UnityEngine.InputSystem;

public class CoinScript : MonoBehaviour
{
    private bool isPlayerInside;
    private void Start()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.name);
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            Debug.Log("Player entered coin collider");
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            Debug.Log("Player exited coin collider");
        }
    }

    private void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            Debug.Log("F pressed. isPlayerInside: " + isPlayerInside);
            if (isPlayerInside)
            {
                CoinManager.AddCoin();
                Disappear();
            }
        }
    }

    
    private void Disappear()
    {
        gameObject.SetActive(false);
    }
}
