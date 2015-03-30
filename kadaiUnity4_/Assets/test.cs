using UnityEngine;
using System.Collections;
using UnityEditor;
/// <summary>
/// unityの公式にあるUnityScriptでのOpenFilePanelのクラスをがんばってC#にした。
/// 最初はstartにどちらも入れていたのだが、どうやら20行目あたりにあるreturn文が悪さをするので
/// AwakeとStartの2つに分けた。
/// 03/30追記
/// Start廃止してchangeTextureに変更
/// 参考URL：http://docs.unity3d.com/ja/current/ScriptReference/EditorUtility.OpenFilePanel.html
/// </summary>
public class test : MonoBehaviour {
    private EditorUtility eu;
    public Texture2D tx;
    public GameObject texture;
    void Awake() {
        eu = new EditorUtility();
        tx = Selection.activeObject as Texture2D;
        if (tx == null) {
            EditorUtility.DisplayDialog(
                "SelectTexture",
                "テクスチャが設定されてません",
                "OK");
            return;
        }
    }
	// Use this for initialization
	public void changeTexture () {
        
        var path = EditorUtility.OpenFilePanel(
            "Overwrite with jpg",
            "",
            "jpg");
        if (path.Length != 0) {
            var www = new WWW("file:///" + path);
            tx = www.textureNonReadable;
            Sprite spriteTexture = Sprite.Create(tx ,new Rect(0,0,255,255),Vector2.zero);
            texture.GetComponent<SpriteRenderer>().sprite = spriteTexture;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
