using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
[System.Serializable]
public class StringStringReferenceEvent:UnityEvent<string,StringReference>{}
public class DictionaryOfDictionaries : MonoBehaviour
{
	
	public StringReference CurrentDictionary;
	
	public StringDictionaryList Dictionary;
	
	public StringStringDictionaryEvent DictionaryEvent;
	public StringStringEvent StringStringEvent;
	public StringStringReferenceEvent StringStringReferenceEvent;
	public StringEvent OutputOnFail;
	
	public void Output(string input){
		NamedStringReferenceList nsr = Dictionary.DictionaryList.Find(x=>x.name==input).dictionary;
		nsr.SaveToDictionary();
		Dictionary<string,string> output = nsr.Dictionary;
		DictionaryEvent.Invoke(output);
	}
	
	public void OutputStringStringEvents(string input){
		Debug.Log(input,gameObject);
		NamedStringReferenceList nsrl = Dictionary.DictionaryList.Find(x=>x.name==input).dictionary;
		Debug.Log(input);
		if(nsrl!=null&&nsrl.NamedStringReferences!=null){
			foreach(NamedStringReference nsr in nsrl.NamedStringReferences){
				StringStringEvent.Invoke(nsr.Name,nsr.StringRef.Value);
				StringStringReferenceEvent.Invoke(nsr.Name,nsr.StringRef);
			}
		} else {
			OutputOnFail.Invoke(input);
		}
	}
	
	public void AddToCurrent(string key,string value){
		NamedStringReferenceList nsrl = Dictionary.DictionaryList.Find(x=>x.name==CurrentDictionary.Value).dictionary;
		if(nsrl!=null){
			if(nsrl.NamedStringReferences==null){
				nsrl.NamedStringReferences = new List<NamedStringReference>();
			}
			StringReference stringReference = new StringReference();
			stringReference.UseConstant = false;
			int count = 0;
			string fileName = "UI-Elements-"+CurrentDictionary.Value +"-"+ key +"-"+ value;
			while(nsrl.NamedStringReferences.Find(x=>x.StringRef.Variable.name==fileName)!=null){
				fileName = fileName +"-"+ count;
				count++;
			}
			string path = "Assets/DigitalExhibitionsToolkit/ScriptableObjects/_UI/Elements/"+fileName+".asset";
			StringVar stringVar = StringVariable(value,path);
			stringReference.Variable = stringVar;
			NamedStringReference entry = new NamedStringReference(key,stringReference);
			nsrl.NamedStringReferences.Add(entry);
			StringStringReferenceEvent.Invoke(key,stringReference);
		}
	}
	
	public StringVar StringVariable(string _val,string path){
		StringVar output = ScriptableObject.CreateInstance<StringVar>();
		output.Value = _val;
		AssetDatabase.CreateAsset(output,path);
		//EditorUtility.FocusProjectWindow();
		//Selection.activeObject = this;
		return output;
	}

}
