using UnityEngine;
using UnityEngine.InputSystem;

public class CoinScript : MonoBehaviour
{
    private bool isPlayerInside;
    [SerializeField] private AudioClip coinPickupSound;
    private void Start()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            WinScreen.Instance.ShowFButtonPick();
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            WinScreen.Instance.HideFButton();
        }
    }

    private void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (isPlayerInside)
            {
                SFXManager.Instance.PlaySound(coinPickupSound, transform);
                CoinManager.AddCoin();
                WinScreen.Instance.HideFButton();
                Disappear();
            }
        }
    }

    
    private void Disappear()
    {
        gameObject.SetActive(false);
    }
}
