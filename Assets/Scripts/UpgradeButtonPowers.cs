using TMPro;
using UnityEngine;

public class UpgradeButtonPowers : MonoBehaviour
{
    SceneManagerScript sceneManager;

    [SerializeField]
    private TextMeshProUGUI AddedTime;


    float cooldownTimer = 5;
    float timer;
    float msgTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddedTime.enabled = false;
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        msgTimer += Time.deltaTime;
        cooldownTimer += Time.deltaTime;

        if (msgTimer > 3)
        {
            AddedTime.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && cooldownTimer >= 10)
        {
            if (sceneManager.theScore >= 5)
            {
                cooldownTimer = 0;
                msgTimer = 0;
                AddedTime.enabled=true;
                sceneManager.theScore -= 5;
                sceneManager.endTimer += 10;
            }
        }
    }
}
