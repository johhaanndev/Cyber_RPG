using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketScript : MonoBehaviour
{
    private ScoreManager scoreManager;

    public Vector3 rotation;

    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ReboundBullet"))
        {
            scoreManager.AddPointsOnGameplay(100);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
