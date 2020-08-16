using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHead : MonoBehaviour
{
    [SerializeField] private Image imageFullHead;
    [SerializeField] private Image imageEmptyHead;


    private void Start()
    {
        Active();
    }

    public void Active()
    {
        imageFullHead.enabled = true;
        imageEmptyHead.enabled = false;
    }

    public void DeActive()
    {
        imageFullHead.enabled = false;
        imageEmptyHead.enabled = true;
    }
}
