using TMPro;
using UnityEngine;

public class UpgradeButtonPowers : MonoBehaviour
{
    SceneManager sceneManager;

    [SerializeField]
    private TextMeshProUGUI AddedTime;

    float timer;
    float msgTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddedTime.enabled = false;
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        msgTimer += Time.deltaTime;

        if (msgTimer > 3)
        {
            AddedTime.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (sceneManager.theScore >= 5)
            {
                msgTimer = 0;
                AddedTime.enabled=true;
                sceneManager.theScore -= 5;
                sceneManager.endTimer += 10;
            }
        }
    }
}
