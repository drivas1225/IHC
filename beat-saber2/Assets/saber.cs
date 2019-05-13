using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;

    //usefull variables to destroy effects on cubes
    float cubeSize = 0.2f;
    int cubesInRow = 2;
    float cubesPivotDistance;
    Vector3 cubesPivot;
    float explosionForce = 50.0f;
    float explosionRadius = 2.0f;
    float explosionUpward = 0.8f;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //to create pivot vector
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.name == "BLUE(Clone)" || col.gameObject.name == "RED(Clone)")
    //    {
    //        Destroy(col.gameObject);
    //    }
    //}

        // Update is called once per frame
        void Update()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            destroyObjects("piece");
            Debug.Log("objetos destrozados!!");
            time = 0.0f;
        }
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward*100, Color.green);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100, layer))
        {
            //Debug.DrawRay(transform.position, transform.forward*100, Color.red);
            print("Hit");  
            //if( Vector3.Angle(transform.position-previousPos,hit.transform.up) > 130)
            //{
            Destroy(hit.transform.gameObject);  //destruccion del objeto!!
            FindObjectOfType<AudioManager>().Play("destroy");   //sonido
            explode();
            time = 0.0f;
            //}

        }
        previousPos = transform.position;
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
}