using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
