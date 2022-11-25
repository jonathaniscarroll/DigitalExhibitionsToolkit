using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryOfDictionaries : MonoBehaviour
{
	public StringDictionaryList Dictionary;
	
	public StringStringDictionaryEvent DictionaryEvent;
	public StringStringEvent StringStringEvent;
	
	public void Output(string input){
		NamedStringReferenceList nsr = Dictionary.DictionaryList.Find(x=>x.name==input).dictionary;
		nsr.SaveToDictionary();
		Dictionary<string,string> output = nsr.Dictionary;
		DictionaryEvent.Invoke(output);
	}
	
	public void OutputStringStringEvents(string input){
		NamedStringReferenceList nsrl = Dictionary.DictionaryList.Find(x=>x.name==input).dictionary;
		Debug.Log(input);
		if(nsrl!=null){
			foreach(NamedStringReference nsr in nsrl.NamedStringReferences){
				StringStringEvent.Invoke(nsr.Name,nsr.StringReference.Value);
			}
		}
	}
}
