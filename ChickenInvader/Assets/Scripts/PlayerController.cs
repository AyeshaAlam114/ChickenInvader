using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxRange;
    public SpawnManager spawnManager;
    public float bulletForce;

    float horizontalInput;
    public GameManager gameManager;



    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver && gameManager.gameISActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
                transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            if (transform.position.x > maxRange)
                transform.position = new Vector3(maxRange, transform.position.y, 0);
            if (transform.position.x < -maxRange)
                transform.position = new Vector3(-maxRange, transform.position.y, 0);
            if (Input.GetKeyDown(KeyCode.Space))
                spawnManager.SpawnBullet(transform.GetChild(0).transform, bulletForce);
        }
       
    }
 
    public void ScoreIncrease()
    {
        gameManager.IncreaseScore();
    }
    public void LifeDecrease()
    {
        gameManager.DecreaseLife();
    }
}
