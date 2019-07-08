using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class saber : NetworkBehaviour
{
    public LayerMask layer;
    public GameObject Score_text;
    public GameObject Multiplier_text;
    private Vector3 previousPos;

    float time=0.0f;

    [SyncVar(hook="SyncScore")]
    int Score = 0;
    [SyncVar]
    int Mul;
    [SyncVar]
    int count;
    [SyncVar]
    bool destroyed;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject scr = Instantiate(Score_text);
        //GameObject Instantiate(Multiplier_text);
        Mul = 1;
        count = 0;
        destroyed = true;
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

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward*5, Color.green);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5, layer))
        {
            //Debug.DrawRay(transform.position, transform.forward*100, Color.red);
            print("Hit");
            //if( Vector3.Angle(transform.position-previousPos,hit.transform.up) > 130)
            //{
            Destroy(hit.transform.gameObject);  //destruccion del objeto!!
            FindObjectOfType<AudioManager>().Play("destroy");   //sonido
            //hit.transform.gameObject.explode();
            count++;
            if (count % 4 == 0 && Mul < 8 )
            {
                count = 0;
                Mul = int.Parse(Multiplier_text.GetComponent<TextMesh>().text) * 2;
                GameObject.Find("Mul").GetComponent<TextMesh>().text = Mul.ToString();
                //Multiplier_text.GetComponent<TextMesh>().text = Mul.ToString();
            }
            Mul = int.Parse(GameObject.Find("Mul").GetComponent<TextMesh>().text);
            int auxScore = int.Parse(GameObject.Find("Score").GetComponent<TextMesh>().text ) + 100 * Mul;
            Debug.Log("paso por aqui!................................");
            CmdUpdateScore(auxScore);
            Debug.Log("paso por aqui tambien!................................");
            //Score_text.GetComponent<TextMesh>().text = Score.ToString();
            GameObject.Find("Score").GetComponent<TextMesh>().text = auxScore.ToString();
            //RpcSyncScore(Score);

            time = 0.0f;
            Debug.Log(Score);
            Debug.Log(Mul);
            //}

        }
        previousPos = transform.position;
    }

    [Command(channel=1)]
    public void CmdUpdateScore(int NewScore)
    {
        Score = NewScore;
        RpcScore(Score); 
    }

    [ClientRpc]
    void RpcScore(int _score)
    {
        Debug.Log("Se actualizo el score!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! "+_score );
    }

    public void UpdateScoreUI(int newScore)
    {
        //Do whatever UI update you need for this new score here

        Score = newScore;  //Need to set the SyncVar locally on the client when using SyncVar hooks
        GameObject.Find("Score").GetComponent<TextMesh>().text = Score.ToString();
    }

    //[ClientRpc]
    public void SyncScore(int new_score)
    {
        Score = new_score;
    }
}