using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmer1Prefab;
    [SerializeField]
    private GameObject swarmer2Prefab;

    [SerializeField]
    private float swarmer1Interval = 3.5f;
    [SerializeField]
    private float swarmer2Interval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmer1Interval,swarmer1Prefab));
        StartCoroutine(spawnEnemy(swarmer2Interval,swarmer2Prefab));
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f,5),Random.Range(-6f,6),0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval,enemy));
    }
}
