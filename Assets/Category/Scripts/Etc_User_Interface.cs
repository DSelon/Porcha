using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Etc_User_Interface : MonoBehaviour
{
    float Health = 1;
    float Gauge = 1;
    float Bomb_Cool = 0;
    float Type_Cool = 0;
    float Time_ = 0;
    public int Score = 0;
    void Start()
    {
        PlayerPrefs.SetFloat("Health", Health);
        PlayerPrefs.SetFloat("Gauge", Gauge);
        PlayerPrefs.SetFloat("Bomb_Cool", Bomb_Cool);
        PlayerPrefs.SetFloat("Type_Cool", Type_Cool);
    }
    void Update()
    {
        Time_ += Time.deltaTime;
        PlayerPrefs.SetFloat("Time", Time_);
        PlayerPrefs.SetInt("Score", Score);
        GameObject.Find("Health").gameObject.GetComponent<Image>().fillAmount = PlayerPrefs.GetFloat("Health");
        GameObject.Find("Gauge").gameObject.GetComponent<Image>().fillAmount = PlayerPrefs.GetFloat("Gauge");
        if (true)
        {
            GameObject.Find("Bomb_Icon").transform.Find("Bomb_CoolTime").gameObject.GetComponent<Image>().fillAmount = PlayerPrefs.GetFloat("Bomb_Cool");
            GameObject.Find("Type_Icon").transform.Find("Type_CoolTime").gameObject.GetComponent<Image>().fillAmount = PlayerPrefs.GetFloat("Type_Cool");
        }
        if (SystemInfo.deviceType.ToString() == "Handheld")
        {
            GameObject.Find("JoyStick_Button_Bomb").transform.Find("Bomb_CoolTime").gameObject.GetComponent<Image>().fillAmount = PlayerPrefs.GetFloat("Bomb_Cool");
            GameObject.Find("JoyStick_Button_Type").transform.Find("Type_CoolTime").gameObject.GetComponent<Image>().fillAmount = PlayerPrefs.GetFloat("Type_Cool");
        }
        GameObject.Find("Time_Text").gameObject.GetComponent<Text>().text = PlayerPrefs.GetFloat("Time").ToString();
        GameObject.Find("Score_Text").gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("Score").ToString();
    }
}
