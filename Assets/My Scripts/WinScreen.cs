using UnityEngine;

public class WinScreen : MonoBehaviour
{
    // singleton instance accessible from anywhere
    public static WinScreen Instance { get; private set; }

    void Awake()
    {
        // assign singleton and start hidden
        Instance = this;
        gameObject.SetActive(false);
    }

    public void ShowWinScreen()
    {
        Debug.Log("Congratulations! You win!");
        gameObject.SetActive(true);
    }
}
