using UnityEngine;
using System.Collections;

public class KnightoPlayer : MonoBehaviour{
	Rigidbody2D KnightoRB;
	public float maxVelocidad;
	Animator KnightoAnim;

	bool puedeMover = true;

	//saltar
	bool enSuelo = false;
	float CheckearRadioSuelo = 0.2f;
	public LayerMask capaSuelo;
	public Transform chequearSuelo;
	public float poderSalto;
	
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
	if (puedeMover && enSuelo && Input.GetAxis("Jump") > 0) {
	KnightoAnim.SetBool ("estaEnSuelo",false);
	KnightoRB.velocity = new Vector2 (KnightoRB.velocity.x, 0f);
	KnightoRB.AddForce (new Vector2 (0, poderSalto), ForceMode2D.Impulse);
	enSuelo = false;
	}

	enSuelo = Physics2D.OverlapCircle (chequearSuelo.position, CheckearRadioSuelo, capaSuelo);
	KnightoAnim.SetBool ("estaEnSuelo", enSuelo);

		float mover = Input.GetAxis ("Horizontal");

		if(puedeMover) {
		if(mover > 0 && !voltearKnighto){
			Voltear();
			}
		else if(mover < 0 && voltearKnighto){
			Voltear();
		}

		KnightoRB.velocity = new Vector2 (mover * maxVelocidad, KnightoRB.velocity.y);

			//hacer que corra
			KnightoAnim.SetFloat("VelMovimiento", Mathf.Abs(mover));
		} else {
			KnightoRB.velocity = new Vector2 (0, KnightoRB.velocity.y);

			KnightoAnim.SetFloat("VelMovimiento", 0);
		}
   
    }
	
	void Voltear(){
		voltearKnighto = !voltearKnighto;
		KnightoRender.flipX = !KnightoRender.flipX;
	}

	public void togglepuedeMover(){
		puedeMover = !puedeMover;
	}
}
