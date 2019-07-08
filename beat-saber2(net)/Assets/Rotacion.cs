using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    float speed = 50.0f;
    Vector3 rot = new Vector3(0, 0, 1);
    int[] dir = { 1 , -1};
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            speed = Random.Range(50.0f, 200.0f);
            rot = new Vector3(0, 0, dir[ Random.Range(0, 2) ]);
            timer = 0;
        }
        transform.Rotate(rot * speed * Time.deltaTime);
    }
}
