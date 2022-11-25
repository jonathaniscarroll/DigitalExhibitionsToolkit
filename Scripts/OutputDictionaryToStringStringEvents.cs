using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputDictionaryToStringStringEvents : MonoBehaviour
{
	public StringStringEvent StringStringEvent;
	public void InputDictionary(Dictionary<string,string> input){
		foreach(KeyValuePair<string,string> kvp in input){
			StringStringEvent.Invoke(kvp.Key,kvp.Value);
		}
	}
}
