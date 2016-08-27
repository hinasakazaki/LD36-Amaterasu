using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class AudioLoader : MonoBehaviour
{
	public AudioSource source;
	private float audioLength;
	string URL; //has to be to .ogg
	// https://en.wikipedia.org/wiki/File:Sample_of_%22Another_Day_in_Paradise%22.ogg

	public void onEdited(string url) {
		Debug.Log("edited "+  url);
		URL = url;
	}
	
	public void StartDownload() 
	{
		WWW www = new WWW(URL);
		source = GetComponent<AudioSource>();
		source.clip = www.GetAudioClip(false, false, AudioType.OGGVORBIS);
		audioLength = source.clip.length;
	}

	void Update() 
	{
		if (source.clip != null && !source.isPlaying && source.clip.loadState == AudioDataLoadState.Loaded) 
		{
			Debug.Log("HINA");
			onFinished();
		} 
	}

	void onFinished() 
	{
		Debug.Log("Finished loading sound");
		gameObject.AddComponent<AudioProcessor>();
		gameObject.AddComponent<AudioMapper>();
		gameObject.GetComponent<AudioMapper>().Length = this.audioLength;
		source.Play();
	}
}