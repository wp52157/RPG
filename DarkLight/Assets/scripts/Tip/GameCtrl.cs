using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl:MonoBehaviour {

    private static GameCtrl instance = null;
    //共有的唯一的，全局访问点

    public string nextSceneName;//要加载下个场景的名字
    public static GameCtrl Instance
    {
        get
        {
            if (instance == null)
            {    //查找场景中是否已经存在单例
                instance = GameObject.FindObjectOfType<GameCtrl>();
                if (instance == null)
                {    //创建游戏对象然后绑定单例脚本
                    GameObject go = new GameObject("GameCtrl");
                }
            }
            return instance;
        }
    }

    private void Awake()
    {    //防止存在多个单例
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }


}
