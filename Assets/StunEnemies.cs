using UnityEngine;
using System.Collections;

public class StunEnemies : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			DoStunEnemies();
		}
	}

	public void DoStunEnemies(){
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject go in targets) {
			if(Vector3.Distance(go.transform.position, transform.position) < 12){
				go.GetComponent<Enemy>().Stun();
			}
		}
	}
}
