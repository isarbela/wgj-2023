using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float followSpeed = 2f;
    public Transform target;
    public GameObject bg;
    private Vector3 _boundSize;

    private void Start()
    {
        _boundSize = bg.GetComponent<Renderer>().bounds.size;
        _boundSize /= 2;
        _boundSize -= Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        newPos.x = Mathf.Clamp(target.position.x, _boundSize.x * -1,  _boundSize.x);
        newPos.y = Mathf.Clamp(target.position.y, _boundSize.y * -1, _boundSize.y);
        transform.Translate(newPos - transform.position);
    }
}
