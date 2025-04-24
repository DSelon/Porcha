using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Cloud : MonoBehaviour
{
	public Sprite[] Cloud_Kinds;
	int Cloud_Kind_Random;
    float Cloud_Speed;
    void Start()
    {
        Cloud_Kind_Random = Random.Range(1, 6);
        if (Cloud_Kind_Random == 1)
        {
            GetComponent<SpriteRenderer>().sprite = Cloud_Kinds[0];
        }
        if (Cloud_Kind_Random == 2)
        {
            GetComponent<SpriteRenderer>().sprite = Cloud_Kinds[1];
        }
        if (Cloud_Kind_Random == 3)
        {
            GetComponent<SpriteRenderer>().sprite = Cloud_Kinds[2];
        }
        if (Cloud_Kind_Random == 4)
        {
            GetComponent<SpriteRenderer>().sprite = Cloud_Kinds[3];
        }
        if (Cloud_Kind_Random == 5)
        {
            GetComponent<SpriteRenderer>().sprite = Cloud_Kinds[4];
        }
        Cloud_Speed = Random.Range(0.05f, 0.15f);
    }
    void Update()
    {
        transform.Translate(new Vector2(-1, 0) * Cloud_Speed * Time.deltaTime);
    }
}
