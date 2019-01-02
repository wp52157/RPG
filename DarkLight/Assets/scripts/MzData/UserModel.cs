using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEditor;



/// <summary>
/// 任务属性值
/// </summary>
public class StatusModel
{
    public static int Hp;
    public static int Mp;
    public static int Atk;
    public static int Def;
    public static int Speed;
    public static int Hit;
}
public class UserModel {
    /*  {"UserList":[{"Hp":80,"MaxHp":120,"Attack":35,"Speed":25}]}  */
    public int Hp;
    public int MaxHp;
    public int Attack;
    public int Speed;
}
public  class UserModelList
{
    //public List<UserModel> UserList = new List<UserModel>();
}
/// <summary>
/// 商品信息
/// </summary>
public class GoodsModel 
{
    public int Id;
    //public string Name;
    //public string Nature;//图片种类(图片名)
    //public string Function;
    //public int Value;//值
    public int Num;//数量
}
public class EquipMode
{
    public int ID;
    public Equipment_Type Type;
    public string Dec;
}
/// <summary>
/// 任务列表
/// </summary>
public class QuestModel
{
    public int questId;
    public string questName ;//任务名称
    //public string description;//任务描述
    public int finishProgress;//任务目标数量
    public int nowNum;
    public int nowStatus;
    //public int rewardCash = 100;//奖励金钱
    //public int rewardExp = 100;//奖励经验
    //public int[] rewardItemID;//奖励物品
    //public int[] rewardEquipmentID;//奖励装备
}

public class Save
{
    //public static UserModelList SaveUser;
    //public static GoodsModelList SaveGoods;

    public static List<QuestModel> playerList = new List<QuestModel>();

    public static List<QuestModel> questList = new List<QuestModel>();
    /// <summary>
    /// 锻造List
    /// </summary>
    public static List<GoodsModel> duanList = new List<GoodsModel>();
        /// <summary>
        ///装备list
        /// </summary>
    public static List<EquipMode> equipList = new List<EquipMode>();
    /// <summary>
    /// 背包里的物品
    /// </summary>
    public static List<GoodsModel> goodList=new List<GoodsModel>();
    /// <summary>
    /// 用户列表
    /// </summary>
    public static List<UserModel> UserList;
    /// <summary>
    /// 属性值
    /// </summary>
    public static List<StatusModel> StatusList=new List<StatusModel>();

