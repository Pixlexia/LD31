using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public bool dir;
	float yspeed;

	void Start(){
		Destroy (gameObject, 3f);
		yspeed = 20;

		if (!dir)
			yspeed *= -1;
	}

	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, yspeed * Time.deltaTime, 0);
	}
}
