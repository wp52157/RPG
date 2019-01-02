using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitPanel : TTUIPage{

    public Image imageTilte;
    //public static Image imageAnyKey;
    public Image imageWite;
    public static Button buttonNew;
    public static Button buttonLoad;

	public TitPanel():base(UIType.Normal,UIMode.DoNothing,UICollider.None)
    {
        uiPath = "TitPanel";
    }
    public override void Awake(GameObject go)
    {
        //imageAnyKey = transform.Find("ImageAnyKey").GetComponent<Image>();
        imageTilte = transform.Find("ImageTilte").GetComponent<Image>();
        imageWite = transform.Find("ImageBG").GetComponent<Image>();
        buttonNew = transform.Find("ButtonNew").GetComponent<Button>();
        buttonLoad = transform.Find("ButtonLoad").GetComponent<Button>();

        buttonNew.gameObject.SetActive(false);
        buttonLoad.gameObject.SetActive(false);
        imageTilte.color = new Color(1, 1, 1, 0);
        //imageAnyKey.gameObject.SetActive(false);
        imageWite.DOFade(0, 2f).SetDelay(0.5f);
        imageTilte.DOFade(1, 1).SetDelay(4);
        buttonNew.GetComponent<Image>().DOFade(1, 1).SetDelay(5).OnStart(()=> buttonNew.gameObject.SetActive(true));
        buttonLoad.GetComponent<Image>().DOFade(1, 1).SetDelay(5).OnStart(()=> buttonLoad.gameObject.SetActive(true));

        buttonNew.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Loading");
            GameCtrl.Instance.nextSceneName = "My Character Creation";
        });
        buttonLoad.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Loading");
            GameCtrl.Instance.nextSceneName = "Dreamdev Village";
        });

        //GameObject.Destroy(buttonLoad.GetComponent<Button>());  销毁组件
        //GameObject.Destroy(gameObject.GetComponent<Button>());


        //判断是否有存档
        if (!PlayerPrefs.HasKey("SaveData"))
        {
            buttonLoad.interactable = false;
        }
    }
}
