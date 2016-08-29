using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**

**/
public class BackgroundScript : MonoBehaviour 
{
	public bool started;

	private float _scrollSpeed;
	private Vector3 startPosition;
	//background is a 3200x600px moving horizontally - only x changes
	void Start() {
		float bpm = 120;
		float bpmInSeconds = 60 / bpm;
		//(gameObject.transform.parent.GetComponent<Game>())._map.bpm;
		_scrollSpeed = bpm/5;
		startPosition = transform.position;
	}

	void Update ()
	{
		if (started) {
			Debug.Log(transform.position.x);
			if (transform.position.x > -120) {
				float newPosition = Mathf.Repeat(Time.time * _scrollSpeed, 1000);
				transform.position = startPosition + Vector3.left * newPosition;
			} else {
				transform.position = startPosition;
			}
		}
	}
}