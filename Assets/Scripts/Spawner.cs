using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script represnts the spawning food on the screen.

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Collider spawnArea;

    [SerializeField]
    public GameObject[] foodPrefabs;

    [SerializeField]
    private float minSpawnDelay = 0.25f;

    [SerializeField]
    private float maxSpawnDelay = 1f;

    [SerializeField]
    private float minAngle = 10f;

    [SerializeField]
    private float maxAngle = 15f;

    [SerializeField]
    private float minForce = 18f;

    [SerializeField]
    private float maxForce = 22f;

    [SerializeField]
    private float maxLifetime = 5f;

    //unity calls it when script is initalized
    private void Start()
    {
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            GameObject prefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];

            Vector3 postion = new Vector3();
            postion.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x); // picking random value from the collider bounds
            postion.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            postion.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);
            //Quaternion rotation = prefab.transform.rotation;
            //Vector3 scale = prefab.transform.localScale;

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, minAngle));
            GameObject food = Instantiate(prefab, postion, rotation);
            // food.transform.localScale = scale;

            Destroy(food, maxLifetime);

            float force = Random.Range(minForce, maxForce);
            food.GetComponent<Rigidbody>().AddForce(food.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
}
