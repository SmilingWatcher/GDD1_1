using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public Boolean slowMotion;
    public float playerBulletDamage;
    public GameObject player;
    public GameObject enemy;
    public GameObject boss;
    public GameObject witchTime;

    private List<GameObject> _enemies;
    private List<Vector3> _enemyPositions;
    private List<int> _possibleEnemyPositions;
    private int _phase;
    private float _witchTimeTimer;
    private float _witchTimeSpawnTimer;
    private float _witchTimeSpawnTrigger;
    // Start is called before the first frame update
    void Start()
    {
        _enemies = new List<GameObject>();
        _enemyPositions = new List<Vector3>();
        _possibleEnemyPositions = new List<int>();
        _phase = 0;
        float height = Camera.main.orthographicSize;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float width = height * screenRatio;
        Vector3 playerInitialPosition = new Vector3(-(width /2.0f), 0.0f, 0.0f);
        Instantiate(player, playerInitialPosition, player.transform.rotation);
        int index = 0;
        for (float i = -6f; i <= 6f; i += 2)
        {
            _enemyPositions.Add(new Vector3(19f, i, 0));
            _possibleEnemyPositions.Add(index);
            index++;
        }

        _witchTimeSpawnTimer = 0;
        _witchTimeSpawnTrigger = Random.Range(15.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        _witchTimeSpawnTimer += Time.deltaTime;
        if (_witchTimeSpawnTimer >= _witchTimeSpawnTrigger)
        {
            SpawnWitchTime();
            _witchTimeSpawnTimer = 0;
            _witchTimeSpawnTrigger = Random.Range(15.0f, 20.0f);
        }
        if (slowMotion)
        {
            _witchTimeTimer += Time.deltaTime;
            if (_witchTimeTimer >= 5.0f)
            {
                slowMotion = false;
            }
        }
        if (_enemies.Count == 0)
        {
            switch (_phase)
            {
                case 0:
                    SpawnEnemy(3);
                    _phase++;
                    break;
                case 1:
                    SpawnEnemy(5);
                    _phase++;
                    break;
                case 2:
                    SpawnBoss();
                    _phase++;
                    break;
            }
        }
    }

    private void SpawnEnemy(int count)
    {
        List<int> possibleEnemyPositions = new List<int>(_possibleEnemyPositions);
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, possibleEnemyPositions.Count);
            _enemies.Add(Instantiate(enemy, _enemyPositions[possibleEnemyPositions[index]], enemy.transform.rotation));
            possibleEnemyPositions.RemoveAt(index);
        }
    }

    private void SpawnBoss()
    {
        Instantiate(boss, new Vector3(24f, 0f, 0f), boss.transform.rotation);
    }

    public void KillEnemy(GameObject corpse)
    {
        _enemies.Remove(corpse);
    }

    public void KillBoss()
    {
        //Debug.Log("WIN");
        SceneManager.LoadScene("WinScreen");
    }

    public void KillPlayer()
    {
        //Debug.Log("GAME OVER");
        SceneManager.LoadScene("LoseScreen");
    }

    public void WitchTime()
    {
        //Debug.Log("WITCH TIME");
        slowMotion = true;
        _witchTimeTimer = 0;
    }

    private void SpawnWitchTime()
    {
        Instantiate(witchTime, new Vector3(18, 0, 0), witchTime.transform.rotation);
    }
}
