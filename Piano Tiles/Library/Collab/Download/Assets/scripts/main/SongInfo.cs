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
    public Text nameText2;
    public Text scoreText;
    public Button playBtn;

    public int isBtnPressed;//btn被按了沒

    public int LookingAt = 0;
    public DataHolder holder;

    public GameObject DirectA, DirectB;


    // Use this for initialization
    void Awake () {
        holder = (DataHolder)Resources.Load("Saves/dataHolder", typeof(DataHolder));
        playBtn.onClick.AddListener(pressBtn);
        this.gameObject.transform.GetChild(2).GetChild(3).GetComponent<Button>().onClick.AddListener(PressSideSong);
        /*highScore = 0;
        combos = 0;
        time = 0;
        musicName = "musicName";
        isBtnPressed = 0;*/
      //  Debug.Log(234);
       // setText(LookingAt);
        playBtn.gameObject.SetActive(true);
	}

   public void loafInfo(SongInfo Temp)
    {
        Number = Temp.Number;     
        BestCombos = Temp.BestCombos;
        BestTime = Temp.BestTime;
        MusicName = Temp.MusicName;
        BestScore = Temp.BestScore;
        //Debug.Log(234);
       // setText(LookingAt);
    }
   
    public void setText(int i)
    {
        nameText.text = "- " + holder.SongScore[i].MusicName + " -";
        nameText2.text = holder.SongScore[i].MusicName;
        comboText.text = holder.SongScore[i].BestCombos + " HIT";
        scoreText.text = holder.SongScore[i].BestScore + " Pt";
        timeText.text = holder.SongScore[i].BestTime /60 + " min " + holder.SongScore[LookingAt].BestTime %60 +" sec";
    }
    public void SetDirection(int i)
    {
        if(i==1)
        {
            DirectA.GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 0,0);
            DirectB.GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 0, 0);
        }
        else if(i ==2)
        {
            DirectA.GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 180, 0);
            DirectB.GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 180, 0);
        }
    }
    void pressBtn()
    {
        if(DataScript.Instance.PianoBlockBool == 2)
        {
            isBtnPressed = 1;
            DataScript.Instance.holder.SongIPlay = mainSceneController.Instance.SongNumInMid;
            mainSceneController.Instance.StartMovePianoBlock();
        }   
    }
   public void PressSideSong()
    {
        if (mainSceneController.Instance.SongMoving == false)
        {
            if(this.gameObject.transform.localPosition.x<0)
            {
                mainSceneController.Instance.Move(0);
            }
            else if(this.gameObject.transform.localPosition.x > 0)
            {
                mainSceneController.Instance.Move(1);
            }
        }
    }
    /* public void pressSong()
     {
         Debug.Log("press");
         playBtn.gameObject.SetActive(true);

     }*/
}
