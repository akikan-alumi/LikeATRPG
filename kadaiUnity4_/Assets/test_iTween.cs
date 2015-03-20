using UnityEngine;
using System.Collections;

public class test_iTween : MonoBehaviour {
    public GameObject gameobject;
    Hashtable table = new Hashtable();      // ハッシュテーブルを用意

    private void Start() {
        table.Add("x", 10);            // xを10まで移動
        table.Add("y", 5);         // yを5まで移動
        table.Add("time", 1.0f);        // トゥイーン時間は3秒
        table.Add("delay", 1.0f);       // 1秒遅らせてからトゥイーンスタート
        table.Add("oncomplete", "CompleteHandler");
        table.Add("oncompletetarget", gameObject);

        iTween.MoveTo(gameObject, table);   // 第二引数にハッシュテーブルをセット
        //iTween.MoveTo(gameObject, iTween.Hash("x", 20, "looptype", iTween.LoopType.loop));
        // 4秒かけて、y軸を260度回転
        //iTween.RotateTo(gameObject, iTween.Hash("y", 260, "time", 4.0f));
        // 4秒かけて、y軸を3倍に拡大
        //iTween.ScaleTo(gameObject, iTween.Hash("y", 3, "time", 4.0f));
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("OnTriggerStay");
    }

    private void StartHandler() {
        Debug.Log("StartHandler");
    }

    private void UpdateHandler() {
        Debug.Log("UpdateHandler");
    }

    private void CompleteHandler() {
        Debug.Log("CompleteHandler");
    }

}
