using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private SongTransferScript transferObject;

    private void Start()
    {
        transferObject = GameObject.Find("SongTransferObject").GetComponent<SongTransferScript>();
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
    }
}
