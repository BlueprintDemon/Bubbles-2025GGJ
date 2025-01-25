using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BubbleScript : MonoBehaviour
{
    SceneManagerScript sceneManager;

    [SerializeField]
    SphereCollider SphereCollider;

    Rigidbody gravityControl;

    bool gravity;
    bool floating;
    bool moving;

    [SerializeField]
    int minlimity = 125;
    [SerializeField]
    int maxlimity = 450;


    [SerializeField]
    Vector3 moveTo;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerScript>();
        gravityControl = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        gravity = sceneManager.understandGravity;
        
        if (!moving) 
        {
            MovementRandom();
        }
        if (gravity && moving)
        {
            MakeBalloonFloat();
        }
        if (transform.position == moveTo)
        {
            moving = false;
        }
        if (!gravity)
        {
            gravityControl.useGravity = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, moveTo, 2 * Time.deltaTime);

    }

    private void MovementRandom()
    {
        
        int newx = Random.Range(-255, 255);
        int newy = Random.Range(minlimity, maxlimity);
        int newz = Random.Range(-300, 300);
        
        moveTo = new Vector3(newx, newy, newz);
        moving = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            sceneManager.theScore++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) //used for testing i g n o r e
    {
        if (other.name == "Player")
        {
            sceneManager.theScore++;
            Destroy(gameObject);
        }
    }
    

    private void MakeBalloonFloat()
    {
        gravityControl.useGravity = false;
    }
}
