using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour
{
    public float m_life = 10;
    public float m_speed = 1;
    protected float m_rotSpeed = 30;
    protected Transform m_transform;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
    }
    
    protected virtual void UpdateMove()
    {
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        m_transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") == 0)
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket != null)
            {
                m_life -= rocket.m_power;
                if(m_life <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if(other.tag.CompareTo("Player") == 0)
        {
            m_life = 0;
            Destroy(this.gameObject);
        }
    }
}
