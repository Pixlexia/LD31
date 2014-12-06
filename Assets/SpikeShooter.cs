using UnityEngine;
using System.Collections;

public class SpikeShooter : MonoBehaviour {

	public bool facingUp, shooting;
	public GameObject spike;
	public float atkDelay, atkCounter;

	void Start(){
		if(atkDelay == 0)
			atkDelay = 1;
	}

	void Update(){
		if (shooting) {
			atkCounter -= Time.deltaTime;

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
		shooting = true;
	}

	public void Deactivate(){
		shooting = false;
	}
}
