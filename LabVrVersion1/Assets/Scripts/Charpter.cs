using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charpter : MonoBehaviour
{

    CharacterController charControl;
    public float walkSpeed;
   

    void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    void Start()
    {
       
        
    }

    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Key Down C");

            StaticMethods.SwitchCursor();
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            CtrCharpter(-10);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            CtrCharpter(10);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StaticMethods.Jump(this.gameObject);
        }
    }

    void MovePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 moveDirSide = transform.right * horiz * walkSpeed;
        Vector3 moveDirForward = transform.forward * vert * walkSpeed;

        charControl.SimpleMove(moveDirSide);
        charControl.SimpleMove(moveDirForward);

    }

    void CtrCharpter(int change)
    {
        Vector3 localScale = transform.localScale;
        localScale.y += change;
        this.transform.localScale=localScale;
        Debug.Log(transform.localScale.y);
    }
}
