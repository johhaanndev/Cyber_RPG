using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private SongTransferScript transferObject;
    private SongsHighScore songsHighScore;
    public GameObject songPreviewButton;

    private void Start()
    {
        transferObject = GameObject.Find("SongTransferObject").GetComponent<SongTransferScript>();
        songsHighScore = GameObject.Find("SongListObject").GetComponent<SongsHighScore>();
    }

    public void LoadSongList()
    {
        SceneManager.LoadScene("SongList");
    }

    public void LoadConfiguration()
    {
        Debug.Log("Load configuration scene");
    }

    public void LoadSocial()
    {
        Debug.Log("Load social scene");
    }

    public void LoadRanking()
    {
        Debug.Log("Load Ranking scene");
    }

    public void PlaySongPreview()
    {
        transferObject.LoadAudioSource(gameObject.name);
        Debug.Log($"Song top score: {gameObject.name} - {songsHighScore.hsDict[gameObject.name]}");
    }

    public void LoadGameplay()
    {
        transferObject.LoadAudioSource(songPreviewButton.name);
        SceneManager.LoadScene("Gameplay");

        if (transferObject.GetComponent<AudioSource>().isPlaying)
            transferObject.GetComponent<AudioSource>().Stop();

    }
}
