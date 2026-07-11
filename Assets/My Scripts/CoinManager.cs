using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

public class CoinManager: MonoBehaviour
{
    
    // public WinScreen winScreen;

    private static int currentCoins;
    private const int targetCoins = 3;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        currentCoins = 0;
        Debug.Log("GameManager Initialized");
    }
    public static void AddCoin()
    {
        currentCoins++;
        if (currentCoins >= targetCoins)
        {
            Debug.Log("Player has collected enough coins to win!");
            if (WinScreen.Instance != null)
            {
                WinScreen.Instance.ShowWinScreen();
                Time.timeScale = 0f; // pause
            }
            else
            {
                Debug.LogError("WinScreen.Instance not found! Make sure WinScreen is in the scene.");
            }


        }
    }

    
}