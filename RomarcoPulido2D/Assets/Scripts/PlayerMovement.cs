using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 15;
    public Vector2 limits = new Vector2 (5, 3.5f);
    // Start is called before the first frame update
    void Start(){

        
    }

    // Update is called once per frame
    void Update(){
        
        //Get current Horizontal Movement
        float horDirection = Input.GetAxisRaw ("Horizontal");
;        Vector3 horMove = horDirection * Vector3.right;
        
        /*if (transform.position.x > -limits.x || transform.position.x < limits.x) {
            horMove *= 0;
            int limit = (int)transform.position.x;
            Vector3 temp = transform.position;
            temp.x = limit;
            transform.position = temp;
        }*/
        //Get current Vertical Movement
        float verDirection = Input.GetAxisRaw ("Vertical");
        Vector3 verMove = verDirection * Vector3.up;

        Vector3 temp = transform.position;
        transform.Translate ((horMove + verMove).normalized * moveSpeed * Time.deltaTime);
        temp.x = Mathf.Clamp (transform.position.x, -limits.x, limits.x);
        temp.y = Mathf.Clamp (transform.position.y, -limits.x, limits.y);
        transform.position = temp;

        /*if ((transform.position.x < -limits.x || transform.position.x > limits.x) ||
            (transform.position.y < -limits.y || transform.position.y > limits.y)) {
            transform.position = Temp;
        }*/

    }

    void OnTriggerEnter2D (Collider2D other){
        Debug.Log ("colision");

    }

    void OnDrawGizmos (){
        Gizmos.DrawSphere (transform.position, 0.15f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube (Vector3.zero, limits);

    }
}
