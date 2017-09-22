using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelConterl : MonoBehaviour {

    //切换到开始场景
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
