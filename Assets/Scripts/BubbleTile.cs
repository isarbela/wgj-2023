using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTile : MonoBehaviour
{
    public float speed;
    public int damage; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
    }
}
