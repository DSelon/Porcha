using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird_Distance : MonoBehaviour
{
    public Sprite[] List_Move;
    public Sprite[] List_Stop;
    public Sprite[] List_Death;
    public GameObject Fireball_Small;
    public AudioClip Sound_Death;
    float Speed = 5.0f;
    int Health = 5;
    int Number_Move;
    int Number_Stop;
    void Start()
    {
        Number_Move = 0;
        Number_Stop = 0;
        StartCoroutine(Animation());
        StartCoroutine(Fire());
        StartCoroutine(Death());
    }
    void Update()
    {
        this.transform.Translate(new Vector2(-1, 0) * Speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Virtual_Wall")
        {
            Speed = 0;
        }
        if (other.name == "Player")
        {
            Health -= 5;
        }
        if (other.name == "Projectile_Bullet")
        {
            Health -= 1;
            Destroy(other.gameObject);
        }
        if (other.name == "Explosion")
        {
            Health -= 5;
        }
    }
    IEnumerator Animation()
    {
        while (true)
        {
            if (Speed != 0)
            {
                Number_Move += 1;
                if (Number_Move == 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Move[0];
                    yield return new WaitForSeconds(0.1f);
                }
                if (Number_Move == 2)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Move[1];
                    yield return new WaitForSeconds(0.1f);
                }
                if (Number_Move == 3)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Move[2];
                    yield return new WaitForSeconds(0.1f);
                }
                if (Number_Move == 4)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Move[3];
                    yield return new WaitForSeconds(0.1f);
                }
                if (Number_Move == 5)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Move[2];
                    yield return new WaitForSeconds(0.1f);
                }
                if (Number_Move == 6)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Move[1];
                    yield return new WaitForSeconds(0.1f);
                    Number_Move = 0;
                }
            }
            if (Speed == 0)
            {
                Number_Stop += 1;
                if (Number_Stop == 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Stop[0];
                    yield return new WaitForSeconds(0.1f);
                }
                if (Number_Stop == 2)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Stop[1];
                    yield return new WaitForSeconds(0.1f);
                }
                if (Number_Stop == 3)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Stop[2];
                    yield return new WaitForSeconds(0.1f);
                }
                if (Number_Stop == 4)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Stop[3];
                    yield return new WaitForSeconds(0.1f);
                }
                if (Number_Stop == 5)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Stop[2];
                    yield return new WaitForSeconds(0.1f);
                }
                if (Number_Stop == 6)
                {
                    this.GetComponent<SpriteRenderer>().sprite = List_Stop[1];
                    yield return new WaitForSeconds(0.1f);
                    Number_Stop = 0;
                }
            }
        }
    }
    IEnumerator Fire()
    {
        while (true)
        {
            if (Speed == 0)
            {
                if (Health > 0)
                {
                    Instantiate(Fireball_Small, transform.position + new Vector3(-1.8f, -0.2f, 0), transform.rotation);
                }
            }
            yield return new WaitForSeconds(Random.Range(1.0f, 6));
        }
    }
    IEnumerator Death()
    {
        while (true)
        {
            if (Health <= 0)
            {
                GetComponent<AudioSource>().PlayOneShot(Sound_Death, 0.5f);
                GameObject.Find("Etc_User_Interface").GetComponent<Etc_User_Interface>().Score += 1;
                GameObject.DestroyImmediate(this.gameObject.GetComponent<BoxCollider2D>());
                Speed = 0;
                GetComponent<Transform>().localScale = new Vector2(0.05f, 0.05f);
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
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
