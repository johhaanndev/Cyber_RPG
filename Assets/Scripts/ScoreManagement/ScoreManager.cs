using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public CharacterMovement character;
    public CharacterHealth characterHealth;

    private float gameplayScore;
    private int currentSpawn;
    private int nextSpawn;

    public Transform[] basketSpawns;
    public GameObject basketPrefab;
    public Text gameplayScoreText;
    public Text finalScoreText;

    //Start is called before the first frame update
    void Start()
    {
        currentSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!character.GetIsWin() && !characterHealth.GetIsDead())
            gameplayScore += Time.deltaTime * 10;
        UpdateGameplayScore();
    }

    private void UpdateGameplayScore()
    {
        if (gameplayScore < 10)
            gameplayScoreText.text = $"Score: 0000{(int)gameplayScore}";
        else if (gameplayScore < 100)
            gameplayScoreText.text = $"Score: 000{(int)gameplayScore}";
        else if (gameplayScore < 1000)
            gameplayScoreText.text = $"Score: 00{(int)gameplayScore}";
        else if (gameplayScore < 10000)
            gameplayScoreText.text = $"Score: 0{(int)gameplayScore}";
        else if (gameplayScore < 100000)
            gameplayScoreText.text = $"Score: {(int)gameplayScore}";
    }

    public void AddPointsOnGameplay(int score)
    {
        gameplayScore += score;
        nextSpawn = Random.Range(0, basketSpawns.Length);
        while (nextSpawn == currentSpawn)
        {
            nextSpawn = Random.Range(0, basketSpawns.Length);
        }

        var basket = (GameObject)Instantiate(basketPrefab, basketSpawns[nextSpawn].position, basketSpawns[nextSpawn].rotation);
        currentSpawn = nextSpawn;
    }

    public int GetGameplayScore()
    {
        return (int)gameplayScore;
    }
}
