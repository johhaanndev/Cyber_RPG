using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMusicManager : MonoBehaviour
{
    // game objects references
    private AudioSource songPlaying;
    public GameObject gameplayUI;
    public GameObject winUI;
    public Text finalScoreText;
    
    // scripts references
    public PlayerController playerController;
    public PlayerHealth playerHealth;
    public ScoreManager scoreManger;

    // paramteres
    private float songTime;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        songPlaying = GameObject.Find("SongTransferObject").GetComponent<AudioSource>();

        songTime = songPlaying.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= songTime && !playerHealth.GetIsDead())
        {
            
            if (!playerHealth.GetIsDead() && !playerController.GetIsWin())
            {
                playerController.SetIsWin(true);
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
