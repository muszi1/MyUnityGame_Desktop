using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private PlayerHealthController healthcontroller;
    // Start is called before the first frame update
    void Start()
    {
        healthcontroller=FindFirstObjectByType<PlayerHealthController>();  //SINGLETON
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) //player rigidbody-ja aktiv�lja majd a trappek ter�let�n
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController.Instance.DamagePlayer();
        }
        
    }
}
