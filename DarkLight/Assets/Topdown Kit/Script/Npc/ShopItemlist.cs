/// <summary>
/// Npc shop.
/// This script use to create a shop to sell item
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShopItemlist : MonoBehaviour {
	
	public List<int> itemID = new List<int>();
    //public Button ganTanHao;

    public static event Action<bool,List<int>> OnNpcTiger;//根Player进出触发器的事件
    
	void Start()
	{
		if(this.gameObject.tag == "Untagged")
			this.gameObject.tag = "Npc_Shop";
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            //ganTanHao.gameObject.SetActive(true);
            //ganTanHao.onClick.AddListener(商店.打开（item.id))
            //点击按钮
            //打开商店
            //设置商店里面的物品
            if (OnNpcTiger != null)
            {
                OnNpcTiger(true, itemID);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (OnNpcTiger != null)
            {
                OnNpcTiger(false, null);
            }
        }
    }
}


