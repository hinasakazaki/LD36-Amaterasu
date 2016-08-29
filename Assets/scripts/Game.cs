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

	private string[] textArray = {"Then, there was the God who controlled it.", "She listens to the calls of nature", "and provides sunlight to all who lives.", "Listen to the sound,", "Click on the Sun on the beats,", "and shine the world with harmony.", "Are you ready?"};
	private int textIndex = 0;

	private float _Score;

	void Start() {
		//start scrolling
		GetComponent<AudioSource>().Play();
		_sun.GetComponent<Animator>().speed = _map.bpm/160;

	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space) && textIndex <= textArray.Length) {
			if (textIndex == textArray.Length) {
				_text.text = "";
				_subtext.text = "";
				GetComponent<AudioSource>().Stop();
				GetComponent<AudioSource>().clip = _audio;
				StartGame();
			} else if (textIndex == 0) {
				_ama.SetActive(true);
			} else if (textIndex == textArray.Length -1) {
				_subtext.text = "space to start";
			}
			_text.text = textArray[textIndex];
			textIndex += 1;
		}
	}

	void StartGame() {
		gameObject.GetComponentInChildren<BackgroundScript>().enabled = true;
		animateElements();
	}
	
	void animateElements() {
		Debug.Log("Animating Elements" + _map.bpm);
		_ama.GetComponent<Animator>().speed = _map.bpm/160;
		_rice.GetComponent<Animator>().speed = _map.bpm/160;
	}
}