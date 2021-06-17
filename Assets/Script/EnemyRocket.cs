using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/EnemyRocket")]
public class EnemyRocket : Rocket
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Player") != 0)
        {
            return;
        }
        Destroy(this.gameObject);
    }
}
