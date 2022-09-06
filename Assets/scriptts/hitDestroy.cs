using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDestroy : MonoBehaviour
   
{
    GameObject GameControl;
    GameControl control;
    public GameObject patlama;
    public GameObject playerPatlama;

    private void Start()
    {
        GameControl = GameObject.FindGameObjectWithTag("gamecontrol");
        control = GameControl.GetComponent<GameControl>();
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "bullet")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(patlama, transform.position, transform.rotation);
            control.ScoreAdd(10);
        }

        if (col.tag == "player")
        {
            Instantiate(playerPatlama, col.transform.position, col.transform.rotation);
                control.gameOver();
        }
    }

}
