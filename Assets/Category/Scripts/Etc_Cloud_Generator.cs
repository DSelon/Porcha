using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etc_Cloud_Generator : MonoBehaviour
{
    public GameObject Cloud;
    void Start()
    {
        StartCoroutine(Cloud_Create());
    }
    IEnumerator Cloud_Create()
    {
        while (true)
        {
            Instantiate(Cloud, new Vector3(15, Random.Range(-5, 3), 1), transform.rotation);
            yield return new WaitForSeconds(Random.Range(10, 21));
        }
    }
}
