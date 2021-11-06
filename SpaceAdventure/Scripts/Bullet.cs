using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool enemyBullet, bullet;
    void Update()
    {
        if(bullet)
        {
            transform.Translate(transform.up * 10 * Time.deltaTime);
        }
        if(enemyBullet)
        {
            transform.Translate(Vector2.down * 7.5f * Time.deltaTime);
        }
        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Boss")&&bullet)
        {
            Destroy(gameObject);
        }
    }
}
