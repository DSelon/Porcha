using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etc_Remove_Zone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.name == "Remove_Zone_Left")
        {
            Destroy(other.gameObject);
        }
        if (this.name == "Remove_Zone_Right")
        {
            if (other.name == "Projectile_Bullet")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
