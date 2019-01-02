using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tools {

	public static void LoadingByName(string strName)
    {
        SceneManager.LoadScene("Loading");
        GameCtrl.Instance.nextSceneName = strName;
    }
}
