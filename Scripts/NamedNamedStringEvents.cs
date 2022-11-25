using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamedNamedStringEvents : MonoBehaviour
{
	[System.Serializable]
	public class NamedNamedStringEvent{
		public string name;
		public NamedStringReferenceList namedStringReference;
	}
	
	public List<NamedNamedStringEvent> namedNamedStringReferences;
	
	public StringStringDictionaryEvent DictionaryEvent;
	public StringStringEvent StringStringEvent;
	
	public void Output(string input){
		NamedStringReferenceList nsr = namedNamedStringReferences.Find(x=>x.name==input).namedStringReference;
		nsr.SaveToDictionary();
		Dictionary<string,string> output = nsr.Dictionary;
		DictionaryEvent.Invoke(output);
	}
	
	public void OutputStringStringEvents(string input){
		NamedStringReferenceList nsrl = namedNamedStringReferences.Find(x=>x.name==input).namedStringReference;
		if(nsrl!=null){
			foreach(NamedStringReference nsr in nsrl.NamedStringReferences){
				StringStringEvent.Invoke(nsr.Name,nsr.StringReference.Value);
			}
		}
	}
}
