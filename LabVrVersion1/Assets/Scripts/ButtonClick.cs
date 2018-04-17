using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour {

    private StoveLogical stoveLogical;
	// Use this for initialization
	void Start () {
        stoveLogical = StoveLogical.getInstance();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        stoveLogical.BeginExpereince();
    }
}
