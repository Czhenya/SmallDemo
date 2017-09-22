using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


//蛇的移动脚本
public class Move : MonoBehaviour {
    List<Transform> Bodylist = new List<Transform>();

    public GameObject Body;  //吃到东西添加在后面的物体
    public bool ISwith = false;  //是否吃到

    public float velocitytime = 0.5f; //初始速度

    Vector2 direction = Vector2.up; //初始方向，
	
    // Use this for initialization
	void Start () {
        //第一次调用方法是程序开始0.5秒过后，之后每隔velocitytime秒之后调用一次
        InvokeRepeating("MoveSnake",0.5f, velocitytime);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }

    }
#region  移动&&核心算法
    void MoveSnake()
    {
        //每执行一次获取一次头部的位置
        Vector3 vpos = transform.position;
        //执行移动
        transform.Translate(direction);

        if (ISwith) //吃到食物
        {
           //实例化吃到的食物
            GameObject Bodyper =(GameObject)Instantiate(Body, vpos, Quaternion.identity);
            //添加到list的头部
            Bodylist.Insert(0, Bodyper.transform);
            ISwith = false;
        }

        //==============核心算法================
        if (Bodylist.Count>0)
        {
            //最后一个移动到第一个的位置
            Bodylist.Last().position = vpos;  
            //list里面的元素 进行交换位置，，最后一个物体添加到list的最前面
            Bodylist.Insert(0, Bodylist.Last());
            //移除最后一个，，（因为他已经被加入到第一个的位置了）
            Bodylist.RemoveAt(Bodylist.Count - 1);
        }
        //======================================
    }
    #endregion

    /// <summary>
    /// 触发检测
    /// </summary>
    /// <param name="other">碰到带物体的名字</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food") //使用标签
        {
            //销毁食物预制体
            Destroy(other.gameObject);
            ISwith = true;
        }
        else  //碰到除了food的物体，重新开始游戏
        {
            SceneManager.LoadScene(0);
        }
    }

}
