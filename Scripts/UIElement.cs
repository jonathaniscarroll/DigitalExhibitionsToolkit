using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement : MonoBehaviour
{
	public StringEvent StringEvent;
	public void InputString(string input){
		Debug.Log(input);
		StringEvent.Invoke(input);
	}
}
