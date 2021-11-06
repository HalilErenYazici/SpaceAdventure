using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipController2D : MonoBehaviour
{
    public GameObject bullet, particleSys, gameOverScreen;
    public Transform firePoint0, firePoint1, firePoint2;
    public Image powerBar, hpBar;
    public AudioSource itemCollect, destroySound, hitSound, fireSound;
    public float movementSpeedH, movemenetSpeedV, waitTime;
    public bool oneShoot, doubleShoot, tripleShoot;
    // Start is called before the first frame update
    void Start()
    {
        oneShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
       float horizontal = Input.GetAxis("Horizontal");
       //float vertical = Input.GetAxis("Vertical");

        powerBar.fillAmount -= 1.0f / waitTime * Time.deltaTime;

        transform.Translate(transform.right * horizontal * movementSpeedH * Time.deltaTime);
        //transform.Translate(transform.up * vertical * movemenetSpeedV * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            fireSound.Play();
            if(oneShoot)
            {
                Instantiate(bullet, firePoint0.transform.position, firePoint0.transform.rotation);
            }
            if(doubleShoot)
            {
                Instantiate(bullet, firePoint1.transform.position, firePoint1.transform.rotation);
                Instantiate(bullet, firePoint2.transform.position, firePoint2.transform.rotation);
            }
            if(tripleShoot)
            {
                Instantiate(bullet, firePoint0.transform.position, firePoint0.transform.rotation);
                Instantiate(bullet, firePoint1.transform.position, firePoint1.transform.rotation);
                Instantiate(bullet, firePoint2.transform.position, firePoint2.transform.rotation);
            }
        }

        if(powerBar.fillAmount==0)
        {
            oneShoot = true;
            doubleShoot = false;
            tripleShoot = false;
        }
        if(hpBar.fillAmount<=0)
        {
            destroySound.Play();
            Instantiate(particleSys, transform.position, transform.rotation);
            gameOverScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("doubleShoot"))
        {
            powerBar.fillAmount = 1;
            itemCollect.Play();
            doubleShoot = true;
            oneShoot = false;
            tripleShoot = false;
            
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("tripleShoot"))
        {
            powerBar.fillAmount = 1;
            itemCollect.Play();
            tripleShoot = true;
            oneShoot = false;
            doubleShoot = false;

            Destroy(collision.gameObject);

        }
        if(collision.gameObject.CompareTag("enemyBullet"))
        {
            hpBar.fillAmount -= 0.1f;
            hitSound.Play();
            Destroy(collision.gameObject);
        }
    }
}
