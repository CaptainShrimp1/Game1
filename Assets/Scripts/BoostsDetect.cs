using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsDetect : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    private SpawbBoosts spawbBoosts;
    private DetectBullets detectBullets;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawbBoosts = GameObject.Find("GameManager").GetComponent<SpawbBoosts>();
        detectBullets = GameObject.Find("Player").GetComponent<DetectBullets>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.name == "Heart(Clone)")
            {
                gameManager.health++;
                if(gameManager.health > 10)
                {
                    gameManager.health = 10;
                }

            }
            if(gameObject.name == "Shield(Clone)")
            {
                detectBullets.Shield();
            }

            Destroy(gameObject);
        }
    }
}
