﻿using System.Collections;
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
            //levelCount();
            finishRoundNumber = 0;
            level += 1;
            judgeController.isGameClear = false;
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
        if(delta > span){
            textComponent.enabled = false;
            //judgeController.isGameClear = false;
            delta = 0;
            //level += 1;
            levelCount();
        }
    }

    void levelCount(){
        Debug.Log("LevelCountが呼ばれた");
        if(level == 1){
            this.speed = -8.0f;
            this.maxRound = 40;
            this.generationSpan = 0.25f;
            Debug.Log(speed);
            Debug.Log(maxRound);
            Debug.Log(generationSpan);
        }
        if(level == 2){
            this.speed = -12.0f;
            this.maxRound = 60;
            this.generationSpan = 0.125f;
            Debug.Log("レベル2も呼ばれている");
        }  
    }
}
