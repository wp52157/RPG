using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;

public class StatusPanel : TTUIPage {

    Text hpT, mpT, atkT, defT, SpeedT, hitT;
    Button cBut;
	public StatusPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "StatusPanel";
    }

    public override void Awake(GameObject go)
    {
        base.Awake(go);
        hpT= transform.Find("Image/Hp/Value").GetComponent<Text>();
        mpT= transform.Find("Image/Mp/Value").GetComponent<Text>();
        atkT = transform.Find("Image/Atk/Value").GetComponent<Text>();
        defT = transform.Find("Image/Def/Value").GetComponent<Text>();
        SpeedT = transform.Find("Image/Speed/Value").GetComponent<Text>();
        hitT = transform.Find("Image/Hit/Value").GetComponent<Text>();
        cBut = transform.Find("Image/Button").GetComponent<Button>();
        cBut.onClick.AddListener(() => ClosePage<StatusPanel>());
        
    }
    public override void Refresh()
    {
        base.Refresh();
        hpT.text = (100 + StatusModel.Hp).ToString();
        mpT.text = (100 + StatusModel.Mp).ToString();
        atkT.text = (40 + StatusModel.Atk).ToString();
        defT.text = (10 + StatusModel.Def).ToString();
        SpeedT.text = (5 + StatusModel.Speed).ToString();
        hitT.text = (1 + StatusModel.Hit).ToString();
    }
}
