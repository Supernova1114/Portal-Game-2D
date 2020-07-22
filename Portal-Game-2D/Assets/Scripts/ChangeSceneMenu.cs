using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneMenu : MonoBehaviour
{
    public Button button;
    public Button buttonExit;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(SwitchScene);
        buttonExit.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(sceneName: "Main");
    }

    void Exit() 
    {
        Application.Quit(0);
    }

    
}
