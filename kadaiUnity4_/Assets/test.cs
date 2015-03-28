using UnityEngine;
using System.Collections;

///dllのテスト
using testdll;
/// <summary>
/// 
/// </summary>
public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(testdll.MyClass.message());
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
