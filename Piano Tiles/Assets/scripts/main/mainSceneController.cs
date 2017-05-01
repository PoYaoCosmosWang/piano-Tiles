using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class mainSceneController : MonoBehaviour {

    public GameObject SongObj;
    public GameObject SongUI;
    public static mainSceneController Instance;
    public bool SongMoving;
    //public List<GameObject> songs;
    //public GameObject Song_Mid;
    //public List<SongInfo> infos;
    //public int songsNum;

    public  Vector3 firstSongPos;
    public GameObject PianoBlock;
    public GameObject Song_LL,Song_L, Song_M, Song_R, Song_RR;
    public int SongNumInMid = 0;
    public float SongDistant = 285f;
    public DataHolder holder;
    // Use this for initialization
    void Start () {
        //songs = new List<GameObject>();
        // infos = new List<SongInfo>();
        // songsNum = 2;
        firstSongPos = new Vector3(0, 90, 0);
        SongObj = Resources.Load("Song") as GameObject;
        holder = (DataHolder)Resources.Load("Saves/dataHolder", typeof(DataHolder));
        mainSceneController.Instance.SongNumInMid = DataScript.Instance.holder.SongIPlay ;
        SetSongMeun();
      
        // SongInfoSet();
        // songsSpawn();

        StartMovePianoBlock();
    }
    private void Awake()
    {
        
        if (!Instance)
        { Instance = this; }
        else
        { Destroy(this.gameObject); }
        SongMoving = false;
    }
    /*public void SongInfoSet()
    {
        infos.Clear();

        SongInfo Temp0 = new SongInfo();        
        SongInfo Temp1 = new SongInfo();

        Temp0.Number = 0;
        Temp0.MusicName = "千本櫻";
        Temp0.BestCombos = 125;
        Temp0.BestScore = 825;
        Temp0.BestTime = 82;

        Temp1.Number = 1;
        Temp1.MusicName = "給愛麗絲";
        Temp1.BestCombos = 140;
        Temp1.BestScore = 445;
        Temp1.BestTime = 43;

        infos.Add(Temp0);
        infos.Add(Temp1);
    }*/
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Move(0);
        if (Input.GetKeyDown(KeyCode.W))
            Move(1);
    }
    public void SetSongMeun()
    {
        int Exist = SongUI.transform.childCount;
        for (int i = 0; i < Exist; i++)
        {
            Destroy(SongUI.transform.GetChild(i).gameObject);
        }

        Song_LL = Instantiate(SongObj,SongUI.transform);
        Song_L = Instantiate(SongObj, SongUI.transform);
        Song_M = Instantiate(SongObj, SongUI.transform);
        Song_R = Instantiate(SongObj, SongUI.transform);
        Song_RR = Instantiate(SongObj, SongUI.transform);

        Song_M.transform.localPosition = firstSongPos;
        Song_L.transform.localPosition = firstSongPos - new Vector3(SongDistant, 0);
        Song_R.transform.localPosition = firstSongPos + new Vector3(SongDistant, 0);
        Song_LL.transform.localPosition = firstSongPos - new Vector3(SongDistant*2, 0);
        Song_RR.transform.localPosition = firstSongPos + new Vector3(SongDistant*2, 0);
       
        Song_M.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(150, 240);
        Song_L.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(35, 240);
        Song_R.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(35, 240);
        Song_LL.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(35, 240);
        Song_RR.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(35, 240);

        SetBG(Song_M,1);
        SetBG(Song_L, 2);
        SetBG(Song_R, 2);
        SetBG(Song_LL, 2);
        SetBG(Song_RR, 2);
       
        int SongNum = holder.SongInfo.Count;
        int SongTemp = DataScript.Instance.holder.SongIPlay;
        Song_M.GetComponent<SongInfo>().setText(SongTemp);
        if(SongTemp - 1<0)
            Song_L.GetComponent<SongInfo>().setText(SongTemp - 1 + SongNum);
        else
            Song_L.GetComponent<SongInfo>().setText(SongTemp - 1);
        if (SongTemp + 1 >= SongNum)
            Song_R.GetComponent<SongInfo>().setText((SongTemp + 1)% SongNum);
        else
            Song_R.GetComponent<SongInfo>().setText(SongTemp + 1);
        if (SongTemp - 2 < 0)
            Song_LL.GetComponent<SongInfo>().setText(SongTemp - 2 + SongNum);
        else
            Song_LL.GetComponent<SongInfo>().setText(SongTemp - 2);
        if (SongTemp + 2 >= SongNum)
            Song_RR.GetComponent<SongInfo>().setText((SongTemp + 2) % SongNum);
        else
            Song_RR.GetComponent<SongInfo>().setText(SongTemp + 2);

        Song_L.GetComponent<SongInfo>().SetDirection(2);
        Song_R.GetComponent<SongInfo>().SetDirection(1);
        Song_LL.GetComponent<SongInfo>().SetDirection(2);
        Song_RR.GetComponent<SongInfo>().SetDirection(1);
    }
    public void SetBG(GameObject Song, int a)
    {
        if (a == 1)
        {
            Song.transform.GetChild(1).gameObject.SetActive(true);
            Song.transform.GetChild(1).GetComponent<CanvasGroup>().alpha = 1;
            Song.transform.GetChild(2).gameObject.SetActive(false);
            Song.transform.GetChild(2).GetComponent<CanvasGroup>().alpha = 0;
        }
        else if (a == 2)
        {
            Song.transform.GetChild(1).gameObject.SetActive(false);
            Song.transform.GetChild(1).GetComponent<CanvasGroup>().alpha = 0;
            Song.transform.GetChild(2).gameObject.SetActive(true);
            Song.transform.GetChild(2).GetComponent<CanvasGroup>().alpha = 1;
        }
    }
    public void Move(int a)//0左1右
    {
        int SongNum = holder.SongInfo.Count;
        if (a==0)
        {
            SongNumInMid--;
            if (SongNumInMid < 0)
                SongNumInMid += SongNum;
            else if (SongNumInMid == SongNum)
                SongNumInMid = 0;

            Destroy(Song_LL);
            Song_LL = Song_L;
            Song_L = Song_M;
            Song_M = Song_R;
            Song_R = Song_RR;
            Song_RR = Instantiate(SongObj, SongUI.transform);

            Song_RR.transform.localPosition = firstSongPos + new Vector3(SongDistant * 3, 0);
            Song_RR.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(35, 240);
            SetBG(Song_RR, 2);
            if (SongNumInMid + 2 >= SongNum)
                Song_RR.GetComponent<SongInfo>().setText(SongNumInMid + 2 - SongNum);
            else
                Song_RR.GetComponent<SongInfo>().setText(SongNumInMid + 2 );
            Song_RR.GetComponent<SongInfo>().SetDirection(1);

            StartCoroutine(MoveSongBlockLeft());
        }
        if (a == 1)
        {
            SongNumInMid++;
            if (SongNumInMid < 0)
                SongNumInMid += SongNum;
            else if (SongNumInMid == SongNum)
                SongNumInMid = 0;

            Destroy(Song_RR);
            Song_RR = Song_R;
            Song_R = Song_M;
            Song_M = Song_L;
            Song_L = Song_LL;
            Song_LL = Instantiate(SongObj, SongUI.transform);

            Song_LL.transform.localPosition = firstSongPos - new Vector3(SongDistant * 3, 0);
            Song_LL.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(35, 240);
            SetBG(Song_LL, 2);
            if(SongNumInMid - 2 <0)
                Song_LL.GetComponent<SongInfo>().setText(SongNumInMid - 2 + SongNum);
            else
                Song_LL.GetComponent<SongInfo>().setText(SongNumInMid - 2 );
            Song_LL.GetComponent<SongInfo>().SetDirection(2);

            StartCoroutine(MoveSongBlockRight());
        }
    }
    public IEnumerator MoveSongBlockLeft()
    {
        float DeltaTime = 0.03f;
        float Times = 20f;
        float DeltaDistant = (-1)*SongDistant / Times;
        float DeltaSize = (150f - 35f)/ Times;

        for(int i=0; i< Times; i++)
        {
            yield return new WaitForSeconds(DeltaTime);
            Song_LL.transform.localPosition += new Vector3(DeltaDistant, 0);
            Song_L.transform.localPosition += new Vector3(DeltaDistant, 0);
            Song_L.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta -= new Vector2(DeltaSize, 0);
            if (i <= 9)
            {
                Song_L.transform.GetChild(1).GetComponent<CanvasGroup>().alpha -= 1 / (Times / 2);
            }
            else
            {
                Song_L.transform.GetChild(1).gameObject.SetActive(false);
                Song_L.transform.GetChild(2).gameObject.SetActive(true);
                Song_L.transform.GetChild(2).GetComponent<CanvasGroup>().alpha += 1 / (Times / 2);
            }
            Song_L.GetComponent<SongInfo>().SetDirection(2);

            Song_M.transform.localPosition += new Vector3(DeltaDistant, 0);
            Song_M.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta += new Vector2(DeltaSize, 0);
            if (i <= 9)
            {
                Song_M.transform.GetChild(2).GetComponent<CanvasGroup>().alpha -= 1 / (Times / 2);
            }
            else
            {
                Song_M.transform.GetChild(1).gameObject.SetActive(true);
                Song_M.transform.GetChild(2).gameObject.SetActive(false);
                Song_M.transform.GetChild(1).GetComponent<CanvasGroup>().alpha += 1 / (Times/2);
            }

            Song_R.transform.localPosition += new Vector3(DeltaDistant, 0);
            Song_RR.transform.localPosition += new Vector3(DeltaDistant, 0);
        }

        yield return 0;
    }
    public IEnumerator MoveSongBlockRight()
    {
        float DeltaTime = 0.03f;
        float Times = 20f;
        float DeltaDistant = SongDistant / Times;
        float DeltaSize = (150f - 35f) / Times;

        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(DeltaTime);
            Song_LL.transform.localPosition += new Vector3(DeltaDistant, 0);
            Song_L.transform.localPosition += new Vector3(DeltaDistant, 0);

            Song_M.transform.localPosition += new Vector3(DeltaDistant, 0);
            Song_M.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta += new Vector2(DeltaSize, 0);
            if (i <= 9)
            {
                Song_M.transform.GetChild(2).GetComponent<CanvasGroup>().alpha -= 1 / (Times / 2);
            }
            else
            {
                Song_M.transform.GetChild(1).gameObject.SetActive(true);
                Song_M.transform.GetChild(2).gameObject.SetActive(false);
                Song_M.transform.GetChild(1).GetComponent<CanvasGroup>().alpha += 1 / (Times / 2);
            }
            Song_R.transform.localPosition += new Vector3(DeltaDistant, 0);
            Song_R.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta -= new Vector2(DeltaSize, 0);
            if (i <= 9)
            {
                Song_R.transform.GetChild(1).GetComponent<CanvasGroup>().alpha -= 1 / (Times / 2);
            }
             else
            {
                Song_R.transform.GetChild(1).gameObject.SetActive(false);
                Song_R.transform.GetChild(2).gameObject.SetActive(true);
                Song_R.transform.GetChild(2).GetComponent<CanvasGroup>().alpha += 1 / (Times / 2);
            }
           
            
            Song_R.GetComponent<SongInfo>().SetDirection(1);
            Song_RR.transform.localPosition += new Vector3(DeltaDistant, 0);
        }

        yield return 0;
    }
    public void StartMovePianoBlock()
    {
        StartCoroutine(MovePianoBlock());
    }
    public IEnumerator MovePianoBlock()
    {
        float Distant = 0;
        float MoveSpeed = 1500f;
        float DeltaTime = 0.02f;
        float DeltaDistant = 0;

        if (!PianoBlock)
        {
            PianoBlock = GameObject.FindWithTag("PianoBlock");
        }

        if (DataScript.Instance.PianoBlockBool == 0)
        {
            DataScript.Instance.PianoBlockBool = 2;
        }
        else if (DataScript.Instance.PianoBlockBool == 1)
        {
            PianoBlock.transform.localPosition = new Vector3(0, 280);
            while (Distant < 1500)
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

            SceneManager.LoadScene("Homework");
        }

        yield return 0;
    }

  
}
