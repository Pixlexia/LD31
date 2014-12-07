using UnityEngine;
using System.Collections;

public class SpikeShooter : MonoBehaviour {

	public bool facingUp, shooting;
	public GameObject spike;
	public float atkDelay, atkCounter;

	public bool origShooting;

	void Start(){
		if(atkDelay == 0)
			atkDelay = 1;

		origShooting = shooting;
	}

	void Update(){
		atkCounter -= Time.deltaTime;

		if (shooting) {

			if(atkCounter <= 0.00f)
				Shoot ();
		}
	}

	void Shoot(){
		GameObject s = Instantiate (spike, transform.position, Quaternion.identity) as GameObject;
		s.GetComponent<Projectile> ().dir = facingUp;

		atkCounter = atkDelay;
	}

	public void Activate(){
		shooting = !origShooting;
	}

	public void Deactivate(){
		shooting = origShooting;
	}
}
