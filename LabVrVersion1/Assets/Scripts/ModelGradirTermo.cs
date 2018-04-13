using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelGradirTermo : MonoBehaviour
{

    private StoveLogical stoveLogical;
    private GameObject Stove;
    private GameObject VMetr;

    // Use this for initialization
    void Start()
    {
        Stove = GameObject.Find("Stove");
        VMetr = GameObject.Find("Vmetr");
        stoveLogical = StoveLogical.getInstance();
        stoveLogical.Init(Stove, VMetr);
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Press Key E");
            stoveLogical.OpenDoor();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Press Key Q");
            stoveLogical.CloseDoor();
        }
        


    }
}
