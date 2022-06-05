using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [SerializeField] float spawnInterval = 1;

    [SerializeField] private ObjectPooling objectPool = null;

    void Start()
    {
        StartCoroutine(nameof(SpawnRoutine));
    }

    public void SetSpawnInterval(float val)
    {
        spawnInterval = val;
    }

    private IEnumerator SpawnRoutine()
    {
        int counter = 0;
        while (true)
        {
            GameObject obj = objectPool.GetPooledObject(counter++ % 2);

            obj.transform.localPosition = Vector3.zero;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
