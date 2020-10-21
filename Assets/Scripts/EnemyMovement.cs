using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    public float shipSpeed;
    private Boolean _slowMotion;
    private float _targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        _targetPosition = Random.Range(12f, 14.5f);
    }

    // Update is called once per frame
    void Update()
    {
        _slowMotion = Camera.main.GetComponent<Game>().slowMotion;
        Vector3 pos = transform.position;
        if (pos.x >= _targetPosition)
        {
            pos.x -= Time.deltaTime * shipSpeed * TimeModifier();
            transform.position = pos;
        }
    }

    float TimeModifier()
    {
        if (_slowMotion)
            return 0.1f;
        return 1f;
    }
}
