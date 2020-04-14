using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private GameObject _panel;
    void Start()
    {
        _panel = gameObject;
        EnablePanel(false);
    }

    void Update()                                                                              
    {
        
    }

    public void EnablePanel(bool isEnable)
    {
        _panel.SetActive(isEnable);
    }
}
