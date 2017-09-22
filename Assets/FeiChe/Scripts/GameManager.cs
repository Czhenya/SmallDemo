using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //单例模式
    public static GameManager Instance;

    public Text scoreText;  //当前显示分数UI

    public float groScore = 140;  //增加分数

    private float curScore = 0;  //当前分数

    private float changeSpeed = 3;  //加分变化速度

    void Awake()
    {  //单例赋值
        Instance = this;
    }

    void Start()
    {
        //获取Text组件
        scoreText = GetComponent<Text>();
    }

    /// <summary>
    /// 增加分数的方法
    /// </summary>
    public void AddScore()
    {
        float a = curScore + groScore;
       
        StartCoroutine(Add(a));
    }


    // 协程增加分数，慢慢增加
    IEnumerator Add(float tonum)
    {
        //Debug.Log(tonum);
        while (curScore < tonum)
        {
           //插值的形式，增加分数
            curScore = Mathf.Lerp(curScore, tonum, changeSpeed * Time.deltaTime);

            scoreText.text = ((int)curScore).ToString();

            yield return 0;
        }       
        
    }
}
