using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/**
Creates an instance of an Audio Map for the music that was entered.
Audio Map will have 
**/
public class AudioMapper : MonoBehaviour, AudioProcessor.AudioCallbacks {

	private AudioProcessor _processor;
	private System.DateTime _beginning;
	public Text _loadingText;
	public Animator[] flowers;
	public GameObject petal;
	public GameObject sparkle1;
	public GameObject sparkle2;

	public float Length; //length of this audio clip
	public float Increments;

	private ArrayList beats = new ArrayList();
	private float beatCount = 0;

	private bool finished = false;

	void Start() 
	{
		_processor = FindObjectOfType<AudioProcessor>();
		_processor.addAudioCallback(this);
		_beginning = System.DateTime.Now;
		Increments = Length/5; //for loading time
		Debug.Log("length" + this.Length);
	}

	void Update()
	{
		if (!finished && _beginning != null)
		{	
			float diff = System.DateTime.Now.Subtract(_beginning).Seconds; 
			float diffPercent = (diff/Length)*100;
			if (diffPercent > 100) {
				diffPercent = 100;
			}
			_loadingText.text = "Loaded " + diffPercent + "%";

			if (diff  >= Length) { //finished
				flowers[4].SetBool("loaded", true);
				FinishedSong();
			} else {
				if (diffPercent > 100) {
				}
				else if (diffPercent > 80) {
					flowers[3].SetBool("loaded", true);
				}
				else if (diffPercent > 60) {
					flowers[2].SetBool("loaded", true);
				}
				else if (diffPercent > 40) {
					flowers[1].SetBool("loaded", true);
				}
				else if (diffPercent > 20) {
					flowers[0].SetBool("loaded", true);
				} 
			}

			
		}
		//TODO Loading Bar using length
	}

	public void onOnbeatDetected() 
	{
		if (this.enabled == true) {
			beatCount += 1;
			beats.Add(System.DateTime.Now.Subtract(_beginning).Seconds);
		}
		// spawn little petals
		SpawnPetal();
	}

	void SpawnPetal() {
		float y1 = 296f;
		float y2 = 200f;
		float x1 = 164f;
		float x2 = 427;

		var spawnPoint = new Vector2 (Random.Range (x1, x2), Random.Range (y1, y2));

		Instantiate (petal, spawnPoint, Quaternion.identity);
		
		if (Random.Range(0, 5) ==  2)  {
			var spawnPoint2 = new Vector2 (Random.Range (x1, x2), Random.Range (y1, 99f));
			GameObject sparkleOne = Instantiate (sparkle1, spawnPoint2, Quaternion.identity) as GameObject;
			sparkleOne.GetComponent<Transform>().parent = this.gameObject.transform;
		}

		if (Random.Range(0, 5) == 3) {
			var spawnPoint3 = new Vector2 (Random.Range (x1, x2), Random.Range (y1, 99f));
			GameObject sparkleTwo = Instantiate (sparkle2, spawnPoint3, Quaternion.identity) as GameObject;
			sparkleTwo.GetComponent<Transform>().parent = this.gameObject.transform;
		}

	}

	public void onSpectrum(float[] spectrum)
    {
        //The spectrum is logarithmically averaged
        //to 12 bands

        for (int i = 0; i < spectrum.Length; ++i)
        {
        /**
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
            //highlgihts.add(TimeStmap)
            **/
        }
    }

    private void FinishedSong() {
    	AudioMap map = new AudioMap();
    	map.bpm = beatCount*60/Length;
    	map.beats = (float[]) (this.beats).ToArray(typeof(float));
    	Debug.Log("bpm" + map.bpm);
    	finished = true;

    	Transform parent = this.transform.parent; //parent being menu
    	parent.GetComponent<AudioSource>().Stop(); //get manu's sound source to stop

    	//try to make a button before 

    	foreach(Transform child in parent.parent) //now go through canvas'schildren
    	{
    		if (child.name == "Game") {
    			child.gameObject.SetActive(true);
    			//child.gameObject.GetComponent<AudioSource>().clip = parent.GetComponent<AudioSource>().clip;
    			Game game = child.GetComponent<Game>();
				game.enabled = true;
    			game._map = map;
    			game._audio = parent.GetComponent<AudioSource>().clip;
    		}
    	}

    	parent.gameObject.SetActive(false);
    	this.gameObject.SetActive(false);

    }
}