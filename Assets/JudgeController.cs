using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JudgeController : MonoBehaviour
{

    private GameObject pointText;
    public int point = 0;
    private GameObject round;
    private GameObject falseRound;
    private GameObject gameOverText;
    private GameObject OutImage1;
    private GameObject OutImage2;
    private GameObject OutImage3;
    private Image image_component1;
    private Image image_component2;
    private Image image_component3;

    public bool isGameOver = false;
    public bool isGameClear = false;
    public int missCount = 0;

    private float mouseClickedTime = 0.0f;

    public RoundGenerator roundGenerator;
    public GameManager gameManager;
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

        //マウスがクリックされたら一定時間roundTagが呼ばれる(「クリックが押されたら」の条件を「クリックしている間の値」として保持しておく) 
		if(Input.GetMouseButtonDown(0)){
            //値が代入される
			mouseClickedTime = 0.1f;
		}
		//時間の経過ともにmouseClickedTimeが減少
		if(mouseClickedTime > 0.0f){
			mouseClickedTime -= Time.deltaTime;
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
			//マウスがクリックされた瞬間の付近のとき。OnTriggerStay2DとGetMouseButtonDownは相性が悪いため、それぞれ別の場所で管理する。
            if(mouseClickedTime > 0.0f){
                this.point += 10;
                this.pointText.GetComponent<Text>().text = this.point + "ポイント";
                //当たったオブジェクトを消去。OnTriggerStay2Dの引数に入っているオブジェクトを削除する
				Destroy(other.gameObject);
                gameManager.finishRoundNumber += 1;
                //RoundControllerに何番目のRoundかの値を持たせる。maxRoundとの比較。RoundControllerに何番目のオブジェクトを持つ変数を用意する。tagの代わりになる背番号の役割。何番目のオブジェクトか。
                if(gameManager.finishRoundNumber == gameManager.maxRound){
                    this.isGameClear = true;
                }
            }
        }else if(other.gameObject.tag == "falseRoundTag"){
            if(mouseClickedTime > 0.0f){
                missCount += 1;
                if(missCount == 3){
                    this.isGameOver = true;
                }
                MissCount();
                gameManager.finishRoundNumber += 1;
                if(gameManager.finishRoundNumber == gameManager.maxRound){
                    this.isGameClear = true;
                }
            }
        }
    }
}
