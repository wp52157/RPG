using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;
using DG.Tweening;

public class TipPanel : TTUIPage {

    //Text textContent;
    CanvasGroup cG;
	public TipPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.Normal)
    {
        uiPath = "TipPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        //textContent = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        cG = transform.GetComponent<CanvasGroup>();
    }
    public override void Refresh()
    {
        base.Refresh();
        Text textContent = transform.GetChild(1).GetChild(0).GetComponent<Text>(); 
        textContent.text = data.ToString();
        cG.alpha = 1;
        cG.DOFade(0, 0.5f).SetDelay(0.5f).OnComplete(() => GameObject.Destroy(gameObject));
    }
}
