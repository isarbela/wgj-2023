using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTrigger : MonoBehaviour
{
    
    [SerializeField] private GameObject tooltip;
    [SerializeField] private GameObject glass;
    private bool _playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        _playerInRange = false;
        tooltip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tooltip.SetActive(_playerInRange);
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
