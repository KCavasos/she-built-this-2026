using UnityEngine;
using TMPro;

public class SequenceManager : MonoBehaviour
{
    public GameObject DialogueCanvas;
    public TextMeshProUGUI DialogueText; 
    
    // Public static property accessible from any script
    public static SequenceManager Instance { get; private set; }
    
    //Start in dialogue
    public bool isInDialogue = true;

    public GameObject[] IntroDialogueSequence;
    
    string[] IntroSequenceStrings =
    {
        "HIGH PRIESTESS: \nAcolyte, wake up! \n",
        "HIGH PRIESTESS: \nYour hard work and sacred studies have paid off. You are ready to conduct your first Rite of Awakening.",
        "ACOLYTE: \n[sleepily] Thank you, High Priestess. What is the Rite of Awakening?",
        "HIGH PRIESTESS:\nHave you ever heard the Song of Awakening just before dawn breaks?\n",
        "ACOLYTE:\nFaintly, from time to time. I am rarely awake that early…\n\n",
        "HIGH PRIESTESS:\nYes, few are. However, if one of our order does not conduct this rite, dawn does not break at all here. \n",
        "ACOLYTE:\nWhat do you mean?! Nobody has ever told me this.\n",
        "HIGH PRIESTESS:\nWe do not speak of it outside of the clergy. People are sometimes alarmed to learn that our sun does not rise of its own accord. The rhythms of life must be conscientiously maintained here.",
        "ACOLYTE:\nI see. What must I do?",
        "HIGH PRIESTESS:\nI will show you. Follow me.\n",
        "HIGH PRIESTESS:\nThis is the Dawn Turtle. He is called Dado. Look closely at his shell.\n",
        "ACOLYTE:\nIs it… an altar?",
        "HIGH PRIESTESS:\nYes. Within each of the circles, you must place a special creature called a Noteling. Each of these creatures sings one note in the Song of Awakening. The Dawn Turtle will continue to slumber until you have assembled all six of the Notelings. When he wakes, the Dawn Turtle will summon the sun.",
        "The Notelings are nocturnal. They always scatter and get up to mischief while we sleep. You will need to find (and in some cases rescue) them. The Notelings will follow you. If they are harmed while in your care, the Noteling will return to where you first found them. Any Notelings you bring to the Dawn Turtle will stay safely on his shell until the Rite is complete.",
        "Now, let’s practice your Slumber Bolt. Put that Rock Element to sleep.",
        "Good. Now, seek out the Notelings.",
    };
    int IntroSequenceIndex = 0;
    bool IsIntroSequence = true;

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Delete duplicate
            return;
        }

        // Set the active instance
        Instance = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //open game with mouse being visible and dialogue open
        SetCursorState(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnContinueButtonPressed()
    {
        print("Continue button pressed");

        if (IsIntroSequence)
        {
            NextIntroSequenceDialogue();
        }
        
    }

    public void NextIntroSequenceDialogue()
    {
        IntroSequenceIndex++;
        if (IntroSequenceIndex < IntroSequenceStrings.Length)
        {
            SetCursorState(true);
            DialogueText.text = IntroSequenceStrings[IntroSequenceIndex];
        }
        else
        {
            IsIntroSequence = false;
            SetCursorState(false);
        }
    }
    
    private void SetCursorState(bool Visible)
    {
        Cursor.lockState = Visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = Visible;  
			
        
    }
}
