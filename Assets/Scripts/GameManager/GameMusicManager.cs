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
    public CharacterManager characterManager;
    public CharacterHealth characterHealth;
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
        if (timer >= songTime && !characterHealth.GetIsDead())
        {
            
            if (!characterHealth.GetIsDead() && !characterManager.GetIsWin())
            {
                characterManager.SetIsWin(true);
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
