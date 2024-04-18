using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource[] sources;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlaySoundAdd()
    {
        sources[0].Play();
    }

    void PlaySoundTen()
    {
        sources[1].Play();
    }
}
