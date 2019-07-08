using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter (Collision col)
    {
        //Debug.Log("COLICION!!!!!!!!!!!!!!!!!!!!!!");
        //if (col.gameObject.name == "RED(Clone)" || col.gameObject.name == "BLUE(Clone)" || col.gameObject.name == "robotSphere(Clone)")
        //{
            Destroy(col.gameObject);
            //GameObject.Find("Mul").GetComponent<TextMesh>().text = "1";
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
