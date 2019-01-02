using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataMMM:MonoBehaviour
{


    /// <summary>
    /// 存放所有物品
    /// </summary>
    private List<Item> itemList = new List<Item>();
    /// <summary>
    /// 懒汉单例
    /// </summary>
    private static DataMMM instence = null;
    public static DataMMM GetInstence()
    {
        if (instence==null)
        {
            instence = new DataMMM();
        }
        return instence;
    }
    private DataMMM()
    {
        TextAsset ta = Resources.Load("swa/ItemData")as TextAsset;
        itemList = JsonConvert.DeserializeObject<List<Item>>(ta.text);
        Debug.Log(itemList.Count);
    }
    /// <summary>
    /// 根据id获取物品信息
    /// </summary>
    /// <returns></returns>
    public Item GetItemById(int _id)
    {

        return itemList.Find(x => x.item_ID == _id);
        //Item AA= itemList.Find((Item aa) =>
        //{

        //    if (aa.item_ID == _id)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //});
        //return AA ;
    }
    
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
/// <summary>
/// 物品类
/// </summary>
[System.Serializable]
public class Item
{
    public string item_Name = "Item Name";
    public string item_Type = "Item Type";
    [Multiline]
    public string description = "Description Here";
    public int item_ID;
    public string item_Img;//图片名字
    public string item_Effect;//特效名字
    public string item_Sfx;//音效名字
    public Equipment_Type equipment_Type;
    public int price;
    public int hp, mp, atk, def, spd, hit;
    public float criPercent, atkSpd, atkRange, moveSpd;
}
public enum Equipment_Type
{
    Null = 0, Head_Gear = 1, Armor = 2, Shoes = 3, Accessory = 4, Left_Hand = 5, Right_Hand = 6, Two_Hand = 7
}
