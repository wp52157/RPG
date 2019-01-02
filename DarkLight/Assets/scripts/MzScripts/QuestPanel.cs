using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;

public class QuestPanel : TTUIPage {

    Transform imageDuiHua;
    Button close;
    public static Transform imageLieBiao;
    GameObject TS;
	public QuestPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "QuestPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        imageDuiHua = transform.Find("ImageDuiHua");
        imageLieBiao = transform.Find("ImageLieBiao");
        TS = Resources.Load("QusetItem") as GameObject;
        close = transform.Find("ImageLieBiao/Button").GetComponent<Button>();
        close.onClick.AddListener(() => GameObject.Destroy(gameObject));
    }
    public override void Refresh()
    {
        base.Refresh();
        
        for (int i = 0; i < Save.questList.Count; i++)
        {
            QuestModel ss = Save.questList[i];
            GameObject ts = GameObject.Instantiate(TS);
            ts.transform.SetParent(transform.Find("ImageLieBiao").GetChild(i));
            ts.transform.localPosition = Vector3.zero;
            ts.transform.GetComponent<RectTransform>().localScale = Vector3.one;
            ts.transform.Find("Text").GetComponent<Text>().text = Save.questList[i].questId.ToString();
            ts.transform.Find("TextDec").GetComponent<Text>().text = Save.questList[i].questName;
            Button jieShou = ts.transform.Find("Button").GetComponent<Button>();
            jieShou.onClick.AddListener(() =>
            {
                Save.AddQuest(ss);
                Save.SavePlayerList();
                Debug.Log(ss.questId);
                ss.nowStatus = 1;
                Save.SaveQuest();
                jieShou .transform.GetChild(0).GetComponent<Text>().text = "进行中";
                jieShou .onClick.RemoveAllListeners();
            });
        }
    }
}
