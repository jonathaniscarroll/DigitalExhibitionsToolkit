using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTextureFromRawImage : MonoBehaviour
{
	public RawImage RawImage;
	public TextureEvent TextureOutput;
	
	public void Output(){
		TextureOutput.Invoke(RawImage.texture);
	}
}
