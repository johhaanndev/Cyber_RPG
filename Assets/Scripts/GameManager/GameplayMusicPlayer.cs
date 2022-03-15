using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMusicPlayer : MonoBehaviour
{
    private AudioSource musicPlayer;
    private GameObject songTransferred;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        songTransferred = GameObject.Find("SongTransferObject");
        LoadAndPlayMusic();
    }

    public void LoadAndPlayMusic()
    {
        musicPlayer.clip = songTransferred.GetComponent<AudioSource>().clip;
        musicPlayer.Play();
    }
}
