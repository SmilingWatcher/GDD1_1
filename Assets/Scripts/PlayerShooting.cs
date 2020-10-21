using System.Collections;
using System.Collections.Generic;
using System.Timers;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float fireDelay = 0.25f;
    private float cooldownTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            // Debug.Log("Pew");
            cooldownTimer = fireDelay;
            Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }
    }
}
