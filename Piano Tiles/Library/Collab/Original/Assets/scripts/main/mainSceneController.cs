using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainSceneController : MonoBehaviour {
    private GameObject songObj;
    public static mainSceneController Instance;
    public List<GameObject> songs;
    public GameObject Song_Mid;
    public List<SongInfo> infos;
    public int songsNum;
    //private const int songBlockWidth=300;
    private  Vector3 firstSongPos;
    public GameObject canvas;

    public GameObject PianoBlock;
    public bool PianoBlockBool = false;

    // Use this for initialization
    void Start () {
        songs = new List<GameObject>();
        infos = new List<SongInfo>();
        songsNum = 2;
        
        firstSongPos = new Vector3(-130, 30, 0);
        SongInfoSet();
        songsSpawn();
	}


   

    private void Awake()
    {
        songObj = Resources.Load("prefab/main/Song") as GameObject;
        SongInfoSet();
        if(!Instance)
        { Instance = this; }
    }
    public void SongInfoSet()
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
    }
    public void StartMovePianoBlock()
    {
        StartCoroutine(MovePianoBlock());
    }
    public IEnumerator MovePianoBlock()
    {
        Debug.Log(123);
        float Distant = 0;
        float MoveSpeed = 1500f;
        float DeltaTime = 0.02f;
        float DeltaDistant = 0;

        while (Distant < 1500)
        {
            yield return new WaitForSeconds(DeltaTime);
            DeltaDistant = MoveSpeed * DeltaTime;
            PianoBlock.transform.localPosition -= new Vector3(0, DeltaDistant);
            Distant += DeltaDistant;
        }
        PianoBlock.transform.localPosition = new Vector3(0, 280);
        PianoBlockBool = !PianoBlockBool;
        SceneManager.LoadScene("Homework");
        yield return 0;
    }
    // Update is called once per frame
    /* void Update () {
         checkClickedSignal();
     }*/
    void songsSpawn()
      {
        Song_Mid.GetComponent<SongInfo>().loadInfo(infos[0]);
         /* for(int i=0;i<songsNum;++i)
          {
              GameObject obj =Instantiate(songObj);
              obj.transform.SetParent(canvas.transform);
              obj.transform.position = firstSongPos + new Vector3( i * songBlockWidth,0, 0) + canvas.transform.position;
              Debug.Log(obj.transform.position.x);
              //調好位置了，開始設定
              SongInfo info = obj.GetComponent<SongInfo>();
              info.number = i;
              //.......not yet
              infos.Add(info);
              songs.Add(obj);
          }*/
      }
    /*   void checkClickedSignal()
       {
           for(int i=0;i<infos.Count;++i)
           {
               if (infos[i].isBtnPressed == 0)//no btn pressed
                   continue;
               else if(infos[i].isBtnPressed==1)//press easy
               {
                   Debug.Log("num:" + i.ToString() + ",start");
                   //.................
               }
               else
               {
                   Debug.Log("num:" + i.ToString() + ",start");
               }
           }
       }*/
}
