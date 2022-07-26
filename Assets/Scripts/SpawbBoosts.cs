using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawbBoosts : MonoBehaviour
{
    public int howMuchBoostsOnTheScreen = 0;
    public int maxBoostsOnTheScreen = 3;

    public GameObject[] BoostsPrefabs;

    public float reloadingSpawn = 1.7f;

    private void Start()
    {
        StartCoroutine(SpawnHelper());
    }


    public IEnumerator SpawnHelper()
    {
        yield return new WaitForSeconds(reloadingSpawn);


        if (howMuchBoostsOnTheScreen < maxBoostsOnTheScreen)
        {
            Instantiate(BoostsPrefabs[Random.Range(0, BoostsPrefabs.Length)], new Vector2 (Random.Range(-6,6), Random.Range(-6,6)), Quaternion.identity);
            howMuchBoostsOnTheScreen++;
            StartCoroutine(SpawnHelper());
        }
        else
        {
            StartCoroutine(SpawnHelper());
        }

    }
}
