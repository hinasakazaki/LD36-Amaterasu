using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/**
Controls the game portion of the project
**/
public class Game : MonoBehaviour 
{
	public AudioMap _map;
	public GameObject _sun;
	public GameObject _ama;
	public GameObject _rice;
	public AudioClip _audio;
	public Text _text;
	public Text _subtext;
	public GameObject _gameover;
	
	private float _songLength;

	private string[] textArray = {"Then, there was the God who controlled it.", "She listens to the calls of nature", "and provides sunlight to all who lives.", "Listen to the sound,", "Click on the Sun on the beats,", "and shine the world with harmony.", "Are you ready?"};
	private int textIndex = 0;

	private float _Score;
	private bool _started;

	void Start() {
		//start scrolling
		GetComponent<AudioSource>().Play();
		_sun.GetComponent<Animator>().speed = _map.bpm/160;
		_songLength = _audio.length;
		_started = false;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space) && textIndex <= textArray.Length) {
			if (textIndex == textArray.Length) {
				_started = true;
				StartGame();
			} else {
				if (textIndex == 0) {
				_ama.SetActive(true);
				} else if (textIndex == textArray.Length -1) {
					_subtext.text = "space to start";
				} 
				_text.text = textArray[textIndex];
				textIndex += 1;
			}
		}

		if (_started && System.DateTime.Now.Subtract(_sun.GetComponent<SunScript>()._startTime).Seconds >= _songLength) {
			endGame();
		}
	}


	void endGame() {
		_sun.GetComponent<SunScript>()._gameStarted = true;
		gameObject.GetComponentInChildren<BackgroundScript>().started = false;
		_ama.SetActive(false);
		_rice.SetActive(false);
		_sun.SetActive(false);
		_gameover.SetActive(true);
	}

	void StartGame() {
		_text.text = "";
		_subtext.text = "";
		GetComponent<AudioSource>().Stop();

		//start playing audio that's loaded
		GetComponent<AudioSource>().clip = _audio;
		_sun.GetComponent<SunScript>()._beats = _map.beats;
		_sun.GetComponent<SunScript>()._gameStarted = true;
		_sun.GetComponent<SunScript>()._startTime = System.DateTime.Now;
		GetComponent<AudioSource>().Play();
		gameObject.GetComponentInChildren<BackgroundScript>().started = true;
		animateElements();
	}

	void animateElements() {
		Debug.Log("Animating Elements" + _map.bpm);
		_ama.GetComponent<Animator>().speed = _map.bpm/160;
		_rice.SetActive(true);
		_rice.GetComponent<Animator>().speed = _map.bpm/160;
	}
}