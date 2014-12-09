using UnityEngine;
using System.Collections;

public class StartingCamera : MonoBehaviour {

	public GameObject p;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position, p.transform.position, 0.005f);

		if(Vector3.Distance(p.transform.position, transform.position) < 0.1f){
			p.GetComponent<PlayerControl>().enabled = true;
			p.GetComponent<LerpToTarget>().enabled = true;
			GetComponent<StartingCamera>().enabled = false;
		}
	}
}
