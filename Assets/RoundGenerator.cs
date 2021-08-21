using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundGenerator : MonoBehaviour
{
    //Prefabを入れておく箱
    public GameObject roundPrefab;
    public GameObject falseRoundPrefab;
    //時間計測用の変数
    private float delta = 0;
    //円の生成位置（X座標）
    private float genPosX = 10.0f;
    //円の生成位置（Y座標）
    private float genPosY = 3.5f;

    //現在のroundの番号
    public int roundNumber;
    private float deadline = -10.0f;

    //カウントダウン
    private float countDownDelta = 0;
    private float countDownSpan = 1.0f;

    public GameManager gameManager;

    void CountDown(){
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //現在のラウンドオブジェクトの数。生成するための記録する変数。最後かどうかタイミングでわからない。その場で大量に生成された場合、roundNumberとmaxRoundがその場で等しくなってしまう。各オブジェクトが何個目のオブジェクトなのかはわからない。
        roundNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        int num = Random.Range(1,11);
        if(this.roundNumber < gameManager.maxRound){
            if(this.delta >= gameManager.generationSpan){
                this.delta = 0;
                if(num <= 2){
                    //必要な値をRoundGeneratorでRoundControllerにGetComponentのroundControllerで渡す。roundController内の変数に値を設定してあげる。
                    GameObject falseRound = Instantiate(falseRoundPrefab);
                    falseRound.GetComponent<RoundController>().speed = gameManager.speed;
                    falseRound.transform.position = new Vector2(this.genPosX, this.genPosY);
                    this.roundNumber += 1;
                }else if(num >= 3 && num <= 9){
                    GameObject trueRound = Instantiate(roundPrefab);
                    trueRound.GetComponent<RoundController>().speed = gameManager.speed;
                    trueRound.transform.position = new Vector2(this.genPosX, this.genPosY);
                    this.roundNumber += 1;
                }
            }
        }
    }
}
