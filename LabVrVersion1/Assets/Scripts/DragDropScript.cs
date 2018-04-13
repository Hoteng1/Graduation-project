using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour {

    //Initialize Variables
    GameObject getTarget;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;
    StoveLogical stoveLogical;
    // Use this for initialization
    void Start()
    {
        stoveLogical = StoveLogical.getInstance();
    }

    void Update()
    {

        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {
            getTarget = ReturnClickedObject();
            if (getTarget != null && isReferenceTrue(getTarget))
            {
                isMouseDragging = true;
                //Converting world position to screen position.
                positionOfScreen = Camera.allCameras[0].WorldToScreenPoint(getTarget.transform.position);
                offsetValue = getTarget.transform.position - Camera.allCameras[0].ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
            }
        }

        //Mouse Button Up
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
            Debug.Log(stoveLogical.isIncludeObject(getTarget));
        }

        //Is mouse Moving
        if (isMouseDragging)
        {
            //tracking mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

            //converting screen position to world position with offset changes.
            Vector3 currentPosition = Camera.allCameras[0].ScreenToWorldPoint(currentScreenSpace) + offsetValue;

            //It will update target gameobject's current postion.
            getTarget.transform.position = currentPosition;
        }


    }

    //Method to Return Clicked Object
    GameObject ReturnClickedObject()
    {
        
        GameObject target = null;
        RaycastHit raycastHit;
        Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit))
        {
            target = raycastHit.collider.gameObject;
        }
        return target;
    }

    bool isReferenceTrue(GameObject gameObject)
    {
        string[] LockObjects ={ "FirstObject", "Terrain" };
        for(int i=0;i<LockObjects.Length;i++)
        {
            if (gameObject.Equals(GameObject.Find(LockObjects[i])))
            {
                return false; 
            }
        }

        return true;
    }
}
