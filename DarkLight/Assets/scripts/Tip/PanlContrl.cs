using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TinyTeam.UI;

public class PanlContrl : MonoBehaviour {

    public Camera cam;
    public Transform targetPoint;//移动目标点
    


    // Use this for initialization
    void Start () {
        //cube.transform.position = Vector3.MoveTowards(Vector3.zero, Vector3.forward*10,1);//起点，终点，移动多少（不能超过终点）
        cam.transform.DOMove(targetPoint.position, 5);
        TTUIPage.ShowPage<TitPanel>();
    }
	
	// Update is called once per frame
	void Update () {
        //cam.transform.position= Vector3.MoveTowards(transform.position, targetPoint.position, 3 * Time.deltaTime);
        //if (Input.anyKeyDown && Time.time>5)
        //{
        //    //SceneManager.LoadScene("My Character Creation");
        //    TitPanel.buttonNew.gameObject.SetActive(true);
        //    TitPanel.buttonLoad.gameObject.SetActive(true);
        //    TitPanel.imageAnyKey.gameObject.SetActive(false);
        //}
    }
}
