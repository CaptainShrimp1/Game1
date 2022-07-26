using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public float damage;

    public LayerMask solid;
    public GameObject bulletEffect;

    [SerializeField] private float movingEnemyStopTime;
    [SerializeField] private float distanceToDestroy = 12f;

    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime); // двигаем пулю вперед

        if (Vector2.Distance(player.transform.position, transform.position) > distanceToDestroy) // удаляем пулю, если далеко ушла
        {
            Destroy(gameObject);
        }


        /*RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distance, solid); // рейкаст вместо проверки коллизий
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Enemy"))
            {
                hitinfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                hitinfo.collider.GetComponent<Enemy>().TakeMovingPause(movingEnemyStopTime);
            }

            else if (hitinfo.collider.CompareTag("Environment"))
            {
                hitinfo.collider.GetComponent<DestroyEnvironment>().DestroyIt();

            }
            Instantiate(bulletEffect, transform.position, Quaternion.identity); // создаем эффект взрыва пули

            Destroy(gameObject);
        }*/
    }
}