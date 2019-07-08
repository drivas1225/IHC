using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class customScript : NetworkBehaviour
{
    public override void OnStartLocalPlayer()
    {
        gameObject.GetComponent<Animator>().enabled = true;
    }
}
