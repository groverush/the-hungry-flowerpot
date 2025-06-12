using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementEnemyAndFruits : MonoBehaviour
{
    Rigidbody rigidbody;
    public SpawnManager spawnManager;
    private bool leftWall, rightWall, frontWall;
 
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedRandom = Random.Range(spawnManager.speedMin, spawnManager.speedMax);

        if (leftWall)
        {
            rigidbody.velocity = new Vector3(speedRandom, 0, 0);
        } 

        if (rightWall)
        {
            rigidbody.velocity = new Vector3(-speedRandom, 0, 0);
        }

        if (frontWall)
        {
            rigidbody.velocity = new Vector3(0, 0, -speedRandom);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LeftWall")
        {
            leftWall = true; rightWall = false; frontWall = false;
            //Debug.Log(leftWall);
        }

        if (other.gameObject.tag == "RightWall")
        {
            leftWall = false; rightWall = true; frontWall = false;
        }

        if (other.gameObject.tag == "FrontWall")
        {
            leftWall = false; rightWall = false; frontWall = true;
        }

        if(other.gameObject.tag == "RightWall" && leftWall)
        {
            Destroy(this.gameObject);
            Debug.Log("derecha");
        }

        if (other.gameObject.tag == "LeftWall" && rightWall)
        {
            Destroy(this.gameObject);
            Debug.Log("izquierda");
        }
    }
}
