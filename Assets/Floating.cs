using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {
	bool floatup;

	// Use this for initialization
	void Start () {
		floatup = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (floatup) {
			StartCoroutine("FloatingUp");		
		}
		else{
			StartCoroutine("FloatingDown");		
		}
	}
	
	IEnumerator FloatingUp(){
		transform.position += new Vector3(0,0.3f * Time.deltaTime,0);
		float r = Random.Range (0, 0.5f);
		yield return new WaitForSeconds (1 + r);
		floatup = false;
	}

	IEnumerator FloatingDown(){
		transform.position -= new Vector3(0,0.3f * Time.deltaTime,0);
		float r = Random.Range (0, 0.5f);
		yield return new WaitForSeconds (1 + r);
		floatup = true;
	}
}
