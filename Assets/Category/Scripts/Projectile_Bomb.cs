using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Bomb : MonoBehaviour
{
    public Sprite[] List_Explosion;
    public AudioClip Sound_Explosion;
    float Speed = 7.5f;
    void Start()
    {
        StartCoroutine(Explosion());
    }
    void Update()
    {
        this.transform.Translate(new Vector2(1, 0) * Speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Virtual_Wall")
        {
            Speed = 0;
        }
    }
    IEnumerator Explosion()
    {
        while (true)
        {
            if (Speed == 0)
            {
                this.name = "Explosion";
                GetComponent<AudioSource>().PlayOneShot(Sound_Explosion, 1.0f);
                GetComponent<Transform>().localScale = new Vector2(0.1f, 0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Explosion[0];
                yield return new WaitForSeconds(0.1f);
                GetComponent<Transform>().localScale = new Vector2(0.3f, 0.3f);
                GetComponent<SpriteRenderer>().sprite = List_Explosion[1];
                yield return new WaitForSeconds(0.1f);
                GetComponent<Transform>().localScale = new Vector2(0.5f, 0.5f);
                GetComponent<SpriteRenderer>().sprite = List_Explosion[2];
                yield return new WaitForSeconds(0.1f);
                GetComponent<Transform>().localScale = new Vector2(0.3f, 0.3f);
                GetComponent<SpriteRenderer>().sprite = List_Explosion[1];
                yield return new WaitForSeconds(0.1f);
                GetComponent<Transform>().localScale = new Vector2(0.5f, 0.5f);
                GetComponent<SpriteRenderer>().sprite = List_Explosion[2];
                yield return new WaitForSeconds(0.1f);
                GetComponent<Transform>().localScale = new Vector2(0.3f, 0.3f);
                GetComponent<SpriteRenderer>().sprite = List_Explosion[1];
                yield return new WaitForSeconds(0.1f);
                GetComponent<Transform>().localScale = new Vector2(0.1f, 0.1f);
                GetComponent<SpriteRenderer>().sprite = List_Explosion[0];
                yield return new WaitForSeconds(0.1f);
                GetComponent<Transform>().localScale = new Vector2(0, 0);
                yield return new WaitForSeconds(1.0f);
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
