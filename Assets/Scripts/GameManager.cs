using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<Bird> birds;
    public List<Pig> pig;

    public static GameManager _instance;

    private Vector3 originPos; //初始化的位置

    private void Awake() {
        _instance = this;
        if (birds.Count > 0) {
            originPos = birds[0].transform.position;
        }
    }

    private void Start() {
        Initialized();
    }
       
    /// <summary>
    /// 初始化小鸟
    /// </summary>
    private void Initialized() {
        for (int i = 0; i < birds.Count; i++) {
            if (i == 0)
            {
                birds[i].transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }

    /// <summary>
    /// 判定游戏逻辑
    /// </summary>
    public void NextBird() {
        if (pig.Count > 0)
        {
            if (birds.Count > 0)
            {
                //下一只小鸟飞出
                Initialized();
            }
            else
            {
                //输了
            }
        }
        else
        {
            //赢了
        }
    }
}
