using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TinyTeam.UI;

public class UIShiJian : MonoBehaviour,IPointerEnterHandler,IPointerClickHandler{
    string ss;
    Button buyBut;
    public static Action<string> OnInfo;
    public static Action<string> OnInfoUse;
    public static Action<string,Transform> OnInfoXie;
    //商店
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.transform.tag == "ShiJian")
        {
            OnInfo(eventData.pointerEnter.transform.GetComponent<Image>().sprite.name);
            int AA = int.Parse(eventData.pointerEnter.transform.GetComponent<Image>().sprite.name);
            Item item = DataMMM.GetInstence().GetItemById(AA);
            buyBut = transform.parent.GetChild(1).GetComponent<Button>();
            buyBut.onClick.AddListener(() => { Save.BuyItem(item);TTUIPage.ShowPage<TipPanel>("购买成功"); SoundManager.instance.PlayingSound("Accept_Quest"); });
        }
    }
    //背包
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerEnter.transform.tag == "SJ")
        {
            OnInfoUse(eventData.pointerEnter.transform.GetComponent<Image>().sprite.name);
        }
        if (eventData.pointerEnter.transform.tag == "sj")
        {
            OnInfoXie(eventData.pointerEnter.transform.GetComponent<Image>().sprite.name, eventData.pointerEnter.transform);
        }
    }

    
}
