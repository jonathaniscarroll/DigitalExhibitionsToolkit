using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringPool : MonoBehaviour
{
	public List<string> PageNames;
	public StringEvent OutputNewString;
	public StringEvent OutputExistingString;
	public void InputString(string input){
		if(PageNames==null){
			PageNames = new List<string>();
		}
		if(PageNames.Contains(input)){
			OutputExistingString.Invoke(input);
		} else {
			PageNames.Add(input);
			OutputNewString.Invoke(input);
		}
	}
}
