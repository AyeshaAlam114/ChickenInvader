using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    Button button;
    public void DestroyBullet()
    {
        Destroy(gameObject);
        button.onClick.AddListener(DestroyBullet);
    }

   

}
