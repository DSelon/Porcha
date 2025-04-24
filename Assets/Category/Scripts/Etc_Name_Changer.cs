using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etc_Name_Changer : MonoBehaviour
{
    void Start()
    {
        for (int k = 1; k < 500; k++)
        {
            if (GameObject.Find("Enemy_Bird_Distance (" + k + ")"))
            {
                if (GameObject.Find("Enemy_Bird_Distance (" + k + ")").name == "Enemy_Bird_Distance (" + k.ToString() + ")")
                {
                    GameObject.Find("Enemy_Bird_Distance (" + k + ")").name = "Enemy_Bird_Distance";
                }
            }
            if (GameObject.Find("Enemy_Bird_Near (" + k + ")"))
            {
                if (GameObject.Find("Enemy_Bird_Near (" + k + ")").name == "Enemy_Bird_Near (" + k.ToString() + ")")
                {
                    GameObject.Find("Enemy_Bird_Near (" + k + ")").name = "Enemy_Bird_Near";
                }
            }
        }
    }
    void Update()
    {
        if (GameObject.Find("Background_Cloud(Clone)"))
        {
            GameObject.Find("Background_Cloud(Clone)").name = "Background_Cloud";
        }
        if (GameObject.Find("Enemy_Bird_Distance(Clone)"))
        {
            GameObject.Find("Enemy_Bird_Distance(Clone)").name = "Enemy_Bird_Distance";
        }
        if (GameObject.Find("Enemy_Bird_Near(Clone)"))
        {
            GameObject.Find("Enemy_Bird_Near(Clone)").name = "Enemy_Bird_Near";
        }
        if (GameObject.Find("Enemy_Whale(Clone)"))
        {
            GameObject.Find("Enemy_Whale(Clone)").name = "Enemy_Whale";
        }
        if (GameObject.Find("Projectile_Bullet(Clone)"))
        {
            GameObject.Find("Projectile_Bullet(Clone)").name = "Projectile_Bullet";
        }
        if (GameObject.Find("Projectile_Fireball_Big(Clone)"))
        {
            GameObject.Find("Projectile_Fireball_Big(Clone)").name = "Projectile_Fireball_Big";
        }
        if (GameObject.Find("Projectile_Fireball_Normal(Clone)"))
        {
            GameObject.Find("Projectile_Fireball_Normal(Clone)").name = "Projectile_Fireball_Normal";
        }
        if (GameObject.Find("Projectile_Fireball_Small(Clone)"))
        {
            GameObject.Find("Projectile_Fireball_Small(Clone)").name = "Projectile_Fireball_Small";
        }
        if (GameObject.Find("Razer_Charging(Clone)"))
        {
            GameObject.Find("Razer_Charging(Clone)").name = "Razer_Charging";
        }
    }
}
