using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;

public class MapPanel : TTUIPage {
    public Button jiaBut, jianBut;

	public MapPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "MapPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        jiaBut = GameObject.Find("JiaButton").GetComponent<Button>();
        jianBut = GameObject.Find("JianButton").GetComponent<Button>();
        jiaBut.onClick.AddListener(() => { transform.GetChild(0).GetComponent<RectTransform>().localScale = Vector3.one * 2; transform.GetChild(1).GetComponent<RectTransform>().localScale = Vector3.one * 2; });
        jianBut.onClick.AddListener(() => { transform.GetChild(0).GetComponent<RectTransform>().localScale = Vector3.one; transform.GetChild(1).GetComponent<RectTransform>().localScale = Vector3.one ; });
    }
}
