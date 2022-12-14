using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHealth : MonoBehaviour
{
    [SerializeField] private float takeDamage;
    [SerializeField] private AudioSource damageEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(takeDamage);
            damageEffect.Play();
        }
    }
}
