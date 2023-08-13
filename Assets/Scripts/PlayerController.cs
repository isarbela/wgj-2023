using System;
using Dialogue;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform weapon;
    public Camera mainCamera;
    public float offset;

    public Transform shotPoint;
    public GameObject bubbleTile;

    public float shotsInterval;
    private float _nextShotTime;

    private Vector2 _screenBounds;
    public GameObject bg;
    private Vector3 _boundSize;

    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _boundSize = bg.GetComponent<Renderer>().bounds.size;
        _boundSize /= 2;
    }

    // Update is called once per frame
    private void Update()
    {
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            return;
        }

        if (Mathf.Abs(transform.position.y) >= _boundSize.y)
        {
            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, _boundSize.y, 0);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, _boundSize.y * -1, 0);
            }
        }
        
        if (Mathf.Abs(transform.position.x) >= _boundSize.x)
        {
            if (transform.position.x > 0)
            {
                transform.position = new Vector3(_boundSize.x, transform.position.y, 0);
            }
            else
            {
                transform.position = new Vector3(_boundSize.x  * -1, transform.position.y, 0);
            }
        }

        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += playerInput.normalized * (speed * Time.deltaTime);

        //Weapon movement
        Vector3 displacement = weapon.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //Calculate the angle between weapon and mouse cursor
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, angle + offset);
        
        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > _nextShotTime)
            {
                _nextShotTime = Time.time + shotsInterval;
                GameObject newBubble = Instantiate(bubbleTile, shotPoint.position, shotPoint.rotation);
                Destroy(newBubble, 5f);
            }
        }

    }
}
