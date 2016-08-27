using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
Controls the game portion of the project
**/
public class Game : MonoBehaviour 
{
	public AudioMap _map;

	private float _Score;


	void Start() {
		//start scrolling
		gameObject.GetComponentInChildren<BackgroundScript>().enabled = true;

	}
}