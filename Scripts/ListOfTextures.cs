using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfTextures : MonoBehaviour
{
	public List<Texture> Textures;
	public TextureEvent OutputTexture;	
	public void OutputRandom(){
		OutputTexture.Invoke(Textures[Random.Range(0,Textures.Count)]);
	}
}
