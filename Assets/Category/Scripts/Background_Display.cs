using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background_Display : MonoBehaviour
{
    public Sprite[] Display_Map;
    int Display_Random;
    void Start()
    {
        Display_Random = Random.Range(1, 4);
        if (Display_Random == 1)
        {
            GetComponent<Image>().sprite = Display_Map[0];
        }
        if (Display_Random == 2)
        {
            GetComponent<Image>().sprite = Display_Map[1];
        }
        if (Display_Random == 3)
        {
            GetComponent<Image>().sprite = Display_Map[2];
        }
    }
}
