using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/Player")]
public class Player : MonoBehaviour
{
    public float m_speed = 1;  
    public Transform m_rocket;  
    public int m_life = 3;
    protected Transform m_transform;
    protected float m_rocketTimer = 0;
    public AudioClip m_shootClip;
    protected AudioSource m_audio;
    public Transform m_explosionFX;
    protected Vector3 m_targetPos;
    public LayerMask m_inputMask;

    void Start()
    {
        m_transform = this.transform;
        m_audio = this.GetComponent<AudioSource>();
        m_targetPos = this.m_transform.position;
    }
    void MoveTo()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 ms = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(ms);
            RaycastHit hitinfo;
            bool iscast = Physics.Raycast(ray, out hitinfo, 1000, m_inputMask);
            if (iscast)
            {
                m_targetPos = hitinfo.point;
            }
        }
        Vector3 pos = Vector3.MoveTowards(this.m_transform.position, m_targetPos, m_speed * Time.deltaTime);
        this.m_transform.position = pos;
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
                m_audio.PlayOneShot(m_shootClip);
            }
        }
        MoveTo(); 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") != 0)
        {
            m_life -= 1;
            GameManager.Instance.ChangeLife(m_life);
            if (m_life <= 0)
            {
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
