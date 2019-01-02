using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;

public class MainPanel : TTUIPage
{

    private Button butSta, butEqu, butBag, butSki, butTishi, butDuanZao,butDaGuai, butDaGuai1, butDaGuai2;
    private List<int> tempList = new List<int>();//记录传过来物品数据list
    public MainPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "MainPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        butSta = transform.Find("StatusButton").GetComponent<Button>();
        butEqu = transform.Find("EquipButton").GetComponent<Button>();
        butBag = transform.Find("BagButton").GetComponent<Button>();
        butSki = transform.Find("SkillButton").GetComponent<Button>();
        butTishi = transform.Find("ButtonTishi").GetComponent<Button>();
        butTishi.gameObject.SetActive(false);
        butDuanZao = transform.Find("ButtonDuanZ").GetComponent<Button>();
        butDaGuai = transform.GetChild(6).GetComponent<Button>();
        butDaGuai1 = transform.GetChild(7).GetComponent<Button>();
        butDaGuai2 = transform.GetChild(8).GetComponent<Button>();
        ShopItemlist.OnNpcTiger += ShowTiShi;
        NpcForge.OnForge +=ShowDuanZao;
        butTishi.onClick.AddListener(() => TTUIPage.ShowPage<ShopPanel>(tempList));
        butBag.onClick.AddListener(() => TTUIPage.ShowPage<BagPanel>());
        butEqu.onClick.AddListener(() => TTUIPage.ShowPage<EquipPanel>());
        butSta.onClick.AddListener(() => TTUIPage.ShowPage<StatusPanel>());
        butDuanZao.onClick.AddListener(() => TTUIPage.ShowPage<DuanZaoPanel>());
        butDaGuai.onClick.AddListener(() => 
        {
            Save.GetQuest(1).nowNum = Save.GetQuest(1).nowNum + 1;
            if (Save.GetQuest(1).nowNum>5)
            {
                Save.GetQuest(1).nowNum = 5;
            }
            
            Debug.Log("打盗贼");
        });
        butDaGuai1.onClick.AddListener(() =>
        {
            Save.GetQuest(2).nowNum = Save.GetQuest(2).nowNum + 1;
            if (Save.GetQuest(2).nowNum > 3)
            {
                Save.GetQuest(2).nowNum = 3;
            }

            Debug.Log("打哥布林");
        });
        butDaGuai2.onClick.AddListener(() =>
        {
            Save.GetQuest(3).nowNum = Save.GetQuest(3).nowNum + 1;
            if (Save.GetQuest(3).nowNum > 2)
            {
                Save.GetQuest(3).nowNum = 2;
            }

            Debug.Log("打采花贼");
        });
    }
    /// <summary>
    /// 是否显示提示按钮
    /// </summary>
    /// <param name="isshow"></param>
    /// <param name="list">npc出入的物品列表</param>
    public void ShowTiShi(bool isshow, List<int> list)
    {

        tempList = list;
        butTishi.gameObject.SetActive(isshow);
        if (!isshow)
        {
            if (!TTUIPage.allPages.ContainsKey("ShopPanel"))
            {
                return;
            }
            TTUIPage.ClosePage<ShopPanel>();
            //解决TTUIPage中Awake只在生成的时候只执行一次
            Transform TT = transform.parent.GetChild(2).GetChild(0).GetChild(0).GetChild(0);
            //销毁子物体
            for (int i = TT.childCount - 1; i >= 0; i--)
            {
                Transform cc = TT.GetChild(i);
                cc.parent = null;
                GameObject.Destroy(cc.gameObject);

            }
            transform.parent.GetChild(2).GetChild(1).gameObject.SetActive(false);
            ShopPanel.dicWuping.Clear();
        }
    }
    public void ShowDuanZao(bool isshow)
    {
        butDuanZao.gameObject.SetActive(isshow);
        
    }
}

