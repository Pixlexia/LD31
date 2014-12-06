using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

	ParticleSystem ps;

	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem> ();
		ps.renderer.sortingLayerName = "Frontest";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
