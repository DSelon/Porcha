using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etc_Stage : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Lock_1_1_1", 1);
        for (int repeat_Area = 1; repeat_Area < 4; repeat_Area++)
        {
            for (int repeat_Map = 1; repeat_Map < 4; repeat_Map++)
            {
                for (int repeat_Level = 1; repeat_Level < 5; repeat_Level++)
                {
                    if (PlayerPrefs.GetInt("Lock_" + repeat_Area.ToString() + "_" + repeat_Map.ToString() + "_" + repeat_Level.ToString()) == 1)
                    {
                        GameObject.Find("Button_Area" + repeat_Area.ToString()).transform.Find("Lock").gameObject.SetActive(false);
                        GameObject.Find("Button_Area" + repeat_Area.ToString()).transform.Find("Button_Map" + repeat_Map.ToString()).transform.Find("Room_StageMod_Area" + repeat_Area.ToString() + "_Map" + repeat_Map.ToString() + "_Level" + repeat_Level.ToString()).transform.Find("Lock").gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
