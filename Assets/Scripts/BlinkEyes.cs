using UnityEngine;
using System.Collections;

public class BlinkEyes : MonoBehaviour {
	public Vector3 start, target;
	public float closeDur,openDur;
	public bool isBlinking;

	// Use this for initialization
	void Start () {
		start = new Vector3 (1, 1, 1);
		isBlinking = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(Random.Range(0,20) == 3)
		{
			if(isBlinking)
				isBlinking = false;
			else
				isBlinking = true;
		}

		if(!isBlinking)
		{	
			StartCoroutine(Blinking());
		}

	}

	void BlinkClose(){
		gameObject.transform.localScale = Vector3.Lerp (gameObject.transform.localScale,target,closeDur * Time.deltaTime *50);
	}
	void BlinkOpen(){
		gameObject.transform.localScale = Vector3.Lerp (gameObject.transform.localScale,start,openDur * Time.deltaTime *50);
	}

	IEnumerator Blinking(){
		BlinkClose ();
		yield return new WaitForSeconds(3f);
		BlinkOpen ();
	}
}
