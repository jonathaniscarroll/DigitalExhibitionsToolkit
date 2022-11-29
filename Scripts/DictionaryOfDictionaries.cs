using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryOfDictionaries : MonoBehaviour
{
	[field:SerializeField]
	public string CurrentDictionary{get;set;}
	
	public StringDictionaryList Dictionary;
	
	public StringStringDictionaryEvent DictionaryEvent;
	public StringStringEvent StringStringEvent;
	public StringEvent OutputOnFail;
	
	public void Output(string input){
		NamedStringReferenceList nsr = Dictionary.DictionaryList.Find(x=>x.name==input).dictionary;
		nsr.SaveToDictionary();
		Dictionary<string,string> output = nsr.Dictionary;
		DictionaryEvent.Invoke(output);
	}
	
	public void OutputStringStringEvents(string input){
		NamedStringReferenceList nsrl = Dictionary.DictionaryList.Find(x=>x.name==input).dictionary;
		Debug.Log(input);
		if(nsrl!=null&&nsrl.NamedStringReferences!=null){
			foreach(NamedStringReference nsr in nsrl.NamedStringReferences){
				StringStringEvent.Invoke(nsr.Name,nsr.StringReference.Value);
			}
		} else {
			OutputOnFail.Invoke(input);
		}
	}
	
	public void AddToCurrent(string key,string value){
		NamedStringReferenceList nsrl = Dictionary.DictionaryList.Find(x=>x.name==CurrentDictionary).dictionary;
		if(nsrl!=null&&nsrl.NamedStringReferences!=null){
			NamedStringReference entry = new NamedStringReference(key,value);
			nsrl.NamedStringReferences.Add(entry);
			
		}
	}
}
