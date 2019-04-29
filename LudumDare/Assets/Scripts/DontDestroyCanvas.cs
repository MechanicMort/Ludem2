using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCanvas : MonoBehaviour {


    public static DontDestroyCanvas Canvas;

	// Use this for initialization
	void Start () {
        if (DontDestroyCanvas.Canvas == null)
        {
            Canvas = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
