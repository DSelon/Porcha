using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Fireball : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(new Vector2(-1, 0) * 5.0f * Time.deltaTime);
    }
}