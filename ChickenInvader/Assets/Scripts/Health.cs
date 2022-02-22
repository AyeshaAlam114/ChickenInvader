using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int power;
 
    public void GetDamage(int damageByPower)
    {
        this.health -= damageByPower;
        if (health < 0)
            DieByHit();
    }

    void DieByHit()
    {
        if(this.CompareTag("Enemy"))
        Destroy(gameObject);
        //instantiate meat

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.CompareTag("Enemy"))
        {
            if (collision.CompareTag("Bullet"))
            {
                this.GetDamage(collision.transform.parent.gameObject.GetComponent<Health>().power);
                collision.transform.parent.GetComponent<PlayerController>().ScoreIncrease();
                collision.GetComponent<Bullet>().DestroyBullet();
            }
                
        }

        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("obstacle"))
            {
                GetDamage(collision.gameObject.GetComponent<Health>().power);
                this.GetComponent<PlayerController>().LifeDecrease();
               
            }

        }
    }

}
