using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    private Boolean _slowMotion;
    private Boolean collisionDetected = false;

    private float destuctionOffest = 0.5f;
    // Update is called once per frame
    void Update()
    {
        _slowMotion = Camera.main.GetComponent<Game>().slowMotion;
        if(collisionDetected)
            Destroy(gameObject);
        Vector3 pos = transform.position;
        if(IsPlayerBullet())
            pos.x += Time.deltaTime * speed * TimeModifier();
        else
            pos.x -= Time.deltaTime * speed * TimeModifier();

        float height = Camera.main.orthographicSize;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float width = height * screenRatio;
        if (pos.y - destuctionOffest > height)
            Destroy(gameObject);
        if (pos.y + destuctionOffest < -height)
            Destroy(gameObject);
        if (pos.x - destuctionOffest > width)
            Destroy(gameObject);
        if (pos.x + destuctionOffest < -width)
            Destroy(gameObject);
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionDetected = true;
    }
    
    private float TimeModifier()
    {
        if (_slowMotion){
            if (IsPlayerBullet())
                return 0.8f;
            return 0.1f;
        }
        return 1f;
    }

    private Boolean IsPlayerBullet()
    {
        return gameObject.layer == 10;
    }
}
