using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePointDetect : MonoBehaviour
{

    private GameManager gameManager;
    private SpawnPointsCircle spawnPointsCircle;
    public float scorePower = 0.1f;
    public float howLongLive = 10;
    private float circleCircle;

    public int value;

    private SpriteRenderer spriteRenderer;
    

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnPointsCircle = GameObject.Find("GameManager").GetComponent<SpawnPointsCircle>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
        
        StartCoroutine(Die());
    }

    private void Update()
    {
        if (circleCircle <=1)
        {
            circleCircle += Time.deltaTime * 0.3f;
        }
        spriteRenderer.color = new Color(1, 1, 1, circleCircle);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && circleCircle >= 0.9f)
        {
            gameManager.score += scorePower*value;
        }
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(howLongLive);
        spawnPointsCircle.howMuchCirclesOnTheScreen--;
        Destroy(gameObject);
    }
}
