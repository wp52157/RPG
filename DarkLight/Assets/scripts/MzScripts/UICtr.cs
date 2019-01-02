using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtr : MonoBehaviour {
    public GameObject sta, equ, bag, ski;
    bool isSta = true, isEqu = true, isBag = true, isSki = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Onsta()
    {
        if (isSta)
        {
            sta.SetActive(true);
        }
        else
        {
            sta.SetActive(false);
        }
        isSta = !isSta;
    }
    public void Onequ()
    {
        if (isEqu)
        {
            equ.SetActive(true);
        }
        else
        {
            equ.SetActive(false);
        }
        isEqu = !isEqu;
    }
    public void Onbag()
    {
        if (isBag)
        {
            bag.SetActive(true);
        }
        else
        {
            bag.SetActive(false);
        }
        isBag = !isBag;
    }
    public void Onski()
    {
        if (isSki)
        {
            ski.SetActive(true);
        }
        else
        {
            ski.SetActive(false);
        }
        isSki = !isSki;
    }
}
