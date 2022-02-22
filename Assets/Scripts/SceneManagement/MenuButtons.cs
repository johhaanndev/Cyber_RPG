using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private string directory;
    private string songFolder;

    private void Start()
    {
        directory = $"{Application.streamingAssetsPath}/Songs/";
        songFolder = $"";
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
        Debug.Log($"Song: {gameObject.name}");
    }
}
