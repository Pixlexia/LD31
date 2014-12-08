using UnityEngine;
using System.Collections;

public class bodyMovement : MonoBehaviour {
	public GameObject leftLeg;
	public GameObject rightLeg;
	public GameObject body;
	public float legDur, legMax, legMin;
	public float bodyDur, bodyMax, bodyMin;
	public PlayerControl moveScript;
	public FollowPlayer followScript;
	// Use this for initialization
	public virtual void Start () {
		moveScript = GetComponent<PlayerControl> ();
		followScript = GetComponent<FollowPlayer> ();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		//IF PLAYER IS MOVING
		if(followScript.isMoving || (moveScript.move.x != 0 || moveScript.move.y != 0))
		{
			MoveAnimation();
		}
		else
		{
			StopAnimation();
		}

		//BODY
		body.transform.localPosition = new Vector3(body.transform.localPosition.x, Mathf.PingPong(Time.time * bodyDur, bodyMax-bodyMin)+bodyMin, body.transform.localPosition.z);
	}

	public void MoveAnimation(){
		//LEG
		leftLeg.transform.rotation = rightLeg.transform.rotation = Quaternion.Euler(leftLeg.transform.localRotation.x, leftLeg.transform.localRotation.y,
		                                                                            Mathf.PingPong(Time.time * legDur, legMax-legMin)+legMin);
	}

	public void StopAnimation(){
		//LEG
		leftLeg.transform.rotation = rightLeg.transform.rotation = transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(
			leftLeg.transform.localRotation.x,leftLeg.transform.localRotation.y,0f)),1f);
//		BODY
//		body.transform.localPosition = Vector3.Lerp(body.transform.localPosition,new Vector3(body.transform.localPosition.x,0f,body.transform.localPosition.z),1f);
	}
}
