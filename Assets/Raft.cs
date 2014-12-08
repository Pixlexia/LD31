using UnityEngine;
using System.Collections;

public class Raft : MonoBehaviour {

	public int count;
	public bool startMoving;

	public GameObject[] playerPositions;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startMoving) {
			transform.position += new Vector3(1 * Time.deltaTime, 0,0);		
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<PlayerControl>().enabled && col.gameObject.GetComponent<Player>().colortype
		     != ColoredPath.MyColor.blue) {
			col.gameObject.GetComponent<Player>().EnterRaft();

			col.transform.parent = transform;

			count++;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<PlayerControl>().enabled && col.gameObject.GetComponent<Player>().colortype
		    != ColoredPath.MyColor.blue) {
			count--;
		}
	}
}
