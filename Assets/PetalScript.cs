using UnityEngine;
using System.Collections;

public class PetalScript : MonoBehaviour {
	float speed = 50.0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		float leftright = Random.Range(-30f, 30f);
		transform.position += Vector3.left * leftright * Time.deltaTime;
		transform.position += Vector3.down * speed * Time.deltaTime;
	}
}
