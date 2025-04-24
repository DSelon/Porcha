using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Whale : MonoBehaviour
{
    public Sprite[] Whale_List;
    public Sprite[] List_Death;
    public GameObject Fireball_Normal;
    public GameObject Fireball_Big;
    public GameObject Razer_Charging;
    public AudioClip Sound_Death;
    public bool Whale_Live = true;
    float Whale_Speed = 5.0f;
    int Whale_Number;
    int Whale_Random;
    int Whale_Whether;
    int Health = 500;
    void Start()
    {
        StartCoroutine(Death());
    }
    void Update()
    {
        this.transform.Translate(new Vector2(-1, 0) * Whale_Speed * Time.deltaTime);
        if (this.GetComponent<Transform>().position.x <= 5.1f)
        {
            Whale_Speed = 0;
            if (Whale_Whether == 0)
            {
                Whale_Whether = 1;
                StartCoroutine(Whale_Attack());
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Health -= 10;
        }
        if (other.name == "Projectile_Bullet")
        {
            Health -= 1;
            Destroy(other.gameObject);
        }
        if (other.name == "Explosion")
        {
            Health -= 100;
        }
    }
    IEnumerator Whale_Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            Whale_Random = Random.Range(1, 4);
            if (Whale_Random == 1)
            {
                for (int Calculation = 0; Calculation <= 5; Calculation++)
                {
                    if (Whale_Live == true)
                    {
                        GetComponent<SpriteRenderer>().sprite = Whale_List[Calculation];
                        yield return new WaitForSeconds(0.1f);
                    }
                    else
                    {
                        break;
                    }
                }
                for (int Calculation = 0; Calculation < 30; Calculation++)
                {
                    if (Whale_Live == true)
                    {
                        Instantiate(Fireball_Normal, transform.position + new Vector3(-1.3f, -2.7f, 0), Quaternion.Euler(0, 0, Random.Range(-45, 46)));
                        yield return new WaitForSeconds(0.3f);
                    }
                    else
                    {
                        break;
                    }
                }
                for (int Calculation = 5; Calculation >= 0; Calculation--)
                {
                    if (Whale_Live == true)
                    {
                        GetComponent<SpriteRenderer>().sprite = Whale_List[Calculation];
                        yield return new WaitForSeconds(0.1f);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (Whale_Random == 2)
            {
                for (int Calculation = 0; Calculation <= 5; Calculation++)
                {
                    if (Whale_Live == true)
                    {
                        GetComponent<SpriteRenderer>().sprite = Whale_List[Calculation];
                        yield return new WaitForSeconds(0.1f);
                    }
                    else
                    {
                        break;
                    }
                }
                if (Whale_Live == true)
                {
                    Instantiate(Razer_Charging, transform.position + new Vector3(-1.5f, -2.7f, 0), transform.rotation);
                    yield return new WaitForSeconds(4.0f);
                }
                else
                {
                    break;
                }
                for (int Calculation = 5; Calculation >= 0; Calculation--)
                {
                    if (Whale_Live == true)
                    {
                        GetComponent<SpriteRenderer>().sprite = Whale_List[Calculation];
                        yield return new WaitForSeconds(0.1f);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (Whale_Random == 3)
            {
                for (int Calculation = 0; Calculation <= 5; Calculation++)
                {
                    if (Whale_Live == true)
                    {
                        GetComponent<SpriteRenderer>().sprite = Whale_List[Calculation];
                        yield return new WaitForSeconds(0.1f);
                    }
                    else
                    {
                        break;
                    }
                }
                for (int Calculation = 5; Calculation > 0; Calculation--)
                {
                    if (Whale_Live == true)
                    {
                        Instantiate(Fireball_Big, transform.position + new Vector3(-1.3f, -2.7f, 0), Quaternion.Euler(0, 0, Random.Range(-30, 31)));
                        yield return new WaitForSeconds(1.0f);
                    }
                    else
                    {
                        break;
                    }
                }
                for (int Calculation = 5; Calculation >= 0; Calculation--)
                {
                    if (Whale_Live == true)
                    {
                        GetComponent<SpriteRenderer>().sprite = Whale_List[Calculation];
                        yield return new WaitForSeconds(0.1f);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
    IEnumerator Death()
    {
        while (true)
        {
            if (Health <= 0)
            {
                Whale_Live = false;
                GetComponent<AudioSource>().PlayOneShot(Sound_Death, 1.0f);
                GameObject.Find("Etc_User_Interface").GetComponent<Etc_User_Interface>().Score += 30;
                GameObject.DestroyImmediate(this.gameObject.GetComponent<BoxCollider2D>());
                GetComponent<Transform>().localScale = new Vector2(0.6f, 0.6f);
                GetComponent<SpriteRenderer>().sprite = List_Death[0]; yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[1]; yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[2]; yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[3]; yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[2]; yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[3]; yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Death[4]; yield return new WaitForSeconds(0.1f);
                GetComponent<Transform>().localScale = new Vector2(0, 0);
                yield return new WaitForSeconds(3.0f);
                if (GameObject.Find("Etc_Point_Area_1_1_4"))
                {
                    PlayerPrefs.SetInt("Lock_1_2_1", 1);
                    Application.LoadLevel("Win");
                }
                if (!GameObject.Find("Etc_Point_Area_1_1_4"))
                {
                    GameObject.Find("Etc_Sky_Enemy_Generator").GetComponent<Etc_Sky_Enemy_Generator>().Whether_Boss = false;
                    Destroy(this.gameObject);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
