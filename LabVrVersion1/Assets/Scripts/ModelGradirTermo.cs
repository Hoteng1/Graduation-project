using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelGradirTermo : MonoBehaviour
{

    private StoveLogical stoveLogical;
    private GameObject Stove;
    private GameObject VMetr;
    private TextMesh Display;
    private TextMesh Text;
    // Use this for initialization
    void Start()
    {
       
        Stove = GameObject.Find("Stove");
        VMetr = GameObject.Find("VmetrM");
        stoveLogical = StoveLogical.getInstance();
        stoveLogical.Init(Stove, VMetr);
        Display = GameObject.Find("DisplayData").GetComponent<TextMesh>();
        Text = GameObject.Find("Data").GetComponent<TextMesh>();
        //m_SpriteRenderer.sprite = m_SpriteRenderer.GetComponents<Sprite>()[1];

    }

    // Update is called once per frame
    void Update()
    {
        if(StaticMethods.currentExp == Exp.Termo)
        {
            if (Input.GetKey(KeyCode.E))
            {

                stoveLogical.OpenDoor();
            }
            if (Input.GetKey(KeyCode.Q))
            {

                stoveLogical.CloseDoor();
            }

            stoveLogical.RotateArrow();
            stoveLogical.ShowDisplay(Display);
            Text.text = stoveLogical.GetInformation();
        }
       


        


    }
}
