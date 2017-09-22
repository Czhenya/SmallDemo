using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {

    public float speed = 10f;    //初速度

    public WheelJoint2D leftWhell;  //车轮
    public WheelJoint2D rightWhell;

    public float phSpeed = 5.0f;

    public AudioSource carSound;
    public AudioClip runClip;  //两个状态的声音
    public AudioClip waitClip;

    private Transform myTrans;

    //JointMotor2D给车轮加动力的
    private JointMotor2D jmL,jmR;

    
    // Use this for initialization
	void Start () {
        //获取速度
        jmL = leftWhell.motor;
        jmR = rightWhell.motor;

        myTrans = this.transform;

    }
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    private void Move()
    {
        //获取输入
        float ax = Input.GetAxis("Horizontal");
        float ay = Input.GetAxis("Vertical");

        //当前速度
        jmL.motorSpeed = ax * speed;
        jmR.motorSpeed = ax * speed;
        //赋值
        leftWhell.motor = jmL;
        rightWhell.motor = jmR;

        if ( ax != 0 )
        {

            // AudioSource.PlayClipAtPoint(runClip, myTrans.position);
            carSound.clip = runClip;

            if(!carSound.isPlaying){
                carSound.Play();
            }

        }else  //停下就不播放声音
        {
            carSound.Stop();
        }

        if(ay != 0)
        {
            //左右平衡赛车的角度
            myTrans.Rotate(myTrans.forward, ay * phSpeed);
        }
    }
}