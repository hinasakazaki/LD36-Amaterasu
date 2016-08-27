using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
Creates an instance of an Audio Map for the music that was entered.
Audio Map will have 
**/
public class AudioMapper : MonoBehaviour, AudioProcessor.AudioCallbacks {

	private AudioProcessor processor;
	public float Length;
	
	void Start() 
	{
		processor = FindObjectOfType<AudioProcessor>();
		processor.addAudioCallback(this);
	}

	void Update()
	{

	}

	public void onOnbeatDetected() 
	{
		//do some animation whatevs
	}

	public void onSpectrum(float[] spectrum)
    {
        //The spectrum is logarithmically averaged
        //to 12 bands

        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
        }
    }
}