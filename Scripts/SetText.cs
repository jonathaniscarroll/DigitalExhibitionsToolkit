using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetText : MonoBehaviour
{
	[SerializeField]
	private string _text;
	public string text {
		get{return _text;}
		set{
			_text = value;
			OutputText.Invoke(_text);
		}
	}
	public StringEvent OutputText;
}
