using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDemo : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GroundManager.Instance.ChangePlayer(collision.transform.position, transform.parent.position);
            //调用增加分数方法
            GameManager.Instance.AddScore();
        }
    }

}
