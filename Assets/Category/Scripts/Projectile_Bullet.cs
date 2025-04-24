using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Bullet : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(new Vector2(1, 0) * 10.0f * Time.deltaTime);
    }
}
