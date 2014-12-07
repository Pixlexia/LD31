using UnityEngine;
using System.Collections;

public class PositionUI : MonoBehaviour {

	public GameObject player; 
	public float yoffset;
	// Use this for initialization
	void Start () { 

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.position = new Vector3 (player.transform.position.x,player.transform.position.y + yoffset,0);
	}

}
