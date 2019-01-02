using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CreatePlayerPanel : TTUIPage {
    public Button buttonP;
    public Button buttonN;
    public Button buttonOK;
    public Button buttonRandom;
    public InputField inputFieldName;//名字输入框

    public GameObject[] hero;  //your hero
    public GameObject buttonNext, buttonPrev; //button prev and button next
    private GameObject[] heroInstance; //use to keep hero gameobject when Instantiate
    int indexHero = 0;

    public string [] xings = {"赵","周","吴","郑","王","冯","陈","褚","卫","蒋","沈","韩","杨","朱","秦","尤","许","何","吕","施","张","孔","曹","严","华","金","魏","陶","姜"};
    public string [] mingz = {"狗蛋","板凳","铁蛋" };

    public void GetRandomName()
    {
        string xing = xings[Random.Range(0, xings.Length)];
        string ming = mingz[Random.Range(0, mingz.Length)];
        string xM = xing + ming;
        inputFieldName.text = xM;
    }

    public void ShaiZiRot()
    {

    }
    public CreatePlayerPanel():base(UIType.Normal,UIMode.DoNothing,UICollider.None)
    {
        uiPath = "CreatePlayerPanel";
    }

    public override void Awake(GameObject go)
    {
        base.Awake(go);
        //初始化可交互的UI
        buttonP = transform.Find("ButtonP").GetComponent<Button>();
        buttonN= transform.Find("ButtonN").GetComponent<Button>();
        buttonOK= transform.Find("ButtonOK").GetComponent<Button>();
        buttonRandom= transform.Find("ButtonRandom").GetComponent<Button>();
        inputFieldName= transform.Find("InputField").GetComponent<InputField>();

        hero = Resources.LoadAll<GameObject>("Player/HeroPreab");
        heroInstance = new GameObject[hero.Length]; //add array size equal hero size
        indexHero = 0; //set default selected hero
        SpawnHero(); //spawn hero to display current selected


        //check if hero is less than 1 , button next and prev will disappear
        if (hero.Length <= 1)
        {
            buttonN.gameObject.SetActive(false);
            buttonP.gameObject.SetActive(false);
        }
        //切换人物按钮事件
        buttonN.onClick.AddListener(() =>
        {
            indexHero++;
            if (indexHero >= heroInstance.Length)
            {
                indexHero = 0;
            }
            UpdateHero(indexHero);
        });
        buttonP.onClick.AddListener(() =>
        {
            indexHero--;
            if (indexHero <0)
            {
                indexHero = heroInstance.Length-1;
            }
            UpdateHero(indexHero);
        });

        //随机名字事件
        int count = 0;
        buttonRandom.onClick.AddListener(()=> {
            GetRandomName();
            int cc = count % 2;
            buttonRandom.transform.DORotate(Vector3.forward * 180*cc, 0.5f);
            count++;
            //buttonRandom.transform.DORotate(Vector3.forward * 180, 0.5f).SetLoops(2,LoopType.Incremental);
        });
        buttonOK.onClick.AddListener(ButtonOKClick);
    }
    //显示指定索引所对应的角色
    public void UpdateHero(int _indexHero)
    {
        for (int i = 0; i < hero.Length; i++)
        {
            //Show only select character
            if (i == _indexHero)
            {
                heroInstance[i].SetActive(true);
            }
            else
            {
                //Hide Other Character
                heroInstance[i].SetActive(false);
            }
        }
    }
    //生成所有，显示默认
    public void SpawnHero()
    {
        for (int i = 0; i < hero.Length; i++)
        {
            heroInstance[i] = (GameObject)GameObject.Instantiate(hero[i], new Vector3(0,-0.6f,0), transform.rotation);
        }

        UpdateHero(indexHero);
    }
    
    public void ButtonOKClick()
    {
        //SaveData
        PlayerPrefs.SetString("pName", inputFieldName.text);
        PlayerPrefs.SetInt("pSelect", indexHero);
        //切换场景
        SceneManager.LoadScene("Dreamdev Village");
    }
}
