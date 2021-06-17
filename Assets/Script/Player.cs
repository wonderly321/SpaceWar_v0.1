using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/player")]
public class Player : MonoBehaviour
{
    public float m_speed = 1;
    public Transform m_transform;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float move_v = 0;
        float move_h = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("1111111111111111");
            move_v += m_speed * Time.deltaTime;
        }
            
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("22222222222");
            move_v -= m_speed * Time.deltaTime;
        }
            
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("3333333333333333333333");
            move_h += m_speed * Time.deltaTime;
        }
            

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            Debug.Log("44444444444444");
            move_h -= m_speed * Time.deltaTime;
        }
            

        this.m_transform.Translate(new Vector3(move_h, 0, move_v));
        
    }
}
