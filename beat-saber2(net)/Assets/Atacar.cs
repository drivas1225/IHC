using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;


public class Atacar : NetworkBehaviour
{
    public GameObject[] cubes;
    public GameObject firstPersonCharacter;
    public GameObject[] characterModel;
    float time = 0;
    

    public override void OnStartLocalPlayer()
    {
        //CmdinitCharacter();
        //int id = connectionToClient.connectionId;
        GetComponent<FirstPersonController>().enabled = true;
        firstPersonCharacter.SetActive(true);


        foreach (GameObject go in characterModel)
        {   
            go.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)return;

        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        time += Time.deltaTime;
        

        if (time > 0.8 && Input.GetKeyDown(KeyCode.O))
        {
            time = 0;
            //Debug.Log("cubo instanciado");
            //GameObject new_cube = Instantiate(cubes[Random.Range(0, 4)], this.transform.position, Quaternion.identity);
            //new_cube.transform.localPosition = Vector3.zero + transform.position; //0.5 2 -2.5 -1
            CmdFire();
            
            
        }
        //CmdTest();

    }

    [Command]
    void CmdFire()
    {
        Vector3 spawn = transform.forward * 5;
        GameObject new_cube = Instantiate(cubes[Random.Range(0, 4)], 
            transform.position + new Vector3(0, 2, 2), transform.rotation);
        new_cube.transform.localRotation = Quaternion.identity;
        //new_cube.transform.localPosition = transform.position - new Vector3(0, 0, 30); //0.5 2 -2.5 -1

       

        NetworkServer.Spawn(new_cube);
        Destroy(new_cube, 5);
    }


    [Command]
    public void CmdTest()
    {
        Debug.Log("A Client called a command, client's id is: " + connectionToClient);
        
    }

}
