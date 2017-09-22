using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//开始界面
public class UIHome : MonoBehaviour {

	void Update () {
        //鼠标左键跳转场景
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
	}
}
