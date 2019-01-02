using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TinyTeam.UI;
using UnityEngine.UI;

public class LoadingScenePanel : TTUIPage {

    public RawImage rawImage;
    public static Slider slider;
    public static Text text;

    public LoadingScenePanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "LoadingPanel";
    }

    public override void Awake(GameObject go)
    {
        rawImage = transform.Find("RawImage").GetComponent<RawImage>();
        slider = transform.Find("Slider").GetComponent<Slider>();
        text = transform.Find("Text").GetComponent<Text>();
        text.text = slider.value.ToString();
    }
}
