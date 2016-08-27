using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class AudioLoader : MonoBehaviour
{
	public AudioSource _source;
	private AudioClip _audio;
	string _url; //has to be to .ogg
	// https://upload.wikimedia.org/wikipedia/en/8/89/Daft_Punk_-_Get_Lucky.ogg

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
		if (_url == null) {
			//Maybe give a message about how you didnt enter Audio URL
			_url = "https://upload.wikimedia.org/wikipedia/en/8/89/Daft_Punk_-_Get_Lucky.ogg"; //default
		}
		WWW www = new WWW(_url);
		
		yield return www;

		_source = GetComponent<AudioSource>();
		_audio = www.GetAudioClip(false, false, AudioType.OGGVORBIS);
		_audio.LoadAudioData();
		_source.clip = _audio;
		Debug.Log("what is this clip" + _source.clip);
		Debug.Log("Is source playing?" + _source.isPlaying);
	}

	void Update() 
	{

		if (_source.clip != null && !_source.isPlaying && _source.clip.isReadyToPlay) 
		{
			onFinished();
		} 
	}

	void onFailed() {
		Debug.Log("FAILED");
	}

	void onFinished() 
	{
		gameObject.AddComponent<AudioProcessor>();
		gameObject.AddComponent<AudioMapper>();
		gameObject.GetComponent<AudioMapper>().Length = _audio.length;
		_source.Play();
		this.enabled = false;
	}
}