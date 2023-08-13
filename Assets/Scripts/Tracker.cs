using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public Transform trackedObject;
    public float updateSpeed = 7.5f;
    public Vector2 trackingOffset;
    private Vector3 _offset;
    public GameObject bg;
    private Vector3 _boundSize;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
        _offset = (Vector3)trackingOffset;
        _offset.z = transform.position.z - trackedObject.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, trackedObject.position + _offset, updateSpeed * Time.deltaTime);
        
    }
}
