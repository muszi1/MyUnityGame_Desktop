using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    private void Awake()
    {
        instance = this;
    }
    public Image[] heartIcons;
    public Sprite heartfull, heartEmpty;

    public TMP_Text livesText,collectiblesText;

    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthDisplay(int health, int maxHealth)
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].enabled = true;

            if (health > i)
            {
                heartIcons[i].sprite = heartfull;
            }
            else
            {
                heartIcons[i].sprite = heartEmpty;

                if (maxHealth <=i)
                {
                    heartIcons[i].enabled = false;
                }

            }
        }
    }
    public void UpdateLivesDisplay(int currentLives)
    {
        livesText.text= currentLives.ToString();
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateCollectibles(int amount)
    {
        collectiblesText.text = amount.ToString();
    }
}
