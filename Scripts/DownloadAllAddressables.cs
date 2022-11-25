using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;

public class DownloadAllAddressables : MonoBehaviour
{
	
	public StringEvent CheckingSize;
	public StringEvent OutputDownloadProgress;
	public StringEvent OnAssetDownloadComplete;
	public void Download(){
		var allLocations = new List<IResourceLocation>();
		foreach (var resourceLocator in Addressables.ResourceLocators)
		{
			if (resourceLocator is ResourceLocationMap map)
			{
				foreach (var locations in map.Locations.Values)
				{
					allLocations.AddRange(locations);
				}
			}
		}
		StartCoroutine(Run(allLocations));
		
	}
	[field:SerializeField]
	public bool Confirmed{get;set;}
	
	IEnumerator Run(List<IResourceLocation> allLocations){
		var preloadSize = Addressables.GetDownloadSizeAsync(allLocations);
		while(!preloadSize.IsDone || !Confirmed){
			
			CheckingSize.Invoke(((int)preloadSize.Result*1000000).ToString());
			yield return new WaitForEndOfFrame();
			
		}
		//Addressables.Release(preloadSize);
		 
		if (preloadSize.Result > 0)
		{
			//Log($"Starting download of {preloadSize / (1024f * 1024f):n2}mbs");
			 
			var oneSecond = System.TimeSpan.FromSeconds(1f);
			var preloadOp = Addressables.DownloadDependenciesAsync(allLocations);
			while (!preloadOp.IsDone)
			{
				var status = preloadOp.GetDownloadStatus();
				OutputDownloadProgress.Invoke($"Downloading in progress: {status.DownloadedBytes / (1024f * 1024f):n2}mbs/{status.TotalBytes / (1024f * 1024f):n2}mbs ({status.Percent * 100f:n0}%)");
				yield return new WaitForEndOfFrame();
			}
			 
			Addressables.Release(preloadSize);
			Addressables.Release(preloadOp);
			OnAssetDownloadComplete.Invoke("");
			//Log($"Download of all assets complete!");
		}
		else
		{
			//Log($"All assets up to date!");
		}
		 
		
		//AsyncOperationHandle<IResourceLocator> handle = Addressables.InitializeAsync();
		//var allKeys = handle.Keys.ToList();
		//var size =  Addressables.GetDownloadSizeAsync(allKeys);
		
		//var downloadSize = Addressables.GetDownloadSizeAsync();
		//while(!downloadSize.IsDone){
		//	CheckingSize.Invoke(((int)downloadSize.GetDownloadStatus().Percent*100).ToString());
		//	yield return new WaitForEndOfFrame();
		//}
		//float download = Mathf.Round(downloadSize.Result/1000000);
		//while(!ConfirmDownload && downloadSize.Result>0){
		//	OutputSize.Invoke(download.ToString());
		//	yield return new WaitForEndOfFrame();
		//}
	}
}
