using UnityEngine;
using System.Collections;

public class branchMovement : MonoBehaviour {
	public float dur, max, min;
	// Use this for initialization
	void Start () {
		dur = Random.Range (1,dur+1);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.gameObject.tag == "LeftBranch")
		{
			transform.rotation = transform.rotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y,
			                                                           Mathf.PingPong(Time.time * dur, max-min)+min);
		}
		else if(transform.gameObject.tag == "RightBranch")
		{
			transform.rotation = transform.rotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y,
			                                                           Mathf.PingPong(Time.time * dur-2, (max-min)*-1)+((min)*-1));
		}
	}
}
