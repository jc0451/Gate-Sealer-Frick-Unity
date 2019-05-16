using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizedsounds : MonoBehaviour {

    public AudioClip[] sounds;
    private AudioSource audioSource;
    public float time = 0.5f;
    public float elapsed;

    void Start () {
        elapsed = time;
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
	}
	private AudioClip getRandomClip()
    {
        return sounds[Random.Range(0, sounds.Length)];
    }


    void Update () {
		if (!audioSource.isPlaying)
        {
            audioSource.clip = getRandomClip();
            audioSource.Play();
            
        }

        elapsed -= Time.deltaTime;
        if (elapsed <= 0.0f)
        {
            elapsed = time;
            gameObject.gameObject.SetActive(false);

        }
    }
}
