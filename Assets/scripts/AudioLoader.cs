using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class AudioLoader : MonoBehaviour
{
	public AudioSource _source;
	private float audioLength;
	private AudioClip _audio;
	string _url; //has to be to .ogg
	// https://upload.wikimedia.org/wikipedia/en/9/9f/Sample_of_%22Another_Day_in_Paradise%22.ogg

	private bool finished = false;

	public void onEdited(string url) {
		Debug.Log("edited "+  url);
		_url = url;
	}

	public void EnterButtonPressed()
	{
		StartCoroutine(StartDownload());
	}
	
	public IEnumerator StartDownload() 
	{
		WWW www = new WWW(_url);
		
		yield return www;

		_source = GetComponent<AudioSource>();
		_audio = www.GetAudioClip(false, false, AudioType.OGGVORBIS);
		_audio.LoadAudioData();
		Resources.Load<AudioClip>();
		_source.clip = _audio;
		Debug.Log("what is this clip" + _source.clip);
		Debug.Log("Is source playing?" + _source.isPlaying);
	}

	void Update() 
	{

		if (_source.clip != null && !_source.isPlaying && _source.clip.isReadyToPlay) 
		{
			Debug.Log("JSDFKKF");
			onFinished();
/**			Debug.Log("Going to switch statement!");
			switch (source.clip.loadState)
			{
				case (AudioDataLoadState.Unloaded): Debug.Log("Unloaded"); break;
				case (AudioDataLoadState.Loading): Debug.Log("Loading"); break;
				case (AudioDataLoadState.Loaded): onFinished(); finished = true; break;
				case (AudioDataLoadState.Failed): onFailed(); finished = true; break;
			}
			**/
		} 
	}

	void onFailed() {
		Debug.Log("FAILED");
	}
	void onFinished() 
	{
		Debug.Log("Finished loading sound");
		gameObject.AddComponent<AudioProcessor>();
		gameObject.AddComponent<AudioMapper>();
		gameObject.GetComponent<AudioMapper>().Length = this.audioLength;
		_source.Play();
	}
}