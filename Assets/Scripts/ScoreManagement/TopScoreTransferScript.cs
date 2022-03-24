using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopScoreTransferScript : MonoBehaviour
{
    private float finalScore = 0.0f;
    private string songName;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("SongList"))
        {
            var songToSendScore = GameObject.Find("SongListObject");
            songToSendScore.GetComponent<SongsHighScore>().SetHighScoreToSong(songName, finalScore);
            Destroy(gameObject);
        }
        else
        {
            songName = GameObject.Find("MusicPlayer").GetComponent<AudioSource>().clip.name;
        }
    }

    public void SetFinalScore(float score, string songToSend)
    {
        songName = songToSend;
        finalScore = score;
    }
}
