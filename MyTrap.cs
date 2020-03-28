using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrap : MonoBehaviour
{
    [SerializeField] private int _damageHealth = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<MFS>();
            player.Hurt(_damageHealth);
        }
    }
}
