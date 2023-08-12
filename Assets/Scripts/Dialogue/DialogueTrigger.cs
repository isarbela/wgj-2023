using Dialogue;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;

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
        if (Input.GetKeyDown("space") && visualCue.activeSelf)
        {
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
