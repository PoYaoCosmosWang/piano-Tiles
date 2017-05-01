using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public bool PianoBlockBool = true;

    public GameObject StartText;
	// Use this for initialization
	void Start () {
        if(!Instance)
             Instance = this;
        if (!HP_Bar)
            HP_Bar = HP_Area.transform.GetChild(1).gameObject;

        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        Heart = 3;
        EnHP = 40000;
        HP = EnHP;

        if(PianoBlockBool)
        {
            PianoBlock.SetActive(true);
               StartCoroutine(MovePianoBlock());
        }
    }
	public IEnumerator MovePianoBlock()
    {
        float Distant = 0;
        float MoveSpeed = 1500f;
        float DeltaTime = 0.02f;
        float DeltaDistant = 0;

        while (Distant<1500)
        {
            yield return new WaitForSeconds(DeltaTime);
            DeltaDistant = MoveSpeed * DeltaTime;
            PianoBlock.transform.localPosition += new Vector3(0, DeltaDistant);
            Distant += DeltaDistant;
        }
        PianoBlock.transform.localPosition = new Vector3(0, 1780);

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
            SetScore();
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
            SetScore();      
            HW_BlockInfo.Instance.Stop = true;
            if(LastBlockThatPlayMusic)
            LastBlockThatPlayMusic.GetComponent<AudioSource>().Stop();
        }
        
    }
    public void SetScore()
    {
        Score = (Heart*100 + HiCombo);
        WinPanel.transform.GetChild(2).GetComponent<Text>().text = ("-Score : " + Score + " -");
        LosePanel.transform.GetChild(2).GetComponent<Text>().text = ("-Score : " + Score + " -");
    }
    void SetComboText()
    {
        ComboText.GetComponent<Text>().text = (Combo + " Combo");
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
