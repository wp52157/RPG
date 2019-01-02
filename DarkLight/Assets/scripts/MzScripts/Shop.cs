using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public GameObject shop;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("11111111");
        if (other.transform.tag=="Player")
        {
            shop.SetActive(true);
            Debug.Log("222222");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            shop.SetActive(false);
        }
    }
}
