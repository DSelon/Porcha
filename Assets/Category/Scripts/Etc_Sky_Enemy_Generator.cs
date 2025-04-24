using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etc_Sky_Enemy_Generator : MonoBehaviour
{
    public GameObject Enemy_Bird_Distance;
    public GameObject Enemy_Bird_Near;
    public GameObject Enemy_Whale;
    public bool Whether_Boss = false;
    bool Whether_Pattern = false;
    void Start()
    {
        StartCoroutine(Generate_Enemy_Bird_Distance());
        StartCoroutine(Generate_Enemy_Bird_Near());
        StartCoroutine(Generate_Enemy_Whale());
        StartCoroutine(Pattern_1());
        StartCoroutine(Pattern_2());
        StartCoroutine(Pattern_3());
        StartCoroutine(Pattern_4());
    }
    IEnumerator Generate_Enemy_Bird_Distance()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2));
            if (!Whether_Boss)
            {
                Instantiate(Enemy_Bird_Distance, new Vector3(Random.Range(15, 17), Random.Range(-4.5f, 4.6f), -1), transform.rotation);
            }
        }
    }
    IEnumerator Generate_Enemy_Bird_Near()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 1.0f));
            Instantiate(Enemy_Bird_Near, new Vector3(Random.Range(15, 17), Random.Range(-4.5f, 4.6f), -1), transform.rotation);
        }
    }
    IEnumerator Generate_Enemy_Whale()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(60, 120));
            if (!Whether_Boss)
            {
                Whether_Boss = true;
                Instantiate(Enemy_Whale, new Vector3(30, 0, 0), transform.rotation);
            }
        }
    }
    IEnumerator Pattern_1()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 15));
            if (!Whether_Pattern)
            {
                Whether_Pattern = true;
                Instantiate(Enemy_Bird_Near, new Vector3(15, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(15, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(15, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(15, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(15, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(19, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(19, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(19, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(19, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(19, -2, -1), transform.rotation);
                yield return new WaitForSeconds(5.0f);
                Whether_Pattern = false;
            }
        }
    }
    IEnumerator Pattern_2()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 15));
            if (!Whether_Pattern && !Whether_Boss)
            {
                Whether_Pattern = true;
                Instantiate(Enemy_Bird_Distance, new Vector3(15, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(15, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(15, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(15, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(15, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, -2, -1), transform.rotation);
                yield return new WaitForSeconds(5.0f);
                Whether_Pattern = false;
            }
        }
    }
    IEnumerator Pattern_3()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 15));
            if (!Whether_Pattern && !Whether_Boss)
            {
                Whether_Pattern = true;
                Instantiate(Enemy_Bird_Distance, new Vector3(15, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(16, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(17, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(18, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(19, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(15, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(16, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(17, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(18, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(19, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(15, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(16, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(17, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(18, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(19, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(15, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(19, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(15, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(19, -2, -1), transform.rotation);
                yield return new WaitForSeconds(5.0f);
                Whether_Pattern = false;
            }
        }
    }
    IEnumerator Pattern_4()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 15));
            if (!Whether_Pattern && !Whether_Boss)
            {
                Whether_Pattern = true;
                Instantiate(Enemy_Bird_Near, new Vector3(15, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(19, 0, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(15, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(19, 1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(15, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(16, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(17, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(18, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Near, new Vector3(19, -1, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(15, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(16, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(17, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(18, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(19, 2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(15, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(16, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(17, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(18, -2, -1), transform.rotation);
                Instantiate(Enemy_Bird_Distance, new Vector3(19, -2, -1), transform.rotation);
                yield return new WaitForSeconds(5.0f);
                Whether_Pattern = false;
            }
        }
    }
}
