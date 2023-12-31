using UnityEngine;

namespace Dialogue
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject visualCue;

        [Header("Ink JSON")]
        [SerializeField] private TextAsset inkJson;

        private bool _playerInRange;

        private void Awake() 
        {
            _playerInRange = false;
            visualCue.SetActive(false);
        }

        private void Update()
        {
            visualCue.SetActive(_playerInRange);
            if (Input.GetKeyDown("space") && visualCue.activeSelf && Time.timeScale != 0) {
                DialogueManager.GetInstance().EnterDialogueMode(inkJson);
                _playerInRange = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.CompareTag("Player"))
            {
                _playerInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.CompareTag("Player"))
            {
                _playerInRange = false;
            }
        }
    }
}
