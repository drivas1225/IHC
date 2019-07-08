using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class cube : MonoBehaviour
{
    

    //usefull variables to destroy effects on cubes
    float cubeSize = 0.2f;
    int cubesInRow = 2;
    float cubesPivotDistance;
    Vector3 cubesPivot;
    float explosionForce = 50.0f;
    float explosionRadius = 2.0f;
    float explosionUpward = 0.8f;
    float time = 0.0f;
    float time2;
    //AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //to create pivot vector
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        //aud = GetComponent<AudioSource>();
        //Debug.Log(aud.name);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            destroyObjects("piece");
            time = 0.0f;
        }
        //time2 += Time.deltaTime;
        //if (time > 3)
        //{
        //    //Destroy(gameObject);
        //    GameObject.Find("Mul").GetComponent<TextMesh>().text = "1";
        //}
        string s = FindObjectOfType<AudioManager>().GetClipName("music");
        if (s == "TheFatRat - Unity")
        {
            transform.position += Time.deltaTime * transform.forward * 20;
        }
        else if(s == "Undertale - Megalovania")
        {
            transform.position += Time.deltaTime * transform.forward * 40;
        }
        else
        {
            transform.position += Time.deltaTime * transform.forward * 30;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("auidaaaaaaaaaa!!!!!!!");
        //if (col.gameObject.name == "Wall")
        //{
        //    Destroy(gameObject);
        //    GameObject.Find("Mul").GetComponent<TextMesh>().text = "1";
        //}
    }
    void explode()
    {
        //createPiece(1,1,1);
        //3 neested loops to create cubes 5*5*5 in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z)
    {
        GameObject piece;

        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.gameObject.tag = "piece";
        piece.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1); //black color

        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);


        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

        //Time.timeScale = 0; //para poner en pausa el juego
        //time = 2.0f;

    }

    void destroyObjects(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }
    }

    void OnDestroy()
    {
        explode();
        //Instantiate( GetComponentInParent<spawner>().explotion, gameObject.transform);
    }
}
