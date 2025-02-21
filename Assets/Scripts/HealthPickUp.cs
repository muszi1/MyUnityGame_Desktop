using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    //azzal, hogy kitoroltem a start es az update fv-t minimális processt time-t nyerek hisz a unity akkor is meghivja ezeket fv-ket ha uresek.


    public int healthToAdd;
    public GameObject pickupEffect;
    public bool giveFullHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerHealthController.Instance.currenthealth != PlayerHealthController.Instance.maxhealth)
            {
                if (giveFullHealth == true)
                {
                    PlayerHealthController.Instance.AddHealth(PlayerHealthController.Instance.maxhealth);
                }
                else
                {
                    PlayerHealthController.Instance.AddHealth(healthToAdd);
                }
                

                Destroy(gameObject);
                Instantiate(pickupEffect,transform.position,transform.rotation);
            }
            
        }
    }
}
