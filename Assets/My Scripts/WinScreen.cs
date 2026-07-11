using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public static WinScreen Instance { get; private set; }

    // Assign these in the Unity Inspector
    [SerializeField] private GameObject winScreenPanel;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] public GameObject FButton;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
    }

    private void Start()
    {
        HideAll();
        HideFButton();
    }

    public void HideAll()
    {
        winScreenPanel.SetActive(false);
        dialoguePanel.SetActive(false);
        FButton.SetActive(false);
    }

    public void ShowWinScreen()
    {
        Debug.Log("Congratulations! You win!");
        winScreenPanel.SetActive(true);
        dialoguePanel.SetActive(false);
    }

    public void ShowDialogue()
    {
        winScreenPanel.SetActive(false);
        dialoguePanel.SetActive(true);
    }

    public void ShowFButtonPick()
    {
        FButton.SetActive(true);

        var textComponent = FButton.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = "Pick Up";
        }
        else
        {
            var legacyText = FButton.GetComponentInChildren<UnityEngine.UI.Text>();
            if (legacyText != null)
            {
                legacyText.text = "Pick Up";
            }
        }
    }

    

    public void HideFButton()
    {
        FButton.SetActive(false);
    }

    
}