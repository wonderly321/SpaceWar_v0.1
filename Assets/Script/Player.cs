using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/Player")]
public class Player : MonoBehaviour
{
    public float m_speed = 1;
    protected Transform m_transform;
    public Transform m_rocket;
    protected float m_rocketTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float move_v = 0;
        float move_h = 0;

        if (Input.GetKey(KeyCode.W))
        {
            move_v -= m_speed * Time.deltaTime;
        }
            
        if (Input.GetKey(KeyCode.S))
        {
            move_v += m_speed * Time.deltaTime;
        }
            
        
        if (Input.GetKey(KeyCode.A))
        {
            move_h += m_speed * Time.deltaTime;
        }
            

        if (Input.GetKey(KeyCode.D)) 
        {
            move_h -= m_speed * Time.deltaTime;
        }
        m_transform.Translate(new Vector3(move_h, 0, move_v));

        m_rocketTimer -= Time.deltaTime;
        if(m_rocketTimer < 0){
            m_rocketTimer = 0.1f;
            if(Input.GetKey(KeyCode.Space))
            {
                Instantiate(m_rocket, m_transform.position, m_transform.rotation);
            }
        } 
 
        
    }
}
