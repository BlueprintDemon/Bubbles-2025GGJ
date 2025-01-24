using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableFloating : MonoBehaviour
{
    SceneManager sceneManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
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
            Debug.Log("FiredButton");
        }
    }
}
