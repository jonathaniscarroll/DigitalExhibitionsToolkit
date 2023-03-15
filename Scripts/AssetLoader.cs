using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class AssetLoader : MonoBehaviour
{
	public AssetReference AssetReferencePrefab;
	public StringEvent LoadingProgress;
	public GameObjectEvent OutputLoadedGameObject;
	public StringEvent CheckingSize;
	public StringEvent OutputSize;
	[field:SerializeField]
	public bool ConfirmDownload{get;set;}
	private AsyncOperationHandle<GameObject> handle;
	public void LoadAsset(){
		StartCoroutine(Loading());
	}
	
	IEnumerator Loading(){
		var downloadSize = Addressables.GetDownloadSizeAsync(AssetReferencePrefab.RuntimeKey);
		while(!downloadSize.IsDone){
			CheckingSize.Invoke(((int)downloadSize.GetDownloadStatus().Percent*100).ToString());
			yield return new WaitForEndOfFrame();
		}
		float download = Mathf.Round(downloadSize.Result/1000000);
		while(!ConfirmDownload && downloadSize.Result>0){
			OutputSize.Invoke(download.ToString());
			yield return new WaitForEndOfFrame();
		}
		var loadedAsset = AssetReferencePrefab.LoadAssetAsync<GameObject>();
		loadedAsset.Completed += DownloadComplete;
		handle = loadedAsset;
		while(!loadedAsset.IsDone){
			int progress = (int)(loadedAsset.GetDownloadStatus().Percent*100);
			LoadingProgress.Invoke(progress.ToString());
			yield return new WaitForEndOfFrame();
		}
	}
	
	void DownloadComplete(AsyncOperationHandle<GameObject> input){
		if(input.Status == AsyncOperationStatus.Succeeded){
			AssetReferencePrefab.InstantiateAsync().Completed+=(loadedGameObject)=>
			{
				GameObject output = loadedGameObject.Result;
				OutputLoadedGameObject.Invoke(output);
			};
			
		}
	}
	
	void OnDisable(){
		if(handle.IsValid())
		Addressables.Release(handle);
	}
	
}