    public static QuestModel GetQuest(int i)
    {
        return playerList.Find(x => x.questId == i);
    }
    /// <summary>
    /// 接任务
    /// </summary>
    /// <param name="bb"></param>
    public static void AddQuest(QuestModel bb)
    {
        playerList.Add(bb);
    }
    /// <summary>
    /// 加入锻造
    /// </summary>
    /// <param name="MM"></param>
    public static void JiaRuDZ(Item MM)
    {
        if (duanList.Count>=2)
        {
            return;
        }
        GoodsModel dm = goodList.Find(x => x.Id == MM.item_ID);
        dm.Num=dm.Num-1;
        if (dm.Num <= 0)
        {
            goodList.Remove(dm);
        }
        SaveGoodS();
        duanList.Add(new GoodsModel() {Id=MM.item_ID,Num=1 });
    }
    /// <summary>
    /// 锻造
    /// </summary>
    /// <param name="xx"></param>
    /// <param name="cc"></param>
    /// <param name="PP"></param>
    public static void DuanZao(GoodsModel xx,GoodsModel cc, GoodsModel PP)
    {
        duanList.Remove(xx);
        duanList.Remove(cc);
        goodList.Add(PP);
        SaveGoodS();
    }
    /// <summary>
    /// 购买物品
    /// </summary>
    /// <param name="_item"></param>
    public static void BuyItem(Item _item)
    {
        if (goodList == null)
        {
            goodList = new List<GoodsModel>();
        }
        GoodsModel gm = goodList.Find(x => x.Id == _item.item_ID);
        if(gm!=null)
        {
            gm.Num =gm.Num + 1;
        }
        else
        {
            goodList.Add(new GoodsModel() { Id = _item.item_ID, Num = 1 });
        }
        SaveGoodS();
    }
    /// <summary>
    /// 使用物品
    /// </summary>
    /// <param name="oo"></param>
    public static void ShiYongItem(Item oo)
    {
        GoodsModel gmm = goodList.Find(x => x.Id == oo.item_ID);
        gmm.Num--;
        if (gmm.Num<=0)
        {
            goodList.Remove(gmm);
        }
        SaveGoodS();
    }
    /// <summary>
    /// 判断是否可以穿装备
    /// </summary>
    public static bool IsSaveOk(Item PP)
    {
        if (equipList==null)
        {
            return true;
        }
        EquipMode gmmmP = equipList.Find(s => s.Type == Equipment_Type.Two_Hand);
        if (gmmmP!=null&&(PP.equipment_Type==Equipment_Type.Right_Hand|| PP.equipment_Type == Equipment_Type.Left_Hand))
        {
            return false;
        }
        EquipMode gmmm = equipList.Find(s => s.Type == PP.equipment_Type);
        if (gmmm==null)
        {
            return true;
        }
        else return false;
    }
    /// <summary>
    /// 脱装备
    /// </summary>
    /// <param name="LL"></param>
    public static void TuoEquip(Item LL)
    {
        EquipMode cm = equipList.Find(x => x.ID == LL.item_ID);
        equipList.Remove(cm);
        GoodsModel cmm = goodList.Find(h => h.Id == LL.item_ID);
        if (cmm!=null)
        {
            cmm.Num=cmm.Num+1;
        }
        else
        {
            goodList.Add(new GoodsModel() { Id = LL.item_ID, Num = 1 });
        }
    }
    /// <summary>
    /// 获取装备属性
    /// </summary>
    public static void Status()
    {
        Reset();
        int THp=0, TMp = 0, TAtk = 0, TDef = 0, TSpeed = 0, THit = 0;
        for (int i = 0; i < equipList.Count; i++)
        {
            THp += DataMMM.GetInstence().GetItemById(equipList[i].ID).hp;
            TMp += DataMMM.GetInstence().GetItemById(equipList[i].ID).mp;
            TAtk += DataMMM.GetInstence().GetItemById(equipList[i].ID).atk;
            TDef += DataMMM.GetInstence().GetItemById(equipList[i].ID).def;
            TSpeed += DataMMM.GetInstence().GetItemById(equipList[i].ID).spd;
            THit += DataMMM.GetInstence().GetItemById(equipList[i].ID).hit;
        }
        StatusModel.Hp = THp;
        StatusModel.Mp = TMp;
        StatusModel.Atk = TAtk;
        StatusModel.Def = TDef;
        StatusModel.Speed = TSpeed;
        StatusModel.Hit = THit;
    }
    /// <summary>
    /// 重置装备属性
    /// </summary>
    public static void Reset()
    {
        StatusModel.Hp = 0;
        StatusModel.Mp = 0;
        StatusModel.Atk = 0;
        StatusModel.Def = 0;
        StatusModel.Speed = 0;
        StatusModel.Hit = 0;
    }
    public static void SaveGoodS()
    {
        
        string path = Application.dataPath + @"/Resources/Setting/UserJson.txt";
        using (StreamWriter sw=new StreamWriter(path))
        {
            string json1 = JsonConvert.SerializeObject(goodList);
            sw.Write(json1);
        }
        //FileInfo fi = new FileInfo(path);
        //StreamWriter sw = fi.CreateText();
        //string json1 = JsonConvert.SerializeObject(goodList);
        //sw.Write(json1);
        //sw.Close();
        //sw.Dispose();
        AssetDatabase.Refresh();
    }
    public static void SaveEquip()
    {
        string path = Application.dataPath + @"/Resources/Setting/EquipJson.txt";
        using (StreamWriter sww = new StreamWriter(path))
        {
            string json11 = JsonConvert.SerializeObject(equipList);
            sww.Write(json11);
        }
        //FileInfo fi = new FileInfo(path);
        //StreamWriter sw = fi.CreateText();
        //string json1 = JsonConvert.SerializeObject(goodList);
        //sw.Write(json1);
        //sw.Close();
        //sw.Dispose();
        AssetDatabase.Refresh();
    }


    public static void SaveQuest()
    {
        //questList.Add(new QuestModel() { questId = 1, questName = "杀5个盗贼", finishProgress = 5, nowNum = 0, nowStatus = 0 });
        //questList.Add(new QuestModel() { questId = 2, questName = "杀3个哥布林", finishProgress = 3, nowNum = 0, nowStatus = 0 });
        //questList.Add(new QuestModel() { questId = 3, questName = "杀2个采花贼", finishProgress = 2, nowNum = 0, nowStatus = 0 });
        string path = Application.dataPath + @"/Resources/Setting/QuestJson.txt";
        using (StreamWriter sw = new StreamWriter(path))
        {
            string json1 = JsonConvert.SerializeObject(questList);
            sw.Write(json1);
        }
        AssetDatabase.Refresh();
    }
    public static void SavePlayerList()
    {
        string path = Application.dataPath + @"/Resources/Setting/PlayerListJson.txt";
        using (StreamWriter sw = new StreamWriter(path))
        {
            string json1 = JsonConvert.SerializeObject(playerList);
            sw.Write(json1);
        }
        AssetDatabase.Refresh();
    }
}



