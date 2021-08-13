using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JudgeController : MonoBehaviour
{
    public bool isGameOver = false;
    private GameObject pointText;
    private int point = 0;
    private GameObject round;
    private GameObject falseRound;
    private GameObject gameOverText;
    private GameObject OutImage1;
    private GameObject OutImage2;
    private GameObject OutImage3;
    private Image image_component1;
    private Image image_component2;
    private Image image_component3;

    public int missCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.pointText = GameObject.Find("pointText");
        this.falseRound = GameObject.Find("falseRound");
        this.gameOverText = GameObject.Find("gameOverText");
        this.OutImage1 = GameObject.Find("outImage1");
        this.OutImage2 = GameObject.Find("outImage2");
        this.OutImage3 = GameObject.Find("outImage3");

        this.image_component1 = OutImage1.GetComponent<Image>();
        this.image_component2 = OutImage2.GetComponent<Image>();
        this.image_component3 = OutImage3.GetComponent<Image>();

        image_component1.enabled = false;
        image_component2.enabled = false;
        image_component3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isGameOver == true){
            this.gameOverText.GetComponent<Text>().text = "ゲームオーバー";
            Invoke("GameOver",2.0f);
        }
    }

    public void GameOver(){
        SceneManager.LoadScene("GameOverScene");
    } 

    public void MissCount(){
        if(missCount == 1){
            image_component1.enabled = true;
        }
        if(missCount == 2){
            image_component2.enabled = true;
        }
        if(missCount == 3){
            image_component3.enabled = true;
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "roundTag"){
            if(Input.GetMouseButtonDown(0)){
                this.point += 10;
                this.pointText.GetComponent<Text>().text = this.point + "ポイント";
                GameObject miss = GameObject.FindGameObjectWithTag("roundTag");
                Destroy(miss);
            }
        }else if(other.gameObject.tag == "falseRoundTag"){
            if(Input.GetMouseButtonDown(0)){
                missCount += 1;
                if(missCount == 3){
                    this.isGameOver = true;
                }
                MissCount();
            }
        }
    }
}
