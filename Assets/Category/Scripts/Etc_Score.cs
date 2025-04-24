using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Etc_Score : MonoBehaviour
{
    void Start()
    {
        if (this.name == "Score")
        {
            this.GetComponent<Text>().text = PlayerPrefs.GetInt("Score").ToString();
        }
        if (this.name == "Time")
        {
            this.GetComponent<Text>().text = PlayerPrefs.GetFloat("Time").ToString();
        }
    }
}
