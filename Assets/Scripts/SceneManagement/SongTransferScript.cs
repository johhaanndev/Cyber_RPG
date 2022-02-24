using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongTransferScript : MonoBehaviour
{
    public string songName;
    public AudioClip trackSelected;

    public void LoadAudioSource(string songName)
    {
        Debug.Log(songName);
        trackSelected = Resources.Load($"Songs/{songName}") as AudioClip;
        GetComponent<AudioSource>().clip = trackSelected;
        GetComponent<AudioSource>().Play();
    }

    public void SetSongName(string name)
    {
        songName = name;
    }
}
