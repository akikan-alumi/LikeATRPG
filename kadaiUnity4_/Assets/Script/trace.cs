using UnityEngine;
using System.Collections;
using System;
public class trace : MonoBehaviour {
    // 開始位置のオブジェクト
    private RaycastHit hit;
    private Vector3 normalVec3 = new Vector3(0.5f,0.5f,0.5f);
    [SerializeField]
    private Vector3 hitVec3;


    public Camera mainCamera;//かめらの位置取得用

    private float negativeMargin = 0f;
    //private float positiveMargin = 1f;
    private float marginX = Screen.width * 0.8f;
    private float marginY = Screen.height;

    private float mySpeed;//トゥウィーンで動くときのスピード

    void Awake() {
        print("スクリーンの大きさ　X：" + marginX + "   Y:"+marginY);
    }

    // Use this for initialization
    void Start() {
        mySpeed = 1f;
        // 開始位置を画面中心辺りにする        
        hit.point = normalVec3;
        this.transform.position = normalVec3;
        hitVec3 = normalVec3;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // クリックした画面から半直線(ray)を生成
            Vector3 vec3 = Input.mousePosition;
            if (isOutOfScreen(vec3)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // 半直線にヒットした情報をhit変数に格納
                Physics.Raycast(ray, out hit);

                hitVec3 = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
                print("真");
                print("playerの現在位置transform"+transform.position);
            } else {
                print("偽");
                print("playerの現在位置transform" + transform.position);
            }
        }
        // 位置を更新し続ける
        iTween.MoveUpdate(gameObject, hitVec3, mySpeed);
    }

    private bool isOutOfScreen(Vector3 vec3) {
        print("カメラからみたクリック場所取得" + vec3);
        if ((vec3.x >= negativeMargin &&//フィールドが表示されている部分
            vec3.x <= marginX) &&
            (vec3.y >= negativeMargin &&
            vec3.y <= marginY)) {
            return true;
        }else{
            return false;
        }
    }
}