using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AudioclipLoader : MonoBehaviour
{
	[SerializeField]
	private string _audioUrl;
	public string audioUrl{
		get{return _audioUrl;}
		set{
			_audioUrl = value;
			StartCoroutine(DownloadAndPlayAudio(_audioUrl));	
		}
	} // URL of the audio file
	public AudioSource audioSource; // Reference to the AudioSource component

	void Start()
	{
		if(!string.IsNullOrEmpty(audioUrl))
		StartCoroutine(DownloadAndPlayAudio(audioUrl));
	}

	IEnumerator DownloadAndPlayAudio(string url)
	{
		AudioType audioType = GetAudioTypeFromUrl(url);

		using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, audioType))
		{
			yield return www.SendWebRequest();

			if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
			{
				Debug.LogError("Error downloading audio: " + www.error);
			}
			else
			{
				AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
				if (clip == null)
				{
					Debug.LogError("Error: Audio clip is null. Unsupported file format or corrupted file.");
				}
				else
				{
					audioSource.clip = clip;
					audioSource.Play();
					Debug.Log("Audio clip loaded and playing");
				}
			}
		}
	}

	AudioType GetAudioTypeFromUrl(string url)
	{
		string extension = System.IO.Path.GetExtension(url).ToLower();

		switch (extension)
		{
		case ".mp3":
			return AudioType.MPEG;
		case ".wav":
			return AudioType.WAV;
		case ".ogg":
			return AudioType.OGGVORBIS;
		case ".aiff":
			return AudioType.AIFF;
		case ".mod":
			return AudioType.MOD;
		case ".it":
			return AudioType.IT;
		case ".s3m":
			return AudioType.S3M;
		case ".xm":
			return AudioType.XM;
		default:
			Debug.LogWarning("Unsupported audio type, defaulting to WAV");
			return AudioType.WAV; // Default to WAV if the extension is unknown
		}
	}
}
