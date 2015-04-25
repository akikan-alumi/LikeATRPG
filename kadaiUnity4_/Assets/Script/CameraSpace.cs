using UnityEngine;
using System.Collections;
/// <summary>
/// このクラスとメソッドにはカメラに関する処理を入れる
/// 初期設定としてAwakeにはカメラのUI表示とメイン画面表示の比率の設定を行っている。
/// 
/// </summary>
public class CameraSpace : MonoBehaviour {
    public Camera UIcamera;
    public GameObject mainCamGameObject;
    private Camera mainCamera;

    /// <summary>
    /// 以下はiTween用グローバル変数
    /// 注意:カメラが進む方向/移動速度＝移動秒数
    /// </summary>
    private float MoveCamera = 5f;//カメラの移動量をここで定義する
    private float speed = 10f;//カメラの移動速度を定義する。
    private const float cameraY = 10f;//カメラの通常位置、基本的に動かさないように
	
	void Awake () {
        mainCamera = mainCamGameObject.GetComponent<Camera>();
        mainCamera.rect = new Rect(0,0,0.8f,1);
        UIcamera.rect = new Rect(0.8f, 0, 0.8f, 1);
	}

    /// <summary>
    /// iTweenLeftMove
    /// カメラを左に移動させる
    /// </summary>
    public void iTweenLeftMove() {
        hashAdd(MoveCamera); 
    }
    /// <summary>
    /// iTweenRightMove
    /// カメラを右に移動させる
    /// </summary>
    public void iTweenRightMove() {
         hashAdd(-MoveCamera);
    }

    /// <summary>
    /// hashadd
    /// カメラの移動方向や移動速度のメソッド
    /// 
    /// h27/04/26
    /// hashtableとか使ってみたけどこれ使いやすいのかねぇ？
    /// 別変数を複数保存できるものとしてはそれなりなのかも
    /// </summary>
    /// <param name="ArgumentX"></param>
    /// <returns></returns>
    private void hashAdd(float ArgumentX) {
        var hash = new Hashtable() {
            {"speed", speed},
            {"x", mainCamGameObject.transform.localPosition.x-ArgumentX},
            {"y", cameraY},
            {"easyType",iTween.EaseType.linear},
        };
        iTween.MoveTo(mainCamGameObject, hash);
    }
}
