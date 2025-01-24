using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    public int theScore;

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

            if (timer >= 15)
            {
                understandGravity = true;
                timer = 0;
            }
        }
    }

    
}
