using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etc_Button_Click : MonoBehaviour
{
    float Area_Position;
    float Map_Position;
    float Arrow_Big_Position;
    Vector2 Arrow_Big_Direction;
    float Arrow_Small_Position;
    Vector2 Arrow_Small_Direction;
    int ChallengeMod_Map;
    public AudioClip Sound_Effect_1;
    public AudioClip Sound_Effect_2;
    public AudioClip Sound_Effect_3;

    public void SceneLoad_Stage()
    {
        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(Sound_Effect_1, 1.0f);
        Application.LoadLevel("Menu_Stage");
    }

    public void SceneLoad_Challenge()
    {
        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(Sound_Effect_1, 1.0f);
        ChallengeMod_Map = Random.Range(1, 2);
        if (ChallengeMod_Map == 1)
        {
            Application.LoadLevel("Room_ChallengeMod_Sky");
        }
        if (ChallengeMod_Map == 2)
        {
            Application.LoadLevel("Room_ChallengeMod_Underwater");
        }
        if (ChallengeMod_Map == 3)
        {
            Application.LoadLevel("Room_ChallengeMod_Space");
        }
    }

    public void Game_Exit()
    {
        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(Sound_Effect_3, 1.0f);
        Application.Quit();
    }

    public void SceneLoad_Main()
    {
        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(Sound_Effect_1, 1.0f);
        Application.LoadLevel("Menu_Main");
    }

    public void SceneLoad_Developers()
    {
        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(Sound_Effect_1, 1.0f);
        Application.LoadLevel("Menu_Developers");
    }

    public void Rendering_Number_Area()
    {
        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(Sound_Effect_2, 1.0f);
        GameObject.Find("Arrow_Small").transform.Translate(new Vector2(0, GameObject.Find("Button_Area1").transform.Find("Button_Map1").gameObject.transform.position.y - GameObject.Find("Arrow_Small").gameObject.transform.position.y));
        GameObject.Find("Button_Area1").transform.Find("Button_Map1").SetSiblingIndex(2);
        GameObject.Find("Button_Area1").transform.Find("Button_Map2").SetSiblingIndex(1);
        GameObject.Find("Button_Area1").transform.Find("Button_Map3").SetSiblingIndex(0);
        GameObject.Find("Button_Area2").transform.Find("Button_Map1").SetSiblingIndex(2);
        GameObject.Find("Button_Area2").transform.Find("Button_Map2").SetSiblingIndex(1);
        GameObject.Find("Button_Area2").transform.Find("Button_Map3").SetSiblingIndex(0);
        GameObject.Find("Button_Area3").transform.Find("Button_Map1").SetSiblingIndex(2);
        GameObject.Find("Button_Area3").transform.Find("Button_Map2").SetSiblingIndex(1);
        GameObject.Find("Button_Area3").transform.Find("Button_Map3").SetSiblingIndex(0);
        this.transform.SetSiblingIndex(8);
        Area_Position = this.gameObject.transform.position.y;
        Arrow_Big_Position = GameObject.Find("Arrow_Big").gameObject.transform.position.y;
        Arrow_Big_Direction = new Vector2(0, this.gameObject.transform.position.y - GameObject.Find("Arrow_Big").gameObject.transform.position.y);
        GameObject.Find("Arrow_Big").transform.Translate(Arrow_Big_Direction * 1.0f);
    }

    public void Rendering_Number_Map()
    {
        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(Sound_Effect_2, 1.0f);
        this.transform.SetSiblingIndex(2);
        Map_Position = this.gameObject.transform.position.y;
        Arrow_Small_Position = GameObject.Find("Arrow_Small").gameObject.transform.position.y;
        Arrow_Small_Direction = new Vector2(0, this.gameObject.transform.position.y - GameObject.Find("Arrow_Small").gameObject.transform.position.y);
        GameObject.Find("Arrow_Small").transform.Translate(Arrow_Small_Direction * 1.0f);
    }

    public void SceneLoad_Level()
    {
        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(Sound_Effect_1, 1.0f);
        if (this.transform.Find("Lock").gameObject.activeSelf == false)
        {
            Application.LoadLevel(this.name);
        }
    }

    public void Refresh()
    {
        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(Sound_Effect_3, 1.0f);
        PlayerPrefs.DeleteAll();
    }

    public void Callback()
    {
        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(Sound_Effect_3, 1.0f);
        PlayerPrefs.SetInt("Lock_1_1_1", 1);
        PlayerPrefs.SetInt("Lock_1_1_2", 1);
        PlayerPrefs.SetInt("Lock_1_1_3", 1);
        PlayerPrefs.SetInt("Lock_1_1_4", 1);
    }
}
