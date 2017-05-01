using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
public class HW_StageManager : MonoBehaviour {

    public  static HW_StageManager Instance;
    public GameObject HP_Area;
    GameObject HP_Bar;
    public float HP,EnHP;
    public float Atk = 100f;
    public int Combo = 0, HiCombo = 0;
    public int Score = 0;
    public GameObject ComboText;
    public GameObject WinPanel , LosePanel;
    public int Heart = 3;
    public GameObject[] HeartPic;
    public AudioClip[] Piano;
    GameObject LastBlockThatPlayMusic;

    public GameObject PianoBlock;
    public DataHolder holder;

	void Start () {

        if (!Instance)
             Instance = this;
        if (!HP_Bar)
            HP_Bar = HP_Area.transform.GetChild(1).gameObject;
        holder = (DataHolder)Resources.Load("Saves/dataHolder", typeof(DataHolder));
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        Heart = 3;
        EnHP = 40000;
        Atk = 100f;
        HP = EnHP;

        PianoBlock.SetActive(true);
        StartCoroutine(MovePianoBlock());
        
    }

    public void StartMovePianoBlock(int a)
    {
        StartCoroutine(MovePianoBlock(a));
    }
    public IEnumerator MovePianoBlock(int a = 0)
    {
        float Distant = 0;
        float MoveSpeed = 1500f;
        float DeltaTime = 0.02f;
        float DeltaDistant = 0;
        if(DataScript.Instance.PianoBlockBool == 0)
        {
            DataScript.Instance.PianoBlockBool = 2;
        }
        else if (DataScript.Instance.PianoBlockBool == 1)
        {
            PianoBlock.transform.localPosition = new Vector3(0, 280);
            while (Distant<1500)
        {
            yield return new WaitForSeconds(DeltaTime);
            DeltaDistant = MoveSpeed * DeltaTime;
            PianoBlock.transform.localPosition += new Vector3(0, DeltaDistant);
            Distant += DeltaDistant;
        }
        PianoBlock.transform.localPosition = new Vector3(0, 1780);
            DataScript.Instance.PianoBlockBool = 2;
        }
        else if (DataScript.Instance.PianoBlockBool == 2)
        {
            PianoBlock.transform.localPosition = new Vector3(0, 1780);
            while (Distant < 1500)
            {
                yield return new WaitForSeconds(DeltaTime);
                DeltaDistant = MoveSpeed * DeltaTime;
                PianoBlock.transform.localPosition -= new Vector3(0, DeltaDistant);
                Distant += DeltaDistant;
            }
            PianoBlock.transform.localPosition = new Vector3(0, 280);
            DataScript.Instance.PianoBlockBool = 1;

            if(a ==0)
            {
                SceneManager.LoadScene("mainScene");            
            }
            else if(a ==1)
            {
                SceneManager.LoadScene("Homework");
            }
        }
        yield return 0;
    }

    public void Attack()
    {
        HW_StageManager.Instance.Combo++;
        SetComboText();
        float AttackPower = (Atk + (Combo / 2));
        HP_Bar.transform.localPosition -= new Vector3(AttackPower * HP_Bar.GetComponent<RectTransform>().rect.width/EnHP, 0);
        HP -= AttackPower;
        if (HP<0)
        {
            WinPanel.SetActive(true);
            SetResult();
            HW_BlockInfo.Instance.Stop = true;
            if (LastBlockThatPlayMusic)
                LastBlockThatPlayMusic.GetComponent<AudioSource>().Stop();
        }
    }
    public void Hurt()
    {
        if (Combo > HiCombo)
        { HiCombo = Combo; }
        Combo = 0;
        SetComboText();
        if (Heart>0)
        {
            Heart--;
            Destroy(HeartPic[Heart]);
        }
        else
        {
            LosePanel.SetActive(true);
            SetResult();      
            HW_BlockInfo.Instance.Stop = true;
            if(LastBlockThatPlayMusic)
            LastBlockThatPlayMusic.GetComponent<AudioSource>().Stop();
        }
        
    }
    void SetComboText()
    {
        ComboText.GetComponent<Text>().text = (Combo + " Combo");
    }
    public void SetResult()
    {
        Score = (Heart*100 + HiCombo);
        holder.Exp += Score;
        int Time = (int)HW_BlockInfo.Instance.PlayTime;
        if(Time % 60 > 9)
        { 
        WinPanel.transform.GetChild(2).GetComponent<Text>().text = ("-Time : " + Time / 60 + ":" + Time % 60 + " -");
        LosePanel.transform.GetChild(2).GetComponent<Text>().text = ("-Time : " + Time / 60 + ":" + Time % 60 + " -");
        } 
        else
        {
            WinPanel.transform.GetChild(2).GetComponent<Text>().text = ("-Time : " + Time / 60 + ":0" + Time % 60 + " -");
            LosePanel.transform.GetChild(2).GetComponent<Text>().text = ("-Time : " + Time / 60 + ":0" + Time % 60 + " -");
        }
        WinPanel.transform.GetChild(3).GetComponent<Text>().text = ("-Best Combo : " + HiCombo + " Hit -");
        LosePanel.transform.GetChild(3).GetComponent<Text>().text = ("-Best Combo : " + HiCombo + " Hit -");
        WinPanel.transform.GetChild(4).GetComponent<Text>().text = ("-Score : " + Score + " -");
        LosePanel.transform.GetChild(4).GetComponent<Text>().text = ("-Score : " + Score + " -");

        if (Time < holder.SongScore[holder.SongIPlay].BestTime && WinPanel.activeInHierarchy)
            holder.SongScore[holder.SongIPlay].BestTime = Time;
        if(HiCombo > holder.SongScore[holder.SongIPlay].BestCombos)
            holder.SongScore[holder.SongIPlay].BestCombos = HiCombo;
        if (Score > holder.SongScore[holder.SongIPlay].BestScore)
            holder.SongScore[holder.SongIPlay].BestScore = Score;

        holder.SetDirty();
    }


    public void PlayMusic(GameObject BLock , int Music)
    {
        Debug.Log(Music);

        if (LastBlockThatPlayMusic && BLock.GetComponent<HW_BlockClick>().Music != 0)
        {
            LastBlockThatPlayMusic.GetComponent<AudioSource>().Stop();
        }
        else
        {
            LastBlockThatPlayMusic = BLock;
        }
     
        BLock.GetComponent<AudioSource>().clip = HW_StageManager.Instance.Piano[Music];
        BLock.GetComponent<AudioSource>().Play();
    }


}
