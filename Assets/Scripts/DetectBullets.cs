using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBullets : MonoBehaviour
{
    private GameManager gameManager;

    public bool canBeAttacken = true;
    public float shieldReloading = 5;

    [SerializeField] private GameObject shieldImage;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            if (canBeAttacken)
            {
                Destroy(other.gameObject);
                gameManager.health--;
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
    public void Shield()
    {
        StartCoroutine(ShieldCourutine());
    }
    private IEnumerator ShieldCourutine()
    {
        canBeAttacken = false;
        shieldImage.SetActive(true);
        yield return new WaitForSeconds(shieldReloading);
        canBeAttacken = true;
        shieldImage.SetActive(false);

    }
}
