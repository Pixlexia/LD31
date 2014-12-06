using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject dieParticle1, dieParticle2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Die(){
		if (dieParticle1 && dieParticle2) {
			Instantiate (dieParticle1, transform.position + new Vector3(0,0.3f,0), Quaternion.identity);
			Instantiate (dieParticle2, transform.position + new Vector3(0,0.3f,0), Quaternion.identity);
		}


	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Deadly") {
			Die ();		
		}
	}
}
