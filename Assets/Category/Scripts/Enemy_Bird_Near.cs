using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird_Near : MonoBehaviour
{
    public Sprite[] List_Death;
    public AudioClip Sound_Death;
    float Rotation;
    float Rotation_X;
    float Rotation_Y;
    float Speed = 5.0f;
    int Health = 3;
    Vector2 Direction = new Vector2(-1, 0);
    void Start()
    {
        StartCoroutine(Death());
    }
    void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Virtual_Wall")
        {
            Rotation_X = GameObject.Find("Player").GetComponent<Transform>().position.x - this.GetComponent<Transform>().position.x;
            Rotation_Y = GameObject.Find("Player").GetComponent<Transform>().position.y - this.GetComponent<Transform>().position.y;
            Rotation = Mathf.Atan(Rotation_Y / Rotation_X) * (360 / (2 * Mathf.PI));
            this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Rotation);
            Speed = 10.0f;
        }
        if (other.name == "Player")
        {
            Health -= 3;
        }
        if (other.name == "Projectile_Bullet")
        {
            Health -= 1;
            Destroy(other.gameObject);
        }
        if (other.name == "Explosion")
        {
            Health -= 3;
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
