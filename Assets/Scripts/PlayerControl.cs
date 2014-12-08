using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed;
	public Vector2 move;

	// Use this for initialization
	void Start () {
	}

	void Update(){
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Movement();
	}

	public void Movement2(){
		Vector2 movement;
		movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		rigidbody2D.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Stairs")
			speed /= 1.5f;
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "Stairs")
			speed *= 1.5f;
	}

	public void Movement(){
		if(Input.GetKey (KeyCode.A)){
			move.x = -1;
		}
		else if(Input.GetKey (KeyCode.D)){
			move.x = 1;
		}
		else{
			move.x = 0;
		}
		
		if(Input.GetKey (KeyCode.W)){
			move.y = 1;
		}
		else if(Input.GetKey (KeyCode.S)){
			move.y = -1;
		}
		else{
			move.y = 0;
		}
		
		rigidbody2D.velocity = move.normalized * speed * Time.deltaTime;
	}
}
