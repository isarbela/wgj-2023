using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRealWolrdController : MonoBehaviour
{
    public float speed;
    public GameObject bg;
    private Vector3 _boundSize;
    public float rotateSpeed = 3.0f;
    private bool turnleft = true;

    private void Start()
    {
        _boundSize = bg.GetComponent<Renderer>().bounds.size;
        _boundSize /= 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= _boundSize.x)
        {
            if (transform.position.x > 0)
            {
                transform.position = new Vector3(_boundSize.x, transform.position.y, 0);
            }
            else
            {
                transform.position = new Vector3(_boundSize.x * -1, transform.position.y, 0);
            }
        }


        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        transform.position += playerInput.normalized * (speed * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !turnleft)
        {
            transform.RotateAround(transform.position, transform.up, 180f);
            turnleft = true;
        }

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && turnleft)
        {
            transform.RotateAround(transform.position, transform.up, 180f);
            turnleft = false;
        }
    }
}