using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Razer_Fire : MonoBehaviour
{
    float Razer_Rotation;
    float Razer_Rotation_X;
    float Razer_Rotation_Y;
    Vector2 Razer_Direction = new Vector2(-1, 0);
    public AudioClip Fire;
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(Razer_Fire());
    }
    IEnumerator Razer_Fire()
    {
        Razer_Rotation_X = GameObject.Find("Player").GetComponent<Transform>().position.x - this.GetComponent<Transform>().position.x;
        Razer_Rotation_Y = GameObject.Find("Player").GetComponent<Transform>().position.y - this.GetComponent<Transform>().position.y;
        Razer_Rotation = Mathf.Atan(Razer_Rotation_Y / Razer_Rotation_X) * (360 / (2 * Mathf.PI));
        this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Razer_Rotation);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Razer_Active());
    }
    IEnumerator Razer_Active()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(Fire, 1.0f);
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = new Vector2(0.15f, 0.13f); yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = new Vector2(0.15f, 0.115f); yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = new Vector2(0.15f, 0.1f); yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = new Vector2(0.15f, 0.085f); yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = new Vector2(0.15f, 0.07f); yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = new Vector2(0.15f, 0.055f); yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = new Vector2(0.15f, 0.04f); yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = new Vector2(0.15f, 0.025f); yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = new Vector2(0.15f, 0.01f); yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
