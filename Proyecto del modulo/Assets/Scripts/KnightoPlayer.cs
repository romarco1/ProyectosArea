using UnityEngine;
using System.Collections;

public class KnightoPlayer : MonoBehaviour{
	Rigidbody2D KnightoRB;
	public float maxVelocidad;
	Animator KnightoAnim;
	
	//voltear personaje
	bool voltearKnighto = true;
	SpriteRenderer KnightoRender;
	
	
    // Start is called before the first frame update
    void Start(){
		KnightoRB = GetComponent<Rigidbody2D>();
		KnightoRender = GetComponent<SpriteRenderer>();
		KnightoAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update(){
		float mover = Input.GetAxis ("Horizontal");
		
		if(mover > 0 && !voltearKnighto){
			Voltear();
			}
		else if(mover < 0 && voltearKnighto){
			Voltear();
			
			
		}
		KnightoRB.velocity = new Vector2 (mover * maxVelocidad, KnightoRB.velocity.y);
		//hacer que corra
		KnightoAnim.SetFloat("VelMovimiento", Mathf.Abs(mover))
		
        
    }
	
	void Voltear(){
		voltearKnighto = !voltearKnighto;
		KnightoRender.flipX = !KnightoRender.flipX;
	}
}
