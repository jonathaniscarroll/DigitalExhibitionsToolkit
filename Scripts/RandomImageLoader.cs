using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class RandomImageLoader : MonoBehaviour
{
	public string baseUrl = "http://example.com/images/";
	//public string[] folders = { "folder1", "folder2", "folder3" };
	[field:SerializeField]	
	public string chosenFolder {get;set;}
	public Texture2DEvent OutputTexture2D;
	
	public List<FolderImageCount> FolderImageCounts;
	
	private Texture2D loadedTexture;
	
	[System.Serializable]
	public class FolderImageCount{
		public string folderName;
		public int imageCount;
	}

	public void Load()
	{
		StartCoroutine(LoadRandomImage());
	}

	private IEnumerator LoadRandomImage()
	{
		// Randomly select a folder
		//string randomFolder = folders[Random.Range(0, folders.Length)];
        
		// Construct the URL for the random image in the random folder
		string randomImageUrl = baseUrl + chosenFolder + "/" + Random.Range(0,FolderImageCounts.Find(x => x.folderName==chosenFolder).imageCount) + ".jpg";
		Debug.Log(randomImageUrl);

		using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(randomImageUrl))
		{
			// Send the request and wait for the response
			yield return www.SendWebRequest();

			if (www.result == UnityWebRequest.Result.Success)
			{
				loadedTexture = new Texture2D(2, 2);
				// Get the downloaded texture
				loadedTexture = DownloadHandlerTexture.GetContent(www);

				// Use the texture in your Unity project
				//GetComponent<Renderer>().material.mainTexture = texture;
				
				OutputTexture2D.Invoke(loadedTexture);

				Debug.Log("Random image loaded from: " + randomImageUrl);
			}
			else
			{
				Debug.LogError("Error loading random image: " + www.error);
			}
		}
	}
	
	public void UnloadTexture(){
		if(loadedTexture!=null){
			Destroy(loadedTexture);
			System.GC.Collect();	
		}
		
	}
	
	
}

