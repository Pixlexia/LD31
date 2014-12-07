using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameColors : MonoBehaviour {
	public Color red, yellow, green, blue;
	public static Dictionary<string, Color> colors;

	// Use this for initialization
	void Awake () {
		colors = new Dictionary<string, Color> ();

		colors.Add ("yellow", yellow);
		colors.Add ("red", red);
		colors.Add ("green", green);
		colors.Add ("blue", blue);
	}
}
