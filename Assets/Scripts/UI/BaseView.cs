using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    public bool ShowAtStart = false;

    private void Start()
    {
        gameObject.SetActive(ShowAtStart);
    }

    public void Show() => UIManager.Show(this);

    public void Close() => UIManager.Close(this);

}
