using System;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story _currentStory;
    
    private static DialogueManager _instance;

    public bool dialogueIsPlaying { get; private set; }

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("There is more than one Dialogue Manager in the scene!");
        }

        _instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return _instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
        
        //continue to check player input
        if (Input.GetKeyDown("space"))
        { 
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        _currentStory = new Story(inkJson.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (_currentStory.canContinue)
        {
            dialogueText.text = _currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }
}
