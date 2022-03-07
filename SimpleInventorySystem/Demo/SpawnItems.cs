using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public Item[] items;
    public float SpawnRate;
    private bool Cooldown;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        if (Cooldown)
            yield break;

        Cooldown = true;

        Vector3 SpawningRange = new Vector3(gameObject.transform.position.x + Random.Range(-gameObject.transform.lossyScale.x * 0.5f, gameObject.transform.lossyScale.x * 0.5f), gameObject.transform.position.y + Random.Range(-gameObject.transform.lossyScale.y * 0.5f, gameObject.transform.lossyScale.y * 0.5f), gameObject.transform.position.z + Random.Range(-gameObject.transform.lossyScale.z * 0.5f, gameObject.transform.lossyScale.z * 0.5f));

        Instantiate(items[Random.Range(0, items.Length)], SpawningRange, Quaternion.identity);

        yield return new WaitForSeconds(SpawnRate);

        Cooldown = false;
    }

}
