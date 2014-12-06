using UnityEngine;
using System.Collections;

public class LerpToTarget : MonoBehaviour {

	public GameObject target;
	public float lerpamt;
	
	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position, new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z), lerpamt);
	}
}
