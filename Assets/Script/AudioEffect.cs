using UnityEngine;
using System.Collections;

public class AudioEffect : MonoBehaviour {
	private AudioSource audioData;

	void Start () { 
		audioData = GetComponent<AudioSource> ();
		audioData.Play (0);
	}

	void Update () { 
	}
}
