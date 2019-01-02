using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;

public class UISceneCtr : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TTUIPage.ShowPage<MainPanel>();
        TTUIPage.ShowPage<MapPanel>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
