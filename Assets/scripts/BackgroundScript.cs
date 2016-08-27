using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**

**/
public class BackgroundScript : MonoBehaviour 
{
	private float _scrollSpeed;
	private Vector3 startPosition;

	void Start() {
		float bpm = (gameObject.transform.parent.GetComponent<Game>())._map.bpm;
		startPosition = transform.position;
	}

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * _scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;
	}
}