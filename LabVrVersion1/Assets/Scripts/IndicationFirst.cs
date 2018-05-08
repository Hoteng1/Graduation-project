using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicationFirst : MonoBehaviour {

    public string nameModel;
    private Light currentLight;
	// Use this for initialization
	void Start () {
        currentLight = gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(StaticMethods.currentExp.ToString().Equals(nameModel))
        {
            currentLight.color = Color.green;
        }
        else
        {
            currentLight.color = Color.red;
        }


	}

    private void OnMouseDown()
    {
        switch(nameModel)
        {
            case "Termo": { StaticMethods.currentExp = Exp.Termo; } break;
            case "Paro": { StaticMethods.currentExp = Exp.Paro; } break;
            default: { StaticMethods.currentExp = Exp.Other; } break;
        }
    }
}
