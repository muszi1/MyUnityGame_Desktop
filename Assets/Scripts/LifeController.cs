using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public static LifeController instance;
    private void Awake()
    {
        instance = this;
    }
    private PlayerController thePlayer;

    public float RespawnDelay = 2f;

    public int currentLives = 3;

    public GameObject deathEffect, RespawnEffect;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindFirstObjectByType<PlayerController>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn()
    {
        // thePlayer.transform.position = FindFirstObjectByType<CheckpointManager>().respawnPosition;

        // PlayerHealthController.Instance.AddHealth(PlayerHealthController.Instance.maxhealth);

        thePlayer.gameObject.SetActive(false);
        thePlayer.theRB.velocity = Vector2.zero;

        currentLives--;

        if(currentLives > 0)
        {
            StartCoroutine(RespanwCo());
        }
        else
        {
            currentLives = 0;
            StartCoroutine(GameOverCo());
        }

        UpdateUI();
        

        Instantiate(deathEffect, thePlayer.transform.position, deathEffect.transform.rotation);

        
    }
    public IEnumerator RespanwCo()
    {
        yield return new WaitForSeconds(RespawnDelay);

        thePlayer.transform.position = FindFirstObjectByType<CheckpointManager>().respawnPosition;

        PlayerHealthController.Instance.AddHealth(PlayerHealthController.Instance.maxhealth);
        thePlayer.gameObject.SetActive(true);

        Instantiate(RespawnEffect, thePlayer.transform.position, RespawnEffect.transform.rotation);
    }
    public IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(RespawnDelay);

        if(UIController.instance != null)
        {
            UIController.instance.ShowGameOver();
        }
    }

    public void AddLife()
    {
        currentLives++;
        UpdateUI();

    }

    public void UpdateUI() //tul sok helyen hasznaltam az if elegazast es a perfomance es a SOLID alapelvek miatt celszerubbnek talaltam function-t csinalni
    {
        if (UIController.instance != null)
        {
            UIController.instance.UpdateLivesDisplay(currentLives);
        }
    }
}
