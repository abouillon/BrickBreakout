using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBrick : MonoBehaviour
{
    private string[] brickPrefabs = {"Maverick", "Prince", "Scoob"};

    public void beginBrickSpawn(Vector3 coords)
    {
        StartCoroutine(SpawningBrick(coords));
    }

    IEnumerator SpawningBrick(Vector3 location)
    {
        int prefab = Random.Range(0, 3);
        yield return new WaitForSeconds(5f);
        GameObject newBrick = (GameObject)Instantiate(Resources.Load("Prefabs/" + brickPrefabs[prefab]));
        newBrick.transform.position = location;

    }
}
