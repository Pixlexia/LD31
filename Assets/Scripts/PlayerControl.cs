using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameObject dieParticle1, dieParticle2;

	public float speed;
	public Vector2 move;

	// Use this for initialization
	void Start () {
	
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

	public void Die(){
		if (dieParticle1 && dieParticle2) {
			Instantiate (dieParticle1, transform.position + new Vector3(0,0.3f,0), Quaternion.identity);
			Instantiate (dieParticle2, transform.position + new Vector3(0,0.3f,0), Quaternion.identity);
		}

//		foreach (Transform go in GetComponentsInChildren<Transform>())
//			go.gameObject.renderer.enabled = false;
	}
}
