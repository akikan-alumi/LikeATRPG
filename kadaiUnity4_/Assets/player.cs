using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
    private float hor;
    private float ver;
    public float speed = 1.0f;
    public Vector3 vecPlayer;
    private bool nowMove;
	// Use this for initialization
	void Start () {
        hor = 0f;
        ver = 0f;
        vecPlayer = Vector3.zero;
        this.transform.position= new Vector3(0.5f,0.5f,0.5f);
        nowMove = false;
	}
	
	// Update is called once per frame
	void Update () {
        movePlayer();//プレイヤー移動処理
        movePlayerGraph();//プレイヤー移動描画
	}

    private void movePlayer() {
        if (!nowMove) {
            hor = Input.GetAxisRaw("Vertical");//ぷれいやーの移動処理
            ver = Input.GetAxisRaw("Horizontal");
            vecPlayer = this.transform.position;
            if ((hor == -1 || hor == 1) && ver == 0) {//x軸方向
                vecPlayer += Vector3.forward * hor * speed;
            }
            if (hor == 0 && (ver == -1 || ver == 1)) {//z軸方向
                vecPlayer += Vector3.right * ver * speed;
            }
        }
    }
    private void movePlayerGraph() {//プレイヤー移動描画
        if (vecPlayer != this.transform.position) {
            nowMove = true;//移動中フラグ
            float X = vecPlayer.x + this.transform.position.x;
            float Y = vecPlayer.y + this.transform.position.y;
            float Z = vecPlayer.z + this.transform.position.z;


        } else {
            nowMove = false;
        }
    }
}
