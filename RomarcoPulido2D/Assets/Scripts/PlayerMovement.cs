using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 15;
    public Vector2 limits = new Vector2 (10, 7);
    Vector2 shapeLimits { get { return limits - ((colliderSize * transform.localScale) / 2); } }
    Vector2 colliderSize;

    // Start is called before the first frame update
    void Start (){
        Vector2 colliderSize = gameObject.GetComponent<BoxCollider2D> ().size;


    }

    // Update is called once per frame
    void Update(){
        
        //Get current Horizontal Movement
;        Vector3 horMove = Input.GetAxisRaw ("Horizontal") * Vector3.right;
    

        /*if (transform.position.x > -limits.x || transform.position.x < limits.x) {
            horMove *= 0;
            int limit = (int)transform.position.x;
            Vector3 temp = transform.position;
            temp.x = limit;
            transform.position = temp;
        }*/
        //Get current Vertical Movement
        Vector3 verMove = Input.GetAxisRaw ("Vertical") * Vector3.up;

        Vector3 temp = transform.position;
        transform.Translate ((horMove + verMove).normalized * moveSpeed * Time.deltaTime);
        temp.x = Mathf.Clamp (transform.position.x, -shapeLimits.x, shapeLimits.x);
        temp.y = Mathf.Clamp (transform.position.y, -shapeLimits.y, shapeLimits.y);
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
        Gizmos.DrawWireCube (Vector3.zero, limits * 2);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube (Vector3.zero, shapeLimits * 2);

    }
}
