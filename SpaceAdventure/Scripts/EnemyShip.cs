using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameManager gameManager;
    int randomSayi;
    public float number1, number2;
    public GameObject bullet, power0, power1, particleEffect, artiYuz, destroySound;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", number1, number2);
    }

    // Update is called once per frame
    void Update()
    {
        randomSayi = Random.Range(0,20);
    }
    void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(particleEffect, transform.position, transform.rotation);
            Instantiate(artiYuz, transform.position, artiYuz.transform.rotation);
            Instantiate(destroySound, transform.position, transform.rotation);

            if(randomSayi==0)
            {
                Instantiate(power0, transform.position, transform.rotation);
            }if(randomSayi==1)
            {
                Instantiate(power1, transform.position, transform.rotation);
            }
            gameManager.sayi++;
            gameManager.score += 100;
        }
    }
}
