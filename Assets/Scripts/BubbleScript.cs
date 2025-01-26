using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
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

    float killTimer = 0;

    [SerializeField]
    int minlimity = 125;
    [SerializeField]
    int maxlimity = 450;

    [SerializeField]
    AudioClip Pop;

    AudioSource audioSource;

    [SerializeField]
    Vector3 moveTo;

    bool timetodie = false;

    MeshRenderer meshRenderer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerScript>();
        gravityControl = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();

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
        killTimer += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveTo, 2 * Time.deltaTime);
        if (killTimer > 0.2 && timetodie) 
        {
            Destroy(gameObject);
        }

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

            audioSource.PlayOneShot(Pop);
            killTimer = 0;
            sceneManager.theScore++;
            //Destroy(gameObject); Used to be here but moved to Update so the sound can play before desctuction
            timetodie = true;
            meshRenderer.enabled = false;
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
