using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelButtons : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void LoadSongListScene()
    {
        SceneManager.LoadScene("SongList");
    }
}
