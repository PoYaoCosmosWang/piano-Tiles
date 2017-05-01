using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SongInfo : MonoBehaviour {
    public int Number;//第幾首
    public int BestScore;
    public int BestCombos;
    public int BestTime;
    public string MusicName;//音樂名

    public Text comboText;
    public Text timeText;
    public Text nameText;
    public Text scoreText;
    public Button playBtn;


    public int isBtnPressed;//btn被按了沒

	// Use this for initialization
	void Start () {

        playBtn.onClick.AddListener(pressBtn);
        /*highScore = 0;
        combos = 0;
        time = 0;
        musicName = "musicName";
        isBtnPressed = 0;*/
        setText();
        playBtn.gameObject.SetActive(true);
	}

   public void loadInfo(SongInfo Temp)
    {
        Number = Temp.Number;     
        BestCombos = Temp.BestCombos;
        BestTime = Temp.BestTime;
        MusicName = Temp.MusicName;
        BestScore = Temp.BestScore;

        setText();
    }
    void setText()
    {
        nameText.text = "- " + MusicName + " -";
        comboText.text = BestCombos + " HIT";
        scoreText.text = BestScore + " Pt";
        timeText.text = BestTime/60 + " min " + BestTime%60 +" sec";
    }


    void pressBtn()
    {
        isBtnPressed = 1;
        mainSceneController.Instance.StartMovePianoBlock();      
    }
    /*
    void pressEasyBtn()//not yet..
    {
        isBtnPressed = 1;
    }


    void pressHardBtn()//not yet
    {
        isBtnPressed = 2;
    }
    */
    public void pressSong()
    {
        Debug.Log("press");
        playBtn.gameObject.SetActive(true);
        
    }
}
