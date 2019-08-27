using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource GameAudio;

    public void Awake()
    {
        DontDestroyOnLoad(GameAudio);
        GameAudio.UnPause();
    }

    public void ContinueAudio()
    {
        PlayerPrefs.SetInt("audio", 1);
        GameAudio.Pause();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
