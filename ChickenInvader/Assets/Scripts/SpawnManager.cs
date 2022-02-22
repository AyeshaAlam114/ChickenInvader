using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    Rigidbody2D bullet;

    public GameObject player;
    public GameObject enemyHolder;
    public GameObject[] enemyPrefab;
    public int totalWaves;
    public int waveCounter = 0;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (enemyHolder.transform.childCount == 0 /*&& waveCounter < totalWaves */&& !gameManager.gameOver)
        {
            if (waveCounter >= totalWaves)
                gameManager.GameOver();
            else
            {
                gameManager.NotifyNextWave(waveCounter);
                if (gameManager.spawnEnemiesNow)
                {
                    gameManager.SetSpawnEnemynabler(false);
                    SpawnWave();
                    
                }
            }

        }




    }
    void SpawnWave()
    {
        if (!gameManager.gameOver && gameManager.gameISActive)
        {
            if (enemyHolder.transform.childCount == 0)
            {
                if (waveCounter < totalWaves)
                {
                    SpawnEnemies();
                }
            }
        }
    }
    void SpawnEnemies()
    {

        this.GetComponent<EnemyGridView>().ResetSpawnPosition();
        this.GetComponent<EnemyGridView>().Initializer(Random.Range(1, 4), Random.Range(3, 6), enemyPrefab[Random.Range(0, enemyPrefab.Length)]);
        waveCounter++;

    }

    public void SpawnBullet(Transform bulletSpawnPosition, float bulletForce)
    {
        GameObject bulletObj = Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity, player.transform);            //spawn bullet and save it's rigidbody component in bullet
        bulletObj.transform.localScale = bulletSpawnPosition.transform.localScale;
        bullet = bulletObj.GetComponent<Rigidbody2D>();
        bullet.AddForce(Vector3.up * Time.deltaTime * bulletForce, ForceMode2D.Impulse);                               // apply force in up direction
    }


}

