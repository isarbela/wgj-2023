using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRealWolrdController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += playerInput.normalized * (speed * Time.deltaTime);
    }
}
