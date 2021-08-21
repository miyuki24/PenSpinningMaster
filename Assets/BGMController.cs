using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    private AudioSource audioSource; 
    public AudioClip CountDown_Clips;
    public AudioClip BGM_Clips;

    //曲再生の判定
    private bool isCountDownSE = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("StartCountDown",1.1f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void StartCountDown(){
        audioSource.PlayOneShot(CountDown_Clips);
        isCountDownSE = true;
        Invoke("BGM",3.3f);
    }

    void BGM(){

        if(isCountDownSE){
            audioSource.clip = BGM_Clips;
            audioSource.Play();
            isCountDownSE = false;
        }
    }
}
