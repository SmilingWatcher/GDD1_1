using System;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    public float speed;
    private Boolean collisionDetected = false;

    private float destuctionOffest = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if(collisionDetected)
            Destroy(gameObject);
        Vector3 pos = transform.position;
        pos.x -= Time.deltaTime * speed;
        pos.y = (float)Math.Sin(pos.x / 2.0f) * 5.0f;

        float height = Camera.main.orthographicSize;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float width = height * screenRatio;
        if (pos.y - destuctionOffest > height)
            Destroy(gameObject);
        if (pos.y + destuctionOffest < -height)
            Destroy(gameObject);
        if (pos.x + destuctionOffest < -width)
            Destroy(gameObject);
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionDetected = true;
    }

}
