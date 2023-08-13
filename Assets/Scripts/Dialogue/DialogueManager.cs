using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {

        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private TextMeshProUGUI displayNameText;
        [SerializeField] private Animator portraitImage;

        private Story _currentStory;
    
        private static DialogueManager _instance;

        private const string SpeakerTag = "speaker";
        private const string PortraitTag = "portrait";

        public bool DialogueIsPlaying { get; private set; }

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
            DialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
        }

        private void Update()
        {
            if (!DialogueIsPlaying)
            {
                return;
            }
        
            //continue to check player input
            if (Input.GetKeyDown("space") && Time.timeScale != 0)
            { 
                ContinueStory();
            }
        }

        public void EnterDialogueMode(TextAsset inkJson)
        {
            _currentStory = new Story(inkJson.text);
            DialogueIsPlaying = true;
            dialoguePanel.SetActive(true);
            dialogueText.text = _currentStory.currentText;
        }

        private void ExitDialogueMode()
        {
            DialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
            dialogueText.text = "";
        }

        private void ContinueStory()
        {
            if (_currentStory.canContinue)
            {
                dialogueText.text = _currentStory.Continue();
                HandleTags(_currentStory.currentTags);
            }
            else
            {
                ExitDialogueMode();
            }
        }

        private void HandleTags(List<string> currentTags)
        {
            foreach (string inkTag in currentTags)
            {
                string[] splitTag = inkTag.Split(':');
                if (splitTag.Length != 2)
                {
                    Debug.LogError("Tag could not be parsed: " + inkTag);
                }

                string tagKey = splitTag[0].Trim();
                string tagValue = splitTag[1].Trim();

                switch (tagKey)
                {
                    case SpeakerTag:
                        displayNameText.text = tagValue;
                        break;
                    case PortraitTag:
                        portraitImage.Play(tagValue);
                        break;
                }

            }
        }
    }
}
