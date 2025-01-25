using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    public int theScore;

    [SerializeField]
    public float endTimer = 15;



    float timer;

    [SerializeField]
    public bool understandGravity = true;

    [SerializeField]
    private TextMeshProUGUI UIscore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        UIscore.text = "Score : " + theScore;

        if (!understandGravity)
        {
            timer += Time.deltaTime;

            if (timer >= endTimer)
            {
                understandGravity = true;
                timer = 0;
            }
        }
    }

    
}
