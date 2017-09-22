using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDemo : MonoBehaviour {

    //摄像机跟随速度
    public float followSpeed = 5;
    //自己的transform
    private Transform myTrans;
    //主角的
    private Transform playerTrans;
	// Use this for initialization
	void Start () {
        //获取位置
        myTrans = this.transform;

        playerTrans = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        //获取主角位置
        Vector3 playerPos = playerTrans.position;
        //把z轴和摄像机对齐，
        playerPos.z = myTrans.position.z;
        //用插值运算，，
        myTrans.position = Vector3.Lerp(myTrans.position, playerPos, followSpeed * Time.deltaTime);

    }
}
