using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maxBoundary;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxBoundary)
            DestroyBullet();
        if (transform.position.y <- maxBoundary )
            DestroyBullet();
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //       // collision.GetComponent<EnemyHealth>().DecreaseHealth();
    //        Destroy(gameObject);
    //    }
    //}
}
