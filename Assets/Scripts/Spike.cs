using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	public bool activated, selfActivating;
	public bool origState;


	void Update(){
	}

	void Start(){
		origState = activated;

		if (activated)
			Activate ();
	}

	public void Hold(){
		activated = !origState;
		if(activated) Activate();
		else Deactivated();

//		else Off();
	}

//	public void Switch(){
//		if(activated)
//			Off();
//		else
//			Activate();
//	}
//
//	public void Switch(bool b){
//		if (b)
//			Activate ();
//		else
//			Off();
//	}
//
	public void Activate(){
		activated = true;

		transform.GetChild(0).gameObject.SetActive(true);
	}

	public void Deactivated(){
		activated = false;
		transform.GetChild(0).gameObject.SetActive(false);
	}

	public void Off(){
		activated = origState;
		transform.GetChild(0).gameObject.SetActive(activated);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (!activated && selfActivating){
			Activate ();

			if(col.gameObject.tag == "Player")
				col.gameObject.GetComponent<Player>().Die ();
		}
		else if (activated && col.gameObject.tag == "Player" && !col.gameObject.GetComponent<Unrescued>()) {
			Activate();		
			col.gameObject.GetComponent<Player>().Die();
		}
	}
}
