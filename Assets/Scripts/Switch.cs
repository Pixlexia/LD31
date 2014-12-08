using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
//	public enum TargetType { spike, door, spikeshooter, coloredpath }
	public Vector3 origPos;
	public bool state = false;
	Transform child1;
	
	public GameObject[] target;

	public virtual void Start(){
		child1 = transform.GetChild (0);
		origPos = transform.localPosition;
	}

	void Update(){
		Debug.Log ("asd");

		if(state)
			child1.localPosition = new Vector3 (child1.localPosition.x, -0.07f, child1.localPosition.z);
		else
			child1.localPosition = new Vector3 (child1.localPosition.x, 0, child1.localPosition.z);;
	}
}
