using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Razer_Charging : MonoBehaviour
{
    public GameObject Razer;
    public Sprite[] Razer_Charging_List;
    void Start()
    {
        StartCoroutine(Razer_Charging());
    }
    IEnumerator Razer_Charging()
    {
        for (int Calculation = 0; Calculation < 10; Calculation++)
        {
            if (GameObject.Find("Enemy_Whale").GetComponent<Enemy_Whale>().Whale_Live == true)
            {
                GetComponent<SpriteRenderer>().sprite = Razer_Charging_List[Calculation];
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                break;
            }
        }
        if (GameObject.Find("Enemy_Whale").GetComponent<Enemy_Whale>().Whale_Live == true)
        {
            Instantiate(Razer, transform.position, transform.rotation);
        }
        yield return new WaitForSeconds(1.0f);
        this.gameObject.SetActive(false);
    }
}
