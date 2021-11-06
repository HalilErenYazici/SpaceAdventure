using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject particleEffect, destroySound, bossMusic, winMusic, artiOnBin;
    public Image hp;
    public Transform boomPoint0, boomPoint1, boomPoint2;
    public AudioSource hitSound;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp.fillAmount <= 0)
        {
            bossMusic.SetActive(false);
            winMusic.SetActive(true);
            Destroy(gameObject);
            Instantiate(particleEffect, boomPoint0.transform.position, boomPoint0.transform.rotation);
            Instantiate(particleEffect, boomPoint1.transform.position, boomPoint1.transform.rotation);
            Instantiate(particleEffect, boomPoint2.transform.position, boomPoint2.transform.rotation);
            Instantiate(artiOnBin, boomPoint2.transform.position, artiOnBin.transform.rotation);
            Instantiate(destroySound, transform.position, transform.rotation);
            gameManager.sayi++;
            gameManager.score += 10000;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            hp.fillAmount -= 0.025f;
            hitSound.Play();
        }
    }
}
