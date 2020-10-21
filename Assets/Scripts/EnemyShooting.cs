
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float minDelay = 1.2f;
    public float maxDelay = 1.8f;
    private float _delay;
    private float _timer;

    private void Start()
    {
        _delay = minDelay + (maxDelay - minDelay) / 2;
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _delay)
        {
            _timer = 0f;
            _delay = Random.Range(minDelay, maxDelay);
            Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }
    }
}
