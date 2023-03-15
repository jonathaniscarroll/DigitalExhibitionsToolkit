using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement : MonoBehaviour
{
	public StringReference StringReference;
	public StringEvent StringEvent;
	public void InputString(string input){
		StringReference.Value = input;
		StringEvent.Invoke(input);
	}
}
