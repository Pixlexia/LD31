using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public bool brokenFromGroup;
	public GameObject target;

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
		if(Vector3.Distance(transform.position, target.transform.position) > 1.2f && Vector3.Distance(transform.position, target.transform.position) < 6)
			transform.position = Vector3.Lerp (transform.position, target.transform.position, 0.05f);
	}
}
