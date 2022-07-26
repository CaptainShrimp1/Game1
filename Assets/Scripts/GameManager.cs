using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float score;
    public Text scoreText;

    public int health;
    public Text healthText;

    public GameObject helloMenu;
    public GameObject deadMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Mathf.Round(score).ToString() + " score";
        healthText.text = health.ToString() + " HP";

        if (health <=0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        helloMenu.SetActive(false);
        deadMenu.SetActive(false);
    }
}
