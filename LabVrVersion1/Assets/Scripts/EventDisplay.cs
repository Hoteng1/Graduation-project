using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStove(UnityEngine.UI.Text text)
    {
        Debug.Log("Press Click");
        text.text = " Stove ON";
    }

    
}
