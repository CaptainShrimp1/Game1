using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsCircle : MonoBehaviour
{
    public int howMuchCirclesOnTheScreen = 0;
    public int maxCirclesOnTheScreen = 3;

    public GameObject[] CirclePrefabs;

    public Vector2[] randomPositions;
    public float maxValuePosition = 4;

    public float reloadingSpawn = 1.7f;

    private void Start()
    {
        StartCoroutine(SpawnHelper());
    }


    public IEnumerator SpawnHelper()
    {
        yield return new WaitForSeconds(reloadingSpawn);


        if (howMuchCirclesOnTheScreen < maxCirclesOnTheScreen)
        {
            Instantiate(CirclePrefabs[Random.Range(0,CirclePrefabs.Length)], randomPositions[Random.Range(0,24)], Quaternion.identity);
            howMuchCirclesOnTheScreen++;
            StartCoroutine(SpawnHelper());
        }
        else
        {
            StartCoroutine(SpawnHelper());
        }

    }
}
