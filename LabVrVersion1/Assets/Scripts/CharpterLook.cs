using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CharpterLook : MonoBehaviour
{

    public Transform playerBody;
    public float mouseSensitivity;
    float xAxisClamp = 0.0f;
    private StoveLogical stove;
    private bool isAutoriz;
    public string login;
    public string password="";
    private void Start()
    {
  
       if(StaticMethods.Id_user==0)
        {
            isAutoriz = false;
        }
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
        if(isAutoriz)
        {
            GUI.Box(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 80, 240, 230), "Авторизация");
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 60, 200, 30), "Логин");
            login = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 25), login);
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 30), "Пороль");
            password = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 30, 200, 25), CreateWord(password.Length));
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - -60, 200, 30), "Войти"))
            {
                
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - -95, 200, 30), "Регистрация"))
            {
                
            }
            //GUI.Box(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 130, 240, 260), "Регистрация");
            //GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 115, 200, 30), "Курс");
            //string NickName = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 90, 200, 25), "");
            //GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 60, 200, 30), "Логин");
            //login = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 25), "" + login);
            //GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 30), "Пароль");
            //password = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - -30, 200, 25), "" + password);
            //if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - -60, 200, 30), "Продолжить"))
            //{
               
            //}
            //if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - -95, 200, 30), "Выйти"))
            //{
                
            //}
        }
    }
    private string CreateWord(int length)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for(int i=0;i<length;i++)
        {
            stringBuilder.Append("*");
        }
        return stringBuilder.ToString();
    }


}
