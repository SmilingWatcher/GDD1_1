using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float health;
    private float _playerBulletDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Damage: " + CalculateDamage(other));
        health -= CalculateDamage(other);
    }

    float CalculateDamage(Collider2D other)
    {
        float ret = 0f;
        int collisionWith = other.gameObject.layer;
        // Debug.Log(collisionWith);
        switch (collisionWith)
        {
            // PlayerShip
            case 8:
                // instant death for enemy
                ret = health;
                break;
            // EnemyShip
            case 9:
                ret = 30f;
                break;
            // PlayerBullet
            case 10:
                ret = _playerBulletDamage;
                break;
            // EnemyBullet
            case 11:
                ret = 10f;
                break;
            // WitchTime
            case 13:
                Camera.main.GetComponent<Game>().WitchTime();
                break;
        }
        return ret;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerBulletDamage = Camera.main.GetComponent<Game>().playerBulletDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Die();
    }

    void Die()
    {
        if(gameObject.layer == 8)
            Camera.main.GetComponent<Game>().KillPlayer();
        if(gameObject.layer == 9)
            Camera.main.GetComponent<Game>().KillEnemy(gameObject);
        if(gameObject.layer == 12)
            Camera.main.GetComponent<Game>().KillBoss();
        Destroy(gameObject);
    }
}
