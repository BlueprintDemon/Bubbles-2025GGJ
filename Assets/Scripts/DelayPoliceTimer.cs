using UnityEngine;

public class DelayPoliceTimer : MonoBehaviour
{
    SceneManagerScript sceneManager;

    float cooldownTimer = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && cooldownTimer >=5)
        {
            if (sceneManager.theScore >= 5)
            {
                cooldownTimer = 0;
                sceneManager.theScore -= 5;
                sceneManager.endGameTimer += 15;
            }
            
        }
    }
}
