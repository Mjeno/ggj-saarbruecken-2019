using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{

	AudioSource asMusic;
	public AudioClip acFinalStage;
	bool bMusicSet;

	void Start() {
		asMusic = this.GetComponent<AudioSource>();
		bMusicSet = false;
	}

	void Update() {
		if(Time.timeSinceLevelLoad > 80 && !bMusicSet) {
			asMusic.Stop();
			asMusic.clip = acFinalStage;
			bMusicSet = true;
			asMusic.Play();
			asMusic.loop = true;
		}
	}
}