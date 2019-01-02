using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class BagPanel : TTUIPage {

    public Button closeBut;
    GameObject tempObjj,tempInfoUse;
    //public static Dictionary<string, Item> dicBag = new Dictionary<string, Item>();

    public BagPanel():base(UIType.Normal,UIMode.DoNothing,UICollider.None)
    {
        uiPath = "BagPanel";
    }

    public override void Awake(GameObject go)
    {
        //GameObject.Destroy(gameObject)
        base.Awake(go);
        tempInfoUse = transform.GetChild(1).gameObject;
        tempObjj = Resources.Load("BagImage") as GameObject;
        closeBut = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        closeBut.onClick.AddListener(() => 
        {
            GameObject.Destroy(gameObject);
           
        } );
        Item tempItemT = new Item();
        if (Save.goodList == null)
        {
            return;
        }
        for (int i = 0; i < Save.goodList.Count; i++)
        {
            tempItemT = DataMMM.GetInstence().GetItemById(Save.goodList[i].Id);//获取物品信息
            Sprite ss = Resources.Load<Sprite>("IconA/" + Save.goodList[i].Id);//根据id加载对应图片
            GameObject obj = GameObject.Instantiate(tempObjj);
            obj.transform.SetParent(transform.GetChild(0).GetChild(0).GetChild(0).GetChild(i));
            obj.transform.localPosition = Vector3.zero;
            obj.transform.GetComponent<RectTransform>().localScale = Vector3.one;
            obj.transform.GetComponent<Image>().sprite = ss;
            obj.transform.GetChild(0).GetComponent<Text>().text = Save.goodList[i].Num.ToString();
            
        }


        UIShiJian.OnInfoUse += Ex;
    }
    public override void Refresh()
    {
        base.Refresh();
        
    }

    public void Ex(string BB)
    {
        int bb = int.Parse(BB);
        tempInfoUse.SetActive(true);
        tempInfoUse.transform.GetChild(0).GetComponent<Text>().text = DataMMM.GetInstence().GetItemById(bb).item_Name;
        tempInfoUse.transform.GetChild(1).GetComponent<Text>().text = DataMMM.GetInstence().GetItemById(bb).description;
        tempInfoUse.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => tempInfoUse.SetActive(false));
        tempInfoUse.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() =>
        {
            if (DataMMM.GetInstence().GetItemById(bb).equipment_Type==Equipment_Type.Null)
            {
                TTUIPage.ShowPage<TipPanel>("药品不能穿！");
                return;
            }
            if (!Save.IsSaveOk(DataMMM.GetInstence().GetItemById(bb)))
            {
                TTUIPage.ShowPage<TipPanel>("穿戴失败！");
                return;
            }
            TTUIPage.ShowPage<TipPanel>("穿戴成功!");
            Save.ShiYongItem(DataMMM.GetInstence().GetItemById(bb));
            Item AA = DataMMM.GetInstence().GetItemById(bb);
            Save.equipList.Add(new EquipMode() { ID = bb, Dec = AA.description,Type=AA.equipment_Type });
            Save.SaveEquip();
            Save.Status();
            GameObject.Destroy(gameObject);
        });
        tempInfoUse.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() =>
        {
            Save.JiaRuDZ(DataMMM.GetInstence().GetItemById(bb));
            tempInfoUse.SetActive(false);
        });
    }
}
