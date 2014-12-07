using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public bool brokenFromGroup;
	public GameObject target;
	public bool isMoving;

	// Use this for initialization
	void Start () {
	}

	public void BreakFromGroup(){
		brokenFromGroup = true;
		GetComponent<FollowPlayer> ().enabled = false;
	}

	public void ConnectToGroup(){
		brokenFromGroup = false;
//		GetComponent<FollowPlayer> ().enabled = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Vector3.Distance (transform.position, target.transform.position) > 1.5f && Vector3.Distance (transform.position, target.transform.position) < 10){
			transform.position = Vector3.Lerp (transform.position, target.transform.position, 0.05f);
			isMoving = true;
		}
		else{
			isMoving = false;
		}
	}

	void OnEnable(){
		isMoving = false;
	}

	void OnDisable(){
		isMoving = false;
	}
}
