using UnityEngine;
using System.Collections;

public class CameraSpace : MonoBehaviour {
    public Camera UIcamera;
    public Camera mainCamera;

    private Vector3 mainVec;
//    private Vector3 UIVec;//必要ないかもだけど一応

    private Vector3 rightVec;//左右にカメラを動かすときに使う変数
	// Use this for initialization
	void Awake () {
        mainCamera.rect = new Rect(0,0,0.8f,1);
        UIcamera.rect = new Rect(0.8f, 0, 0.8f, 1);
        mainVec = mainCamera.transform.position;
  //      UIVec = UIcamera.transform.position;
        rightVec = new Vector3(1f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (mainCamera.transform.position != mainVec) {

        }
	}
    public void leftMove() {
        mainCamera.transform.position -= rightVec;
    }
}
