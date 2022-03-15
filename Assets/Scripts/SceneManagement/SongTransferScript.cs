using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongTransferScript : MonoBehaviour
{
    public string songName;
    public AudioClip trackSelected;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "SongList")
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadAudioSource(string songName)
    {
        trackSelected = Resources.Load($"Songs/{songName}") as AudioClip;
        GetComponent<AudioSource>().clip = trackSelected;
        GetComponent<AudioSource>().Play();
    }

    public void SetSongName(string name)
    {
        songName = name;
    }
}
