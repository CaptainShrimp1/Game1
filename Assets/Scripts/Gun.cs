using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float reloadingTime = 1f;
    [SerializeField] private float startReloadingTime = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ReloadGun();
    }
    public void Shoot()
    {
        //yield return new WaitForSeconds(reloadingTime);

        Instantiate(bulletPrefab, firePoint.position, firePoint.transform.rotation);
        reloadingTime = startReloadingTime;
    }
    public void ReloadGun()
    {
        if (reloadingTime <= 0)
        {

            Shoot();
        }
        else
        {
            reloadingTime -= Time.deltaTime;
        }

    }

    



}

