using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;

public class EquipPanel : TTUIPage {

    private Transform head, armor, leftHand, rightHand, shoes,accessory;
    public Button closeBut;
    Transform CCtransform;//显示装备预制
    GameObject tempInfoXie;
    Sprite spriteSS;
    public EquipPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "EquipPanel";
    }

    public override void Awake(GameObject go)
    {
        base.Awake(go);
        closeBut = transform.Find("Button").GetComponent<Button>();
        closeBut.onClick.AddListener(() => { tempInfoXie.SetActive(false); GameObject.Destroy(gameObject); });
        head = transform.Find("ImageEquip/Headgear");
        armor= transform.Find("ImageEquip/Armor");
        leftHand = transform.Find("ImageEquip/LH");
        rightHand = transform.Find("ImageEquip/RH");
        shoes = transform.Find("ImageEquip/Shoe");
        accessory = transform.Find("ImageEquip/Accessory");
        tempInfoXie = transform.Find("BagImageTip").gameObject;
        CCtransform = Resources.Load<Transform>("EquipImage");
        UIShiJian.OnInfoXie += CV;
    }
    public override void Refresh()
    {
        base.Refresh();
        for (int i = 0; i < Save.equipList.Count; i++)
        {
            Transform tempImage = GameObject.Instantiate(CCtransform);
            spriteSS = Resources.Load<Sprite>("IconA/" + Save.equipList[i].ID);
            switch (Save.equipList[i].Type)
            {
                case Equipment_Type.Null:
                    break;
                case Equipment_Type.Head_Gear:
                    ReadEquip(tempImage, "Headgear");
                    break;
                case Equipment_Type.Armor:
                    ReadEquip(tempImage, "Armor");
                    break;
                case Equipment_Type.Shoes:
                    ReadEquip(tempImage, "Shoe");
                    break;
                case Equipment_Type.Accessory:
                    ReadEquip(tempImage, "Accessory");
                    break;
                case Equipment_Type.Left_Hand:
                    ReadEquip(tempImage, "LH");
                    break;
                case Equipment_Type.Right_Hand:
                    ReadEquip(tempImage, "RH");
                    break;
                case Equipment_Type.Two_Hand:
                    ReadEquip(tempImage, "RH");
                    break;
            }
        }
    }
    /// <summary>
    /// 读取EquipList装备
    /// </summary>
    /// <param name="ABC"></param>
    void ReadEquip(Transform AA, string ABC)
    {
        AA.SetParent(transform.Find("ImageEquip/"+ ABC));
        AA.localPosition = Vector3.zero;
        AA.GetComponent<RectTransform>().localScale = Vector3.one;
        AA.GetComponent<Image>().sprite = spriteSS;
    }
    public void CV(string XX,Transform ZZ)
    {
        tempInfoXie.SetActive(true);
        //Vector3 v3 = new Vector3();
        //RectTransformUtility.ScreenPointToWorldPointInRectangle(TTUIRoot.Instance.root.GetComponent<RectTransform>(), Input.mousePosition, TTUIRoot.Instance.uiCamera, out v3);
        //tempInfoXie.transform.localPosition = v3;
        int xx = int.Parse(XX);
        tempInfoXie.transform.GetChild(0).GetComponent<Text>().text = DataMMM.GetInstence().GetItemById(xx).item_Name;
        tempInfoXie.transform.GetChild(1).GetComponent<Text>().text = DataMMM.GetInstence().GetItemById(xx).description;
        tempInfoXie.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
        {
            tempInfoXie.SetActive(false);
            ZZ.parent = null;
            ZZ.gameObject.SetActive(false);
            Save.TuoEquip(DataMMM.GetInstence().GetItemById(xx));
            TTUIPage.ShowPage<TipPanel>("脱下装备");
            
            //GameObject.Destroy(ZZ.gameObject);
            Save.Status();

        });
    }
}
