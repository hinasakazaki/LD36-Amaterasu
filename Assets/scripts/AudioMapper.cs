using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
Creates an instance of an Audio Map for the music that was entered.
Audio Map will have 
**/
public class AudioMapper : MonoBehaviour, AudioProcessor.AudioCallbacks {

	private AudioProcessor _processor;
	private System.DateTime _beginning;

	public float Length; //length of this audio clip

	private ArrayList beats;
	private float beatCount;

	private bool finished = false;

	void Start() 
	{
		_processor = FindObjectOfType<AudioProcessor>();
		_processor.addAudioCallback(this);
		_beginning = System.DateTime.Now;
		Debug.Log("length" + this.Length);
	}

	void Update()
	{
		if (!finished && _beginning != null && System.DateTime.Now.Subtract(_beginning).Seconds >= Length) //detecting end of song 
		{	
			GetComponent<AudioSource>().Stop();
			FinishedSong();
		}
		//TODO Loading Bar using length
	}

	public void onOnbeatDetected() 
	{
		beatCount += 1;
		beats.Add(System.DateTime.Now);
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
    	map.beats = (System.DateTime[]) (this.beats).ToArray(typeof(System.DateTime));
    	Debug.Log("bpm" + map.bpm);
    	finished = true;

    	GameObject parent = this.transform.parent.gameObject; //parent being canvas
    	Game game = parent.GetComponent<Game>();
    	game._map = map;

    	//map.highlights = this.highlights;
    }
}