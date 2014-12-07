using UnityEngine;
using System.Collections;

public class RippleEffect : MonoBehaviour {
	
	public float minimum = 0.0f;
	public float maximum = 1f;
	public float duration = 5.0f;
	public Vector3 start, target;
	private float startTime;
	
	//public SpriteRenderer sprite;
	
	void Start() {
		startTime = Time.time;
	}
	void Update() {
		float t = (Time.time - startTime) / duration;
		GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r,
		                                                 GetComponent<SpriteRenderer>().color.g,
		                                                 GetComponent<SpriteRenderer>().color.b,
		                                                 Mathf.SmoothStep(maximum, minimum, t));
		transform.localScale = Vector3.Lerp(start, target, t);
		
		if(t >= duration)
			Destroy(gameObject);
	}
}