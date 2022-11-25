using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class StringDictionaryList : ScriptableObject
{
	[System.Serializable]
	public class NamedDictionary{
		public string name;
		public NamedStringReferenceList dictionary;
	}
	
	public List<NamedDictionary> DictionaryList;
}
