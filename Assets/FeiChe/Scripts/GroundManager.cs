using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {
    //单例模式的引用
    public static GroundManager Instance;
    //所有的地形
    public List<GameObject> allGroundlist;
    //当前地形的数组
    public GameObject[] curGroundarr = new GameObject[3];

	// Use this for initialization
	void Awake () {
        //单例
        Instance = this;

    }
	
	
    //检测主角方法
    public void ChangePlayer(Vector3 playerPos,Vector3 groundPos)
    {
        //检测什么方向开车
        CreateGround(playerPos.x < groundPos.x);
    }

    //无限地形逻辑
    public void CreateGround(bool p_Isright)
    {
        //随机创建地形，
        //int a = Random.Range(0, allGroundlist.Count - 1);
        GameObject tempGround = Instantiate(allGroundlist[Random.Range(0, allGroundlist.Count - 1)]);
        if (p_Isright)  //正方向开车
        {
            //创建出来的地形位置
            Vector3 tempPos = curGroundarr[2].transform.position;
            tempPos.x += 20.48f;    //两个地形之间的差值
            tempGround.transform.position = tempPos; 

            //销毁最早走过的地形
            Destroy(curGroundarr[0].gameObject);
            //2 -> 1 .. 1 -> 0 ,0 ->新生成 三个地形之间的转换 
            curGroundarr[0] = curGroundarr[1];
            curGroundarr[1] = curGroundarr[2];
            curGroundarr[2] = tempGround;
        }
        else  //反方向  ,与上面逻辑想返
        {
            Vector3 tempPos = curGroundarr[0].transform.position;
            tempPos.x -= 20.48f;    
            tempGround.transform.position = tempPos;

            Destroy(curGroundarr[2].gameObject);

            curGroundarr[2] = curGroundarr[1];
            curGroundarr[1] = curGroundarr[0];

            curGroundarr[0] = tempGround;
        }
    }
}
