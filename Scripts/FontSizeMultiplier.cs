using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FontSizeMultiplier : MonoBehaviour
{
	//public FloatReference FontMultiplier;
	
	public TMP_Text Text;
	private float baseFontSize;
	
	void Awake(){
		baseFontSize = Text.fontSize;
	}
	public void InputFloat(float input){
		
		Text.fontSize = baseFontSize * input;
	}
}
