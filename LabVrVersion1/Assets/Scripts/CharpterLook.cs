using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharpterLook : MonoBehaviour
{

    public Transform playerBody;
    public float mouseSensitivity;
    float xAxisClamp = 0.0f;
    private StoveLogical stove;

    private TextMesh Text;
  
    private void Start()
    {
        Text = GameObject.Find("Data").GetComponent<TextMesh>();
       
        stove = StoveLogical.getInstance();
    }
    void Awake()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotateCamera();

    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotCam.z = 0;
        targetRotBody.y += rotAmountX;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }




        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);


    }

    private void OnGUI()
    {
        Text.text = stove.GetInformation();
        //GUI.Box(new Rect(0, 0, 400, 400), "Information"+ stove.GetInformation());
    }
}
