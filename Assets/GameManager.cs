using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//あちらこちらに値を送るクラス。中間管理職の役割。
public class GameManager : MonoBehaviour
{
    private int level;
    public float speed;
    public int maxRound;

    private float delta = 0;
    private float span = 1.0f;

    public JudgeController judgeController;
    public RoundController roundController;

    private GameObject levelText;
    private Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        this.speed = -4.0f;
        this.maxRound = 20;
        this.levelText = GameObject.Find("level");
        this.textComponent = levelText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(judgeController.isGameClear == true){
            levelClear();
            levelCount();
            Debug.Log("ゲームがクリアした");
        }
    }

    void levelClear(){
        delta += Time.deltaTime;
        this.levelText.GetComponent<Text>().text = "レベル" + (level + 2);
        if(delta > span){
            textComponent.enabled = false;
            judgeController.isGameClear = false;
            delta = 0;
            level += 1;
            Debug.Log("delta>spanが呼ばれた");
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
