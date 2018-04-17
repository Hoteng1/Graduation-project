using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelGradirTermo : MonoBehaviour
{

    private StoveLogical stoveLogical;
    private GameObject Stove;
    private GameObject VMetr;
    SpriteRenderer m_SpriteRenderer;
    // Use this for initialization
    void Start()
    {
        m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
        Stove = GameObject.Find("Stove");
        VMetr = GameObject.Find("Vmetr");
        stoveLogical = StoveLogical.getInstance();
        stoveLogical.Init(Stove, VMetr);
        m_SpriteRenderer.sprite = m_SpriteRenderer.GetComponents<Sprite>()[1];
;
    }

    // Update is called once per frame
    void Update()
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


    }
}
