using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void LoadSongList()
    {
        SceneManager.LoadScene("SongList");
    }

    public void LoadSocial()
    {
        Debug.Log("Load social scene");
    }

    public void LoadRanking()
    {
        Debug.Log("Load Ranking scene");
    }

    public void LoadConfiguration()
    {
        Debug.Log("Load configuration scene");
    }
}
