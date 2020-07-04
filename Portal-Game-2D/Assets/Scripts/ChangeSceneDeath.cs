﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneDeath : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(SwitchScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SwitchScene()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }


}
