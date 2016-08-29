using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
Controls the game portion of the project
**/
public class Game : MonoBehaviour 
{
	public AudioMap _map;
	public GameObject _sun;
	public GameObject _ama;
	public GameObject _rice;

	private float _Score;

	void Start() {
		//start scrolling
		gameObject.GetComponentInChildren<BackgroundScript>().enabled = true;
		GetComponent<AudioSource>().Play();
		animateElements();

	}

	void animateElements() {
		Debug.Log("Animating Elements" + _map.bpm);
		_sun.GetComponent<Animator>().speed = _map.bpm/160;
		_ama.GetComponent<Animator>().speed = _map.bpm/160;
		_rice.GetComponent<Animator>().speed = _map.bpm/160;
	}
}