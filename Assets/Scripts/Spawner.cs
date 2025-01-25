using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject TheBubbles;

    Vector3 ranndomPlacementVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 550; i++)
        {
            int newx = Random.Range(-255, 255);
            int newy = Random.Range(30, 140);
            int newz = Random.Range(-300, 300);
            ranndomPlacementVector = new Vector3(newx, newy, newz);
            Instantiate(TheBubbles, ranndomPlacementVector, Quaternion.identity);
            Debug.Log("Printing Bubble");
        }
        Instantiate(TheBubbles, ranndomPlacementVector, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {


    }
}
