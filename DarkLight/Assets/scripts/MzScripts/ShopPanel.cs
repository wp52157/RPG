using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;


public class ShopPanel : TTUIPage {

    private Image imageItem;
    GameObject tempObj;
    Transform tt;
    public static Dictionary<string, Item> dicWuping = new Dictionary<string, Item>();
    GameObject infoImage;
    Button buyBut;
    //List <int> numLis=new List<int>();
    public ShopPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "ShopPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go); 
        tempObj = Resources.Load("ImageItem")as GameObject;

    }

    public override void Refresh()
    {
        Item tempItem=new Item();
        List<int> numLis = new List<int>();
        numLis = (List<int>)data; 
        Debug.Log(numLis.Count);
        //商店中物品生成
        for (int i = 0; i < numLis.Count; i++)
        {
            tempItem = DataMMM.GetInstence().GetItemById(numLis[i]);
            Sprite ss= Resources.Load<Sprite>("IconA/" + numLis[i]);
            GameObject obj = GameObject.Instantiate(tempObj);
            obj.transform.SetParent(transform.GetChild(0).GetChild(0).GetChild(0));
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            obj.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = ss;
            obj.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = tempItem.item_Name;
            obj.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = tempItem.item_Type;
            obj.transform.GetChild(0).GetChild(4).GetComponent<Text>().text = tempItem.price.ToString();
            dicWuping.Add(tempItem.item_ID.ToString(), tempItem);
            //buyBut = obj.transform.GetChild(0).GetChild(1).GetComponent<Button>();
            //buyBut.onClick.AddListener(() => { Save.BuyItem(tempItem);Debug.Log("ABC"); });
        }
        UIShiJian.OnInfo += Dx;
        infoImage = transform.GetChild(1).gameObject;
        Debug.Log(infoImage.name);
    }
    public void Dx(string AA)
    {
        if (dicWuping.ContainsKey(AA))
        {
            Debug.Log("ok");
            infoImage.gameObject.SetActive(true);
            infoImage.transform.GetChild(0).GetComponent<Text>().text = AA;
            infoImage.transform.GetChild(1).GetComponent<Text>().text = dicWuping[AA].item_Type;
            infoImage.transform.GetChild(2).GetComponent<Text>().text = dicWuping[AA].description;
        }
        
    }
    
}
