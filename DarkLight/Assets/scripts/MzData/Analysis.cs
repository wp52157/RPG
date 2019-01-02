using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
/// <summary>
/// 解析数据
/// </summary>
public class Analysis : MonoBehaviour {

	void Awake () {
        EquipAnalysis();
        Save.Status();
        // 用户数据解析
        UserAnalysis();
        PlayerAnalysis();
        QuestAnalysis();
        // 物品数据解析
        GoodsAnalysis();
        
    }
    /// <summary>
    /// 用户数据解析
    /// </summary>
	void UserAnalysis()
    {
        TextAsset u = Resources.Load("Setting/UserJson") as TextAsset;
        if (!u)
        {
            return;
        }
        //Save.SaveUser = JsonMapper.ToObject<UserModelList>(u.text);
        //print(u.text);
        Save.goodList = JsonConvert.DeserializeObject<List<GoodsModel>>(u.text);
    }

    /// <summary>
    /// 物品数据解析
    /// </summary>
    void GoodsAnalysis()
    {
        TextAsset g = Resources.Load("Setting/GoodsList") as TextAsset;
        if (!g)
        {
            return;
        }
        //Save.SaveGoods = JsonMapper.ToObject<GoodsModelList>(g.text);
        //print(g.text);
        Save.UserList = JsonConvert.DeserializeObject<List<UserModel>>(g.text);
    }
    /// <summary>
    /// 装备数据解析
    /// </summary>
    void EquipAnalysis()
    {
        TextAsset t = Resources.Load("Setting/EquipJson") as TextAsset;
        if (!t)
        {
            return;
        }
        //Save.SaveGoods = JsonMapper.ToObject<GoodsModelList>(g.text);
        //print(g.text);
        Save.equipList = JsonConvert.DeserializeObject<List<EquipMode>>(t.text);
    }
    void QuestAnalysis()
    {
        TextAsset t = Resources.Load("Setting/QuestJson") as TextAsset;
        if (!t)
        {
            return;
        }
        //Save.SaveGoods = JsonMapper.ToObject<GoodsModelList>(g.text);
        //print(g.text);
        Save.questList = JsonConvert.DeserializeObject<List<QuestModel>>(t.text);
    }
    void PlayerAnalysis()
    {
        TextAsset m = Resources.Load("Setting/PlayerListJson") as TextAsset;
        if (!m)
        {
            return;
        }
        //Save.SaveGoods = JsonMapper.ToObject<GoodsModelList>(g.text);
        //print(g.text);
        Save.playerList = JsonConvert.DeserializeObject<List<QuestModel>>(m.text);
    }
}
