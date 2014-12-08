using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayTextAnim : MonoBehaviour {
	public Color transparent;
	public string text;
	public float speed;
	public float sentenceEnd;
	public float pause;
	public bool caps;
	public float delayBeforeFadeOut;

	float animSpeed;
	string tempText;
	bool textDone;

	void Start(){ 
		textDone = false;

		if(caps)
		{
			text = text.ToUpper();
		}
		StartCoroutine( AnimateText(text) ); 
	}

	void Update(){
		if(textDone)
		{
			FadeOutText();
		}
	}
	
	IEnumerator AnimateText(string strComplete)
	{ 
		int i = 0; 
		tempText = ""; 
		while( i < strComplete.Length )
		{ 
			if(strComplete[i] == '%')
			{	
				animSpeed = pause; 
				i++;
			}
			else if(strComplete[i] == '.')
			{
				animSpeed = sentenceEnd;
				tempText += strComplete[i++];
			}
			else
			{
				animSpeed = speed;
				tempText += strComplete[i++];
			}	
			gameObject.transform.GetComponent<Text>().text = tempText;
			yield return new WaitForSeconds(animSpeed); 
		} 
		yield return new WaitForSeconds(delayBeforeFadeOut); 
		textDone = true;
		Destroy (gameObject, 3f);
	}

	void FadeOutText(){
		gameObject.transform.GetComponent<Text> ().color = Color.Lerp (gameObject.transform.GetComponent<Text> ().color,transparent, .1f);
	}
}
