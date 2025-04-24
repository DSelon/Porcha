using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etc_Point_Area : MonoBehaviour
{
    void Update()
    {
        if (this.name != "Etc_Point_Area_1_1_4")
        {
            this.transform.Translate(new Vector2(-1, 0) * 5.0f * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (this.name == "Etc_Point_Area_1_1_1")
            {
                PlayerPrefs.SetInt("Lock_1_1_2", 1);
            }
            if (this.name == "Etc_Point_Area_1_1_2")
            {
                PlayerPrefs.SetInt("Lock_1_1_3", 1);
            }
            if (this.name == "Etc_Point_Area_1_1_3")
            {
                PlayerPrefs.SetInt("Lock_1_1_4", 1);
            }
            Application.LoadLevel("Win");
        }
    }
}
