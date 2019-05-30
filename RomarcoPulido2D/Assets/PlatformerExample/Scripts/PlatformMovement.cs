using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public float gravity = 9;
    public float horizontalSpeed = 15;

    float verticalSpeed;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        transform.Translate (Vector3.right * Input.GetAxis ("Horizontal") * horizontalSpeed * Time.deltaTime);
        verticalSpeed += gravity * Time.deltaTime;
        transform.Translate (Vector3.down * verticalSpeed * Time.deltaTime);
    }
}
