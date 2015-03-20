using UnityEngine;
using System.Collections;
using System;

public class trace : MonoBehaviour {
    // 開始位置のオブジェクト
    //public GameObject StartPosition;
    private RaycastHit hit;
    private Vector3 normalVec3 = new Vector3(0.5f,0.5f,0.5f);
    // Use this for initialization
    void Start() {
        // 開始位置をとりあえずゴールを開始位置のオブジェクトの位置に

        hit.point = normalVec3;

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // クリックした画面から半直線(ray)を生成
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 半直線にヒットした情報をhit変数に格納
            Physics.Raycast(ray, out hit);
        }
        // 位置を更新し続ける
        iTween.MoveUpdate(gameObject, hit.point, 1.0f);
    }
}