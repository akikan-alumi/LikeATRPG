using UnityEngine;
using System.Collections;

public class CameraSpace : MonoBehaviour {
    public Camera UIcamera;
    public Camera mainCamera;
	// Use this for initialization
	void Awake () {
        mainCamera.rect = new Rect(0,0,0.8f,1);
        UIcamera.rect = new Rect(0.8f, 0, 0.8f, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void leftMove() {
       // mainCamera.transform.position += ;
    }
}
