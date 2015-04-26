using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// unityの公式にあるUnityScriptでのOpenFilePanelのクラスをがんばってC#にした。
/// 最初はstartにどちらも入れていたのだが、どうやら20行目あたりにあるreturn文が悪さをするので
/// AwakeとStartの2つに分けた。
/// h27/03/30追記
/// Start廃止してchangeTextureに変更
/// h27/0426追記
/// そもそもの並び方を変更
/// なぜAwakeでインスタンス生成しないとエラーでるし
/// 参考URL：http://docs.unity3d.com/ja/current/ScriptReference/EditorUtility.OpenFilePanel.html
/// </summary>
public class inputTexture : MonoBehaviour {
    public Texture2D texture2D;
    public GameObject textureGameObject;
    void Awake() {
        /*ここでインスタンス生成しないとエラーが出る。*/
        texture2D = Selection.activeObject as Texture2D;
    }

    /// <summary>
    /// changeTexture
    /// uGUI用に作成した。
    /// 何かしらのGameObjectにこの.csを入れて、uGUIに登録すれば使える。
    /// </summary>
    public void changeTexture () {
        
        var path = EditorUtility.OpenFilePanel(
            "Overwrite with jpg",
            "",
            "jpg");
        if (path.Length != 0) {
            var www = new WWW("file:///" + path);
            texture2D = www.textureNonReadable;

            /*↓テクスチャをとりあえず表示する部分↓*/
            Sprite spriteTexture = Sprite.Create(texture2D ,new Rect(0,0,255,255),Vector2.zero);
            textureGameObject.GetComponent<SpriteRenderer>().sprite = spriteTexture;
            /*↑テクスチャをとりあえず表示する部分↑*/
        }
        if (texture2D == null) {
            EditorUtility.DisplayDialog(
                "SelectTexture",//タイトルバー
                "テクスチャが設定されてません",//本文
                "OK"//ボタン
                );
        }
	}
}
#endif