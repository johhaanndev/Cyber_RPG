using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelButtons : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadSongListScene()
    {
        SceneManager.LoadScene("SongList");
    }
}
