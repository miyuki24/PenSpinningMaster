using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    public bool storyOnly = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetBiginingButton(){
        SceneManager.LoadScene("OpeningScene");
    }

    public void GetStoryButton(){
        SceneManager.LoadScene("OpeningScene");
        storyOnly = true;
    }

    public void GetRuleButton(){
        SceneManager.LoadScene("RuleScene");
    }
}
