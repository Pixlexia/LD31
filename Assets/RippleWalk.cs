using UnityEngine;
using System.Collections;

public class RippleWalk : MonoBehaviour {
	public GameObject shadowPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D go){
		if(go.gameObject.tag == "WaterPlatform")
		{
			InvokeRepeating ("RippleActive",0f,.2f);
		}
	}

	void OnTriggerExit2D(Collider2D go)
	{
		if(go.gameObject.tag == "WaterPlatform")
		{
			CancelInvoke("RippleActive");
		}
	}

	public void RippleActive(){
		GameObject idle = Instantiate (Resources.Load("Ripple"),shadowPos.gameObject.transform.position,transform.rotation) as GameObject;
		idle.GetComponent<RippleEffect> ().target = new Vector3 (2f,0.8f,2f);
		//idle.transform.parent = GameObject.Find("Effects").transform.parent;
	}
}
