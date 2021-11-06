using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMesh scoreText;
    public GameObject winScreen;
    public int vurulmasiGerekenDusmanSayisi, sayi, score, activeScene;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("score", score);
        if(sayi == vurulmasiGerekenDusmanSayisi)
        {
            winScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
