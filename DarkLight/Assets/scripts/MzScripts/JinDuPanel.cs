using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;


public class JinDuPanel : TTUIPage {

    GameObject BN;
    Button clo;
    //List<Button> butList = new List<Button>();
    public JinDuPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "JinDuPanel";
    }
    public override void Active()
    {
        base.Active();
        
        BN = Resources.Load("JinDuItem") as GameObject;
        clo = transform.Find("Button").GetComponent<Button>();
        clo.onClick.AddListener(() => 
        {
            GameObject.Destroy(gameObject);
            
            
        });
        //NpcForge.OnWancheng += VB;
    }
    public override void Refresh()
    {
        base.Refresh();
        for (int i = 0; i < Save.playerList.Count; i++)
        {
            Button finBut;
            QuestModel bb = Save.playerList[i];
            GameObject tss = GameObject.Instantiate(BN);
            tss.transform.SetParent(transform.GetChild(i));
            tss.transform.localPosition = Vector3.zero;
            tss.transform.GetComponent<RectTransform>().localScale = Vector3.one;
            tss.transform.Find("Text").GetComponent<Text>().text = Save.playerList[i].questId.ToString();
            tss.transform.Find("TextDec").GetComponent<Text>().text = Save.playerList[i].questName.ToString();
            tss.transform.Find("TextJInDu").GetComponent<Text>().text = Save.playerList[i].nowNum.ToString()+"/"+ Save.playerList[i].finishProgress.ToString();
            //finBut = tss.transform.GetChild(3).GetComponent<Button>();
            //finBut.onClick.AddListener(() =>
            //{
            //    Save.playerList.Remove(bb);
            //    Save.SavePlayerList();
            //    GameObject.Destroy(gameObject);
            //    TTUIPage.ShowPage<TipPanel>("恭喜完成任务");
            //    bb.nowNum = 0;
            //    Save.SaveQuest();

            //});
            //butList.Add(finBut);
            if (tss.transform.parent.childCount > 1)
            {
                tss.transform.parent.GetChild(0).parent=null;
            }
            
        }
    }
    //public void VB(QuestModel qu)
    //{
    //    for (int i = 0; i < butList.Count; i++)
    //    {
    //        if (qu.questId.ToString()==butList[i].transform.parent.GetChild(0).GetComponent<Text>().text)
    //        {
    //            //butList[i].gameObject.SetActive(true);
    //            //Debug.Log(butList[i]);
                
    //        }
    //    }
    //}
}
