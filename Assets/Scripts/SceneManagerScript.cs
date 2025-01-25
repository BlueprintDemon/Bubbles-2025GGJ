using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField]
    public int theScore;

    [SerializeField]
    public float endTimer = 15;

    [SerializeField]
    public float endGameTimer = 100;

    float timer;

    [SerializeField]
    public bool understandGravity = true;

    public bool gameStart = false;

    [SerializeField]
    private TextMeshProUGUI UIscore;
    [SerializeField]
    private TextMeshProUGUI GameAlarm;
    [SerializeField]
    private TextMeshProUGUI GameTimers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        UIscore.text = "Score : " + theScore;
        if (!gameStart && SceneManager.GetActiveScene().name == "GameEnd")
        {
            UIscore = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        }
        if (!understandGravity)
        {
            timer += Time.deltaTime;

            if (timer >= endTimer)
            {
                understandGravity = true;
                timer = 0;
            }
        }

        if (gameStart)
        {
            GameAlarm.enabled = true;
            endGameTimer -= Time.deltaTime;
            GameAlarm.text = "Timer: " + endGameTimer;

            if (endGameTimer < 0)
            {
                SceneManager.LoadScene("GameEnd");
                gameStart = false;
            }

        }
    }

    
}
