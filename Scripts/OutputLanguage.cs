using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputLanguage : MonoBehaviour
{
	public string textLanguageCode = System.Globalization.CultureInfo.CurrentCulture.Name;
	public StringEvent OutputString;
	public void Output(){
		OutputString.Invoke(textLanguageCode);
	}
}
