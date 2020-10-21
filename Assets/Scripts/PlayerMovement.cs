using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float shipSpeed;
    public float shipRadius;
    private Boolean _slowMotion;
    
    // Update is called once per frame
    void Update()
    {
        _slowMotion = Camera.main.GetComponent<Game>().slowMotion;
        Vector3 pos = transform.position;
        pos.y += Input.GetAxis("Vertical") * Time.deltaTime * shipSpeed *TimeModifier();
        pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * shipSpeed * TimeModifier();

        float height = Camera.main.orthographicSize;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float width = height * screenRatio;
        
        if (pos.y + shipRadius > height)
            pos.y = height - shipRadius;
        if (pos.y - shipRadius < -height)
            pos.y = -height + shipRadius;
        if (pos.x + shipRadius > width)
            pos.x = width - shipRadius;
        if (pos.x - shipRadius < -width)
            pos.x = -width + shipRadius;
        
        transform.position = pos;
    }

    float TimeModifier()
    {
        if (_slowMotion)
            return 0.8f;
        return 1f;
    }
}
