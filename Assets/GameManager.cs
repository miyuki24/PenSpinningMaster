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
    public float generationSpan;

    private float delta = 0;
    private float span = 1.0f;

    public JudgeController judgeController;
    public RoundController roundController;

    private GameObject levelText;
    private Text textComponent;

    private GameObject countDownImage;
    private Image image_component;

    public Sprite countDown1;
    public Sprite countDown2;
    public Sprite countDown3;

    public int finishRoundNumber = 0;

    private float countDownDelta = 0;

    public RoundGenerator roundGenerator;
    // Start is called before the first frame update
    void Start()
    {
        this.speed = -4.0f;
        this.maxRound = 20;
        this.generationSpan = 0.5f;
        this.levelText = GameObject.Find("level");
        this.textComponent = levelText.GetComponent<Text>();
        this.countDownImage = GameObject.Find("countDownImage");
        this.image_component = countDownImage.GetComponent<Image>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(judgeController.isGameClear == true){
            levelClear();
            finishRoundNumber = 0;
            
        }
        CountDown();
    }

    void CountDown(){
        image_component.sprite = countDown3;
        countDownDelta += Time.deltaTime;
        if(countDownDelta > 3.0f){
            image_component.enabled = false;
        } else if(countDownDelta > 2.0f){
            image_component.sprite = countDown1;
        } else if(countDownDelta > 1.0f){
            image_component.sprite = countDown2;
        }
    }

    void levelClear(){
        delta += Time.deltaTime;
        this.levelText.GetComponent<Text>().text = "レベル" + (level + 2);
        if(judgeController.isGameOver){
            textComponent.enabled = false;
        }
        if(delta > span){
            textComponent.enabled = false;
            delta = 0;
            level += 1;
            levelCount();
            judgeController.isGameClear = false;
            roundGenerator.roundNumber = 0;
        }
    }

    void levelCount(){
        if(level == 1){
            this.speed = -6.5f;
            this.maxRound = 30;
            this.generationSpan = 0.3f;
        }
        if(level == 2){
            this.speed = -9.0f;
            this.maxRound = 50;
            this.generationSpan = 0.15f;
        }  
    }
}
