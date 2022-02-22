using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMusicManager : MonoBehaviour
{
    // game objects references
    public AudioSource songPlaying;
    public GameObject gameplayUI;
    public GameObject winUI;
    public Text finalScoreText;
    
    // scripts references
    public CharacterMovement characterMovement;
    public CharacterHealth characterHealth;
    public ScoreManager scoreManger;

    // paramteres
    private float songTime;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        songTime = songPlaying.clip.length;
        winUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= songTime && !characterHealth.GetIsDead())
        {
            
            if (!characterHealth.GetIsDead())
            {
                characterMovement.SetIsWin(true);
                gameplayUI.SetActive(false);

                finalScoreText.text = $"{scoreManger.GetGameplayScore()}";
                winUI.SetActive(true);
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
