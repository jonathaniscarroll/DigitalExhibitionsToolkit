using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
	public List<Material> Materials;
	public MaterialEvent OutputMaterial;
	public void OutputRandom(){
		Material output = Materials[Random.Range(0,Materials.Count-1)];
		OutputMaterial.Invoke(output);
		
	}
}
