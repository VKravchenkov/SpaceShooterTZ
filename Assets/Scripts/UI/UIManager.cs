using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private List<BaseView> baseViews;

    public static List<BaseView> BaseViews => Instance.baseViews;

    protected override void Awake()
    {
        base.Awake();

    }

    public static void Show(BaseView view)
    {
        BaseViews.Find(item => item == view).gameObject.SetActive(true);
        // view.gameObject.SetActive(true);
    }

    public static void Close(BaseView view)
    {
        BaseViews.Find(item => item == view).gameObject.SetActive(false);
        //view.gameObject.SetActive(false);
    }
}
