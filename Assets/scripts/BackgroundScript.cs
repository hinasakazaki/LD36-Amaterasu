using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**

**/
public class BackgroundScript : MonoBehaviour 
{
	private float _scrollSpeed;
	private Vector3 startPosition;
	//background is a 3200x600px moving horizontally - only x changes
	void Start() {
		float bpm = 120;
		float bpmInSeconds = 60 / bpm;
		//(gameObject.transform.parent.GetComponent<Game>())._map.bpm;
		_scrollSpeed = bpm/60;
		startPosition = transform.position;
	}

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * _scrollSpeed, 1000);
		transform.position = startPosition + Vector3.left * newPosition;
	}
}