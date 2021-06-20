using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu("MyGame/GameManager")]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform m_canvas_main;
    public Transform m_canvas_gameover;
    public Text m_text_score;
    public Text m_text_best;
    public Text m_text_life;

    protected int m_score = 0;
    public static int m_histcore = 0;
    protected Player m_player;

    public AudioClip m_musicClip;
    protected AudioSource m_Audio;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        m_Audio = this.gameObject.AddComponent<AudioSource>();
        m_Audio.clip = m_musicClip;
        m_Audio.Play();

        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        m_text_score = m_canvas_main.transform.Find("Text_score").GetComponent<Text>();
        m_text_best = m_canvas_main.transform.Find("Text_best").GetComponent<Text>();
        m_text_life = m_canvas_main.transform.Find("Text_life").GetComponent<Text>();

        m_text_score.text = string.Format("Score: {0}", m_score);
        m_text_best.text = string.Format("Best Score: {0}", m_histcore);
        m_text_life.text = string.Format("Life: {0}", m_player.m_life);

        var restart_button = m_canvas_gameover.transform.Find("Button_restart").GetComponent<Button>();
        restart_button.onClick.AddListener(delegate()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        m_canvas_gameover.gameObject.SetActive(false);
    }
    public void AddScore(int point)
    {
        m_score += point;
        if(m_histcore < m_score)
        {
            m_histcore = m_score;
        }
        m_text_score.text = string.Format("Score: {0}", m_score);
        m_text_best.text = string.Format("Best Score: {0}", m_histcore);
    }

    // Update is called once per frame
    public void ChangeLife(int life)
    {
        m_text_life.text = string.Format("Life: {0}", life);
        if(life <= 0)
        {
            m_canvas_gameover.gameObject.SetActive(true);
        }
    }
}
