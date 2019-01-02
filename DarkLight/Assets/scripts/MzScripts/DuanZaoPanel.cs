using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;

public class DuanZaoPanel : TTUIPage {

    Transform BBtransform;
    Sprite cBB, cBc;
    Button closeBut, duanZaoBut;
	public DuanZaoPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "DuanZaoPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        closeBut = transform.Find("Image/CloseBut").GetComponent<Button>();
        duanZaoBut = transform.Find("Image/DuanZaoBut").GetComponent<Button>();
        closeBut.onClick.AddListener(() => GameObject.Destroy(gameObject));
        BBtransform = Resources.Load<Transform>("EquipImage");
    }
    public override void Refresh()
    {
        base.Refresh();
        Debug.Log(Save.duanList[0].Id);
        Debug.Log(Save.duanList[1].Id);
        Transform tempImage = GameObject.Instantiate(BBtransform);
        Transform tempImage1 = GameObject.Instantiate(BBtransform);
        cBB = Resources.Load<Sprite>("IconA/" + Save.duanList[0].Id);
        cBc = Resources.Load<Sprite>("IconA/" + Save.duanList[1].Id);
        ReadDuanZao(tempImage, "AA", cBB);
        ReadDuanZao(tempImage1, "BB", cBc);
        duanZaoBut.onClick.AddListener(() => { Save.DuanZao(Save.duanList[0], Save.duanList[1], new GoodsModel() { Id = 2020, Num = 1 });TTUIPage.ShowPage<TipPanel>("锻造成功");GameObject.Destroy(gameObject); });
    }
    void ReadDuanZao(Transform AA, string ABC,Sprite BB)
    {
        AA.SetParent(transform.Find("Image/" + ABC));
        AA.localPosition = Vector3.zero;
        AA.GetComponent<RectTransform>().localScale = Vector3.one;
        AA.GetComponent<Image>().sprite = BB;
    }
}
