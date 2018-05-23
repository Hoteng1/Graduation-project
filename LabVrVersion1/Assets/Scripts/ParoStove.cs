using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParoStove : MonoBehaviour
{

    public GameObject gl_knopka;
    private GameObject lopasty;
    private GameObject ArrowP1;
    private GameObject ArrowP2;
    private TextMesh T1Text;
    private TextMesh T2Text;
    private TextMesh T4Text;
    private float speed;
    private double TFeron = -4;
    private double PFerom = 1;
    private double T1;
    private double T2;
    private double T4;
    private double P1;
    private double P2;
    private double Patm = 1;
    private double TCompreser = 80;
    private double TEvaporator = -8;
    private float deltaSpeed=0;
    private float diferentP1=0;
    private float diferentP2=0;
    private TextMesh Text;
    System.Random rand;
    int Count = 0;
    
    // Use this for initialization
    void Start()
    {
        lopasty = GameObject.Find("Lopast");
        Text = GameObject.Find("DataTwo").GetComponent<TextMesh>();
        T1Text = GameObject.Find("T2").GetComponent<TextMesh>();
        T2Text = GameObject.Find("T3").GetComponent<TextMesh>();
        T4Text = GameObject.Find("T1").GetComponent<TextMesh>();
        ArrowP1 = GameObject.Find("ArrowP1");
        ArrowP2 = GameObject.Find("ArrowP2");
        rand = new System.Random();

    }

    // Update is called once per frame
    void Update()
    {
        if (StaticMethods.currentExp == Exp.Paro)
        {
          
            if (StaticMethods.isTHD)
            {
                if (speed <= 10)
                {
                    speed += deltaSpeed;
                    GetInformation();
                    EvaporatorToCompressor();
                }
                lopasty.transform.Rotate(new Vector3(0, 90, 0), speed, Space.Self);
                
               

            }

            if (!StaticMethods.isTHD)
            {
                if (speed > 0)
                {
                    speed -= deltaSpeed;
                    lopasty.transform.Rotate(new Vector3(0, 90, 0), speed, Space.Self);
                }
            }
            
            
        }
        
        
    }

    

    private void EvaporatorToCompressor()
    {
        while(TFeron <  TCompreser - rand.Next(-5,5)) //Комрпессор вытягивает пар из испарителя повышает давление и температуру
        {
            TFeron += 1;
            PFerom += 0.5;
            T2 =  TFeron;
            P2 =  PFerom;
            ArrowP2.transform.Rotate(diferentP2, 0, 0);
            ArrowP2.transform.Rotate((float)(P2 * 9), 0, 0);
            diferentP2 = -(float)(P2 * 9);
            new  WaitForSeconds(10);


        }

        CompressorToCondesator();
    }

    private void  CompressorToCondesator() //Кондесатор доводит пар до жидкого состояние пар , после чего происходит 60%-80% тепла.(переохлождение)
    {
        TFeron=TFeron* rand.Next(6, 8)/10;
        T4 = TFeron;
        deltaSpeed =((float)(T2 / T4));
        CondensatorToResiver();
        
    }

    private void CondensatorToResiver()
    {
        while(PFerom > Patm + rand.Next(-5,5)/10)
        {
            PFerom -= 0.5;
            P1 = PFerom;
            ArrowP1.transform.Rotate(diferentP1, 0, 0);
            diferentP1 = -(float)(P1 * 9);
            ArrowP1.transform.Rotate((float)(P1 * 9), 0, 0);
        }
        ResiverToEvaporator();
    }

    private void ResiverToEvaporator()
    {
        while(TFeron > TEvaporator + rand.Next(-4,2))
        {
            TFeron --;
            T1 = TFeron;
            
        }       
    }

    public void GetInformation()
    {
        if (Count > 8)
        {
            Count = 0;
            Text.text = "";
        }
        Text.text += "T1 " + Math.Round(T1) +
         " T2 " + Math.Round(T2) +
         " T4 " + Math.Round(T4) + " P1 " + Math.Round(P1)
         + " P2 " + Math.Round(P2) + Environment.NewLine;
        T1Text.text = Math.Round(T1).ToString();
        T2Text.text = Math.Round(T2).ToString();
        T4Text.text = Math.Round(T4).ToString();
        Count++;
    }
   
   
    

}
