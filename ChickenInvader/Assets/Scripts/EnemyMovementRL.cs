using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRL : MonoBehaviour
{
    public float speed;
    public float maxRange;

    bool right;
    bool left;
    // Start is called before the first frame update
    void Start()
    {
        right = true;
        left = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            if (right)
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (left)
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (GetMaxPoint() > maxRange)
            {
                right = false;
                left = true;
            }
            if (GetMinPoint() < -maxRange)
            {
                left = false;
                right = true;
            }
        }
       
    }
    float GetMaxPoint()
    {
        if (this.transform.childCount == 1)
            return this.transform.GetChild(0).position.x;
        Bounds bounds = new Bounds(this.transform.GetChild(0).position, Vector3.zero);
        for (int i = 0; i < this.transform.childCount; i++)
            bounds.Encapsulate(this.transform.GetChild(i).position);
        return bounds.max.x;
    }
    float GetMinPoint()
    {
        if (this.transform.childCount == 1)
            return this.transform.GetChild(0).position.x;
        Bounds bounds = new Bounds(this.transform.GetChild(0).position, Vector3.zero);
        for (int i = 0; i < this.transform.childCount; i++)
            bounds.Encapsulate(this.transform.GetChild(i).position);
        return bounds.min.x;
    }
}
