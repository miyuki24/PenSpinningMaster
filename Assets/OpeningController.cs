using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningController : MonoBehaviour
{
    private int clickTimes = 0;
    private GameObject talkText;
    private Text text_component;

    private GameObject gameObject;
    private TitleSceneController titleSceneController;

    //public TitleSceneController titleSceneController;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject = GameObject.Find("TitleSceneController");
        //this.titleSceneController = gameObject.GetComponent<TitleSceneController>();
        this.talkText = GameObject.Find("Talk");
        this.text_component = talkText.GetComponent<Text>();
        this.text_component.text = "キーンコーンカーンコーン\n先生：お〜い、授業はじめるぞ〜\n生徒：よろしくお願いします";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            this.clickTimes  += 1;
        }

        if(this.clickTimes == 1){
            text_component.text = "生徒A：おい！今日は絶対負けねぇからな！\nあなた：おう！望むところだ";
        }

        if(this.clickTimes == 2){
            text_component.text = "生徒A：もちろん種目は〜\n生徒A・あなた：ペンまわし！\nあなた：記録更新でペン回師に俺はなる！";
        }
        if(this.clickTimes == 3 && TitleSceneController.storyOnly == false){
            SceneManager.LoadScene("RuleScene");
        }
        if(this.clickTimes == 3 && TitleSceneController.storyOnly == true){
            SceneManager.LoadScene("TitleScene");
        }
    }
}
