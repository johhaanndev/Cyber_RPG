using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    private int currentHealth;

    private bool isDead = false;

    public Text healthText;
    public GameObject loseUI;
    public GameObject controlsUI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BasicBullet"))
        {
            Debug.Log("Bullet hit");
            if (!isDead)
            {
                SubstractOne();
                UpdateHealthText();
            }
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = $"Health: {currentHealth}";
    }

    private void SubstractOne()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            isDead = true;
            loseUI.SetActive(true);
            controlsUI.SetActive(false);
        }
    }

    public bool GetIsDead() => isDead;
}
