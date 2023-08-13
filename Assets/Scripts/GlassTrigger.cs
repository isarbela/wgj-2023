using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GlassTrigger : MonoBehaviour
{
    
    [SerializeField] private GameObject tooltip;
    [SerializeField] private GameObject glass;
    public static bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
        tooltip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tooltip.SetActive(playerInRange);
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
