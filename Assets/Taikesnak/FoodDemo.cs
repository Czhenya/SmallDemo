using UnityEngine;

public class FoodDemo : MonoBehaviour {

    public GameObject SSFood; //食物的预制体
    public int xLimit = 30;   //游戏边界（最大高度，宽度）
    public int yLimit = 22;

	// Use this for initialization
	void Start () {
        //动态生成食物的时间
        InvokeRepeating("Food", 1, 8);
	}

    void Food()
    {
        //随机生成食物位置
        int x = Random.Range(-xLimit, xLimit);
        int y = Random.Range(-yLimit, yLimit);
        Instantiate(SSFood, new Vector2(x, y), Quaternion.identity);
    }
}
