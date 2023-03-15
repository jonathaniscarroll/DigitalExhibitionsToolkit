using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TextMeshProUGUI))]
public class OpenHyperlinks : MonoBehaviour {
	
	private TMP_Text text = default;
	private Camera pCamera;
	
	public void CheckLink() {
		if(pCamera==null){
			pCamera = Camera.main;
		}
		if(text==null){
			text = GetComponent<TMP_Text>();
		}
		int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
		if( linkIndex != -1 ) { // was a link clicked?
			TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];

			// open the link id as a url, which is the metadata we added in the text field
			Application.OpenURL(linkInfo.GetLinkID());
		}
	}
}