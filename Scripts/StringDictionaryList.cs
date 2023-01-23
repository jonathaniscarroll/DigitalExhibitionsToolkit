using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu]
public class StringDictionaryList : ScriptableObject
{
	[System.Serializable]
	public class NamedDictionary{
		public string name;
		public NamedStringReferenceList dictionary;
		public NamedDictionary(string _name,string _dictionaryName){
			NamedStringReferenceList newDictionary = ScriptableObject.CreateInstance<NamedStringReferenceList>();
			string path = "Assets/DigitalExhibitionsToolkit/ScriptableObjects/_UI/Pages/UI-Pages-"+_name+".asset";
			#if UNITY_EDITOR
			AssetDatabase.CreateAsset(newDictionary,path);
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = newDictionary;
			#endif
			name = _name;
			dictionary = newDictionary;
		}
	}
	
	public List<NamedDictionary> DictionaryList;
	public StringListEvent OutputNamesEvent;
	
	public void CreateNewEntry(string name, string scriptableObjectName){
		NamedDictionary newDictionary = new NamedDictionary(name, scriptableObjectName);
		DictionaryList.Add(newDictionary);
	}
	
	public void OutputListOfNames(){
		List<string> list = new List<string>();
		foreach(NamedDictionary dict in DictionaryList){
			list.Add(dict.name);
		}
		OutputNamesEvent.Invoke(list);
	}
}
