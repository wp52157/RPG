using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TinyTeam.UI;

public class NpcForge : MonoBehaviour {

    public static event Action<bool> OnForge;
    public static event Action<QuestModel> OnWancheng;
    bool IsOpen = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
             QuestPanel.imageLieBiao.gameObject.SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.P))
        {

            TTUIPage.ShowPage<JinDuPanel>();

        }
        if (Save.playerList.Count==0)
        {
            return;
        }
        for (int i = 0; i < Save.playerList.Count; i++)
        {
            if (Save.playerList[i].nowNum== Save.playerList[i].finishProgress)
            {
                //JinDuPanel.finBut.gameObject.SetActive(true);
                //OnWancheng(Save.playerList[i]);
                Save.playerList.Remove(Save.playerList[i]);
                TTUIPage.ShowPage<TipPanel>("完成任务");
               
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="Player")
        {
            TTUIPage.ShowPage<QuestPanel>();
            if (OnForge!=null)
            {
                OnForge(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (OnForge != null)
            {
                OnForge(false);
            }
        }
    }
}
