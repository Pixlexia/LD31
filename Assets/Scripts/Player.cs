using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public ColoredPath.MyColor colortype;

	// Particles
	public GameObject dieParticle1, playerColorParticle, keyParticle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = Vector2.Lerp (rigidbody2D.velocity, Vector2.zero, 0.2f);
	}
	
	public void Die(){
		if (dieParticle1 && playerColorParticle) {
			Instantiate (dieParticle1, transform.position + new Vector3(0,0.3f,0), Quaternion.identity);
			GameObject p = Instantiate (playerColorParticle, transform.position + new Vector3(0,0.3f,0), Quaternion.identity) as GameObject;
//			Debug.Log (transform.GetChild(0).GetComponent<SpriteRenderer>().color);
//			Debug.Log (p);
			p.GetComponent<ParticleSystem>().startColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
		}

		gameObject.SetActive (false);
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Deadly") {
			Die ();		
		}
		else if(col.gameObject.tag == "Key"){
			PlayerMaster.hasKey = true;
			Destroy (col.gameObject);
			Instantiate(keyParticle, transform.position, Quaternion.identity);
		}
	}
}
