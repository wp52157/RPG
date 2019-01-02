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

    public static event Action<bool,List<int>> OnNpcTiger;//��Player�������������¼�
    
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
            //ganTanHao.onClick.AddListener(�̵�.�򿪣�item.id))
            //�����ť
            //���̵�
            //�����̵��������Ʒ
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


