using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Vector3 dir;
	float speed;

	void Start(){
		Destroy (gameObject, 3f);
		speed = 20;

		if (dir.x != 0) {
			transform.Rotate(new Vector3(0,0,90));		
		}
	}

	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (dir.x * speed * Time.deltaTime, dir.y * speed * Time.deltaTime, 0);
	}
}
