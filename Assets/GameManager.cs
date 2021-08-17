using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//あちらこちらに値を送るクラス。中間管理職の役割。
public class GameManager : MonoBehaviour
{
    private int level;
    public float speed;
    public int maxRound;

    public JudgeController judgeController;
    public RoundController roundController;
    // Start is called before the first frame update
    void Start()
    {
        this.speed = -4.0f;
        this.maxRound = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if(judgeController.isGameClear == true){
            level += 1;
            judgeController.isGameClear = false;
            levelCount();
        }
    }

    void levelCount(){
        if(level == 1){
            this.speed = -8.0f;
            this.maxRound = 40;
        }
        if(level == 2){
            this.speed = -12.0f;
            this.maxRound = 60;
        }  
    }
}
