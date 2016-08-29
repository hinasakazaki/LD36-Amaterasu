using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class SunScript : MonoBehaviour {

	public GameObject _NICE;
	public GameObject _NOTGOOD;
	public float[] _beats;
	public float _score;
	public Text _scoreBoard;
	public bool _gameStarted;

	public System.DateTime _startTime;

	// Use this for initialization
	void Start () {
		_NICE.SetActive(false);
		_NOTGOOD.SetActive(false);
		_score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (_gameStarted) _scoreBoard.text = "SCORE: " + _score;
	}

	void OnMouseDown()
 	{
 		if (_gameStarted)
    	{ 
    		GetComponent<Animator>().SetTrigger("clicked");
	    	float diff = System.DateTime.Now.Subtract(_startTime).Seconds; 
	    	if (_beats.Contains(diff)) {
	    		_score += 1;
	    		_NICE.SetActive(true);
	    		_NOTGOOD.SetActive(false);
	    	} else {
	    		_score -= 5;
	    		_NICE.SetActive(false);
	    		_NOTGOOD.SetActive(true);
	    	}
	    }
 	}
}
