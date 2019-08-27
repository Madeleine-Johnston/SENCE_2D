using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSFX : MonoBehaviour
{
    public AudioClip textArrive;
    public AudioClip clipArrive;
    public AudioClip ui;
    public AudioSource sfx;

    public AudioClip[] backgroundNoises;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
        StartCoroutine(audioTrigger());
    }

    IEnumerator audioTrigger()
    {
        Debug.Log("playing backgriund sfx");
        yield return new WaitForSeconds(5);
        AudioClip nextclip = backgroundNoises[Random.Range(1, backgroundNoises.Length)];
        sfx.clip = nextclip;
        sfx.Play();
        //sfx.PlayOneShot(nextclip, 1.0f);
    }

}
