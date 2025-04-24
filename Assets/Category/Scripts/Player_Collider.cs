using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collider : MonoBehaviour
{
    public Sprite[] List_Death;
    public AudioClip Damage;
    float Health = 150;
    void Start()
    {
        StartCoroutine(Death());
        PlayerPrefs.SetFloat("Health", Health / 150);
        PlayerPrefs.SetInt("Score", 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Projectile_Fireball_Big")
        {
            Health -= 30;
            Destroy(other.gameObject);
        }
        if (other.name == "Projectile_Fireball_Normal")
        {
            Health -= 10;
            Destroy(other.gameObject);
        }
        if (other.name == "Projectile_Fireball_Small")
        {
            Health -= 5;
            Destroy(other.gameObject);
        }
        if (other.name == "Razer_Charging")
        {
            Health -= 50;
        }
        if (other.name == "Razer_Fire")
        {
            Health -= 50;
        }
        if (other.name == "Enemy_Bird_Near")
        {
            Health -= 10;
        }
        if (other.name == "Enemy_Bird_Distance")
        {
            Health -= 10;
        }
        if (other.name == "Whale")
        {
            Health -= 100;
        }
        if (other.name != "Virtual_Wall" && other.name != "Etc_Point_Area_1_1_1" && other.name != "Etc_Point_Area_1_1_2" && other.name != "Etc_Point_Area_1_1_3")
        {
            GetComponent<AudioSource>().PlayOneShot(Damage, 1.0f);
            PlayerPrefs.SetFloat("Health", Health / 150);
        }
    }
    IEnumerator Death()
    {
        while (true)
        {
            if (Health <= 0)
            {
                transform.parent.GetChild(1).gameObject.SetActive(false);
                transform.parent.GetChild(2).gameObject.SetActive(false);
                transform.parent.GetChild(3).gameObject.SetActive(false);
                GameObject.DestroyImmediate(this.gameObject.GetComponent<BoxCollider2D>());
                GetComponent<Transform>().localScale = new Vector2(0.1f, 0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[0];
                yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[1];
                yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[2];
                yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[3];
                yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[2];
                yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[3];
                yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[4];
                yield return new WaitForSeconds(0.1f);
                GetComponent<Transform>().localScale = new Vector2(0, 0);
                yield return new WaitForSeconds(0.5f);
                PlayerPrefs.Save();
                Application.LoadLevel("Defeat");
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}