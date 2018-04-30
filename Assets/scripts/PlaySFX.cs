using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour {

	private AudioSource playSfx;
	// Use this for initialization
	void Start () {
		playSfx = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	public void Play () {
		playSfx.Play();
	}
}
