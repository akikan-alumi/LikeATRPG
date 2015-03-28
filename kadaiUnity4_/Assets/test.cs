using UnityEngine;
using System.Collections;
using UnityEditor;
/// <summary>
/// unityの公式にあるUnityScriptでのOpenFilePanelのクラスをがんばってC#にした。
/// 最初はstartにどちらも入れていたのだが、どうやら20行目あたりにあるreturn文が悪さをするので
/// AwakeとStartの2つに分けた。
/// 参考URL：http://docs.unity3d.com/ja/current/ScriptReference/EditorUtility.OpenFilePanel.html
/// </summary>
public class test : MonoBehaviour {
    private EditorUtility eu;
    public Texture2D tx;
    void Awake() {
        eu = new EditorUtility();
        tx = Selection.activeObject as Texture2D;
        if (tx == null) {
            EditorUtility.DisplayDialog(
                "SelectTexture",
                "You Must Select a Texture first!",
                "OK");
            return;
        }
    }
	// Use this for initialization
	void Start () {
        
        var path = EditorUtility.OpenFilePanel(
            "Overwrite with pnf",
            "",
            "png");
        if (path.Length != 0) {
            var www = new WWW("file:///" + path);
            www.LoadImageIntoTexture(tx);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
