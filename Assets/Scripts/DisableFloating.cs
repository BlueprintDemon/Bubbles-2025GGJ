using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableFloating : MonoBehaviour
{
    SceneManagerScript sceneManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TouchedButton");
        if(other.gameObject.name == "Player")
        {
            sceneManager.understandGravity = false;
            sceneManager.gameStart = true;
            Debug.Log("FiredButton");
        }
    }
}
