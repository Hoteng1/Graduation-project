using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParoStove : MonoBehaviour
{

    public GameObject gl_knopka;
    private GameObject lopasty;
    private bool vkl = false;
    public string a = "";
    public string b = "";
    public float speed = 0.1f;
    public float T = 0;
    public float T1 = 20;//начальное значение температуры
    public float T2;
    public float d_T;//дельта Т (разница температур)
    public string d_T_s = "";
    public float kpd = 377;//теоретическое значение КПД компрессора
    public string kpd_s = "";
    public float c1u;
    public float c_u;//удельная теплоемкость
    public string c_u_s = "";
    public float m = 13.6f;//масса фреона
    public float Q;//количество теплоты
    public string Q_s = "";
    public float C;//теплоемкость
    public string C_s = "";
    public float Ro;//плотность фреона
    public float V;//объем фреона
    public float Nu;//удельный объем
    public string Nu_s;
    public float Ro_1;//плотность вещества (фреона)
    public string Ro_1_s = "";
    public float Nu_1;
    public string Nu_1_s = "";
    public string V_s = "";
    private TextMesh Text;
    // Use this for initialization
    void Start()
    {
        lopasty = GameObject.Find("Lopast");
        Text = GameObject.Find("DataTwo").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticMethods.currentExp == Exp.Paro)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                vkl = !vkl;
                if (vkl)
                {
                    a = "Включенно";

                }
                else
                {
                    a = "Выключенно";
                }
            }

            if (vkl)
            {
                if (speed <= 20)
                {
                    speed += 0.1f;
                    lopasty.transform.Rotate(new Vector3(0, 90, 0), speed, Space.Self);
                }
            }

            if (!vkl)
            {
                if (speed > 0)
                {
                    speed -= 0.1f;
                    lopasty.transform.Rotate(new Vector3(0, 90, 0), speed, Space.Self);
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (vkl == true)
                {
                    T += 0.1f;
                    T2 = T1;
                    T1 += 10;
                    ChangeTermo();
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (vkl == true)
                {
                    T -= 0.1f;
                    T2 = T1;
                    T1 -= 10;
                    ChangeTermo();
                }
            }

            if (speed >= 19.9f)
            {
                lopasty.transform.Rotate(new Vector3(0, 90, 0), speed - T, Space.Self);
            }

            

            if (Input.GetKeyDown(KeyCode.O))
            {
                if (vkl == true)
                {
                    Ro_1 = Random.Range(894.1f, 1517);
                    Ro_1_s = "Ro = " + Ro_1.ToString();
                    Ro = (float)System.Math.Round(Ro_1, 2);
                    V = m / Ro;//объем фреона
                    V_s = "Объем = " + V.ToString();
                    Nu_1 = V / m;//удельный объем фреона
                    Nu_1_s = "Удельный объем (без округления) = " + Nu_1.ToString();
                    Nu = (float)System.Math.Round(Nu_1, 5);
                    Nu_s = "Удельный объем = " + Nu.ToString();
                }

            }

            GetInforamtion();
        }
        
    }

    public void GetInforamtion()
    {
        Text.text = a + '\n' +
        b + '\n' +
        kpd_s + '\n' +
         Q_s + '\n' +
         C_s + '\n' +
         Nu_s + '\n' +
        c_u_s + '\n' +
         d_T_s + '\n' +
        Ro_1_s + '\n' +
         Nu_1_s;
    }

    public void ChangeTermo()
    {
        b = "T = " + (float)System.Math.Round(T1, 2);

        c1u = Random.Range(1.1f, 2.2f);
        c_u = (float)System.Math.Round(c1u, 2);//удельная теплоемкость фреона
        c_u_s = "Удельная теплоемкость = " + c_u.ToString();
        d_T = T1 - T2;
        d_T_s = "Дельта T (Разница температур) = " + d_T.ToString();
        Q = c_u * m * (T1 - T2);
        Q_s = "Количество теплоты = " + Q.ToString();
        C = c_u * m;
        C_s = "Теплоемкость = " + C.ToString();
    }
}
