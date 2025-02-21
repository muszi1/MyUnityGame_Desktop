using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance;

    private void Awake()
    {
        Instance = this;
    }





    public int currenthealth;
    public int maxhealth;
    public float invincibilityLength = 1f;
    private float invincibilityCounter;
    public SpriteRenderer theSR;
    public Color normalColor, fadeColor;

    private PlayerController thePlayer;
    void Start()
    {
        thePlayer = GetComponent<PlayerController>();
        currenthealth = maxhealth;
        UIController.instance.UpdateHealthDisplay(currenthealth,maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            if(invincibilityCounter <= 0)
            {
                theSR.color= normalColor;
            }
        }
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.H))
        {
            AddHealth(1);
        }
#endif
    }

    public void DamagePlayer()
    {
        if (invincibilityCounter <= 0)
        {

            currenthealth--;

            if (currenthealth <= 0)
            {
                currenthealth = 0;
                //gameObject.SetActive(false);

                LifeController.instance.Respawn();
            } else
            {
                invincibilityCounter = invincibilityLength;
                theSR.color = fadeColor;
                thePlayer.KnockBack();

            }

            UIController.instance.UpdateHealthDisplay(currenthealth, maxhealth); 
        }
        
    }
    public void AddHealth(int amountToAdd)
    {
        currenthealth += amountToAdd;

        if(currenthealth > maxhealth)
        {
            currenthealth = maxhealth;
        }
        UIController.instance.UpdateHealthDisplay(currenthealth, maxhealth);
    }
}
