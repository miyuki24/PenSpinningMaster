using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//過ぎていったオブジェクトに対する処理
public class MissingController : MonoBehaviour
{
    public JudgeController judgeController;
    public RoundGenerator roundGenerator;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "roundTag"){
            judgeController.missCount += 1;
            if(judgeController.missCount == 3){
                judgeController.isGameOver = true;
            }
            judgeController.MissCount();
            if(roundGenerator.roundNumber == gameManager.maxRound){
                judgeController.isGameClear = true;
            }
        }
    }
}
