using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xieC : MonoBehaviour {
    WWW www;
    // Use this for initialization
    void Start () {
        StartCoroutine(OnDon());
	}

    IEnumerator OnDon()
    {
        www = new WWW("http://f.hiphotos.baidu.com/zhidao/wh%3D450%2C600/sign=b222a45a030828386858d4108da98537/8694a4c27d1ed21b9ba921a0a96eddc451da3f16.jpg");
        yield return www;
        Debug.Log(www.progress);
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.GetComponent<MeshRenderer>().material.mainTexture = www.texture;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
