using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public bool isMoving;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Deadly") {
			Die ();		
		}
	}

	void Die(){
		Destroy (gameObject);
	}
}
