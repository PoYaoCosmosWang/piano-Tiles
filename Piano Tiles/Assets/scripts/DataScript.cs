using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SongScoreData: DataHolder
{
    public int Number;//第幾首
    public string MusicName;//音樂名
    public int BestScore = 0;
    public int BestCombos = 0;
    public int BestTime = 0;

}
public class SongInfoData: DataHolder
{
    public int Number;//第幾首
    public List<int> MusicSheet = new List<int>();

    public void SetSheetA()
    {
        MusicSheet.Clear();
        /* CDEFG A B
        05612345#6#71#2#34
        012345678901234567
                  1
        */
        MusicSheet.Add(0);
        MusicSheet.Add(7);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(7);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(7);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(6);
        MusicSheet.Add(6);
        MusicSheet.Add(5);
        MusicSheet.Add(5);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(3);
        MusicSheet.Add(7);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(7);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(7);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(12);
        MusicSheet.Add(0);
        MusicSheet.Add(17);
        MusicSheet.Add(0);
        MusicSheet.Add(16);
        MusicSheet.Add(17);
        MusicSheet.Add(16);
        MusicSheet.Add(14);
        MusicSheet.Add(12);
        MusicSheet.Add(12);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(7);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(7);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(7);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(6);
        MusicSheet.Add(6);
        MusicSheet.Add(5);
        MusicSheet.Add(5);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(3);
        MusicSheet.Add(7);/////////
        MusicSheet.Add(7);
        MusicSheet.Add(9);
        MusicSheet.Add(12);
        MusicSheet.Add(14);
        MusicSheet.Add(12);
        MusicSheet.Add(9);
        MusicSheet.Add(7);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(9);
        MusicSheet.Add(14);
        MusicSheet.Add(9);/////
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(2);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(9);/////////
        MusicSheet.Add(9);
        MusicSheet.Add(7);
        MusicSheet.Add(9);
        MusicSheet.Add(7);
        MusicSheet.Add(6);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(3);////////////
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(3);
        MusicSheet.Add(2);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(3);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(9);
        MusicSheet.Add(7);
        MusicSheet.Add(9);
        MusicSheet.Add(7);
        MusicSheet.Add(6);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(0);///////////////
        MusicSheet.Add(6);
        MusicSheet.Add(0);
        MusicSheet.Add(5);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(0);
        MusicSheet.Add(3);
        MusicSheet.Add(0);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(2);
        MusicSheet.Add(1);
        MusicSheet.Add(2);
        MusicSheet.Add(0);
        MusicSheet.Add(2);
        MusicSheet.Add(0);
        MusicSheet.Add(2);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(0);
        MusicSheet.Add(7);
        MusicSheet.Add(0);
        MusicSheet.Add(5);
        MusicSheet.Add(0);
        MusicSheet.Add(6);
        MusicSheet.Add(6);
        MusicSheet.Add(5);
        MusicSheet.Add(3);///////
        MusicSheet.Add(4);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(0);
        MusicSheet.Add(6);
        MusicSheet.Add(0);
        MusicSheet.Add(5);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(0);
        MusicSheet.Add(3);
        MusicSheet.Add(0);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(2);
        MusicSheet.Add(1);
        MusicSheet.Add(2);
        MusicSheet.Add(0);
        MusicSheet.Add(2);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(4);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(0);
        MusicSheet.Add(7);
        MusicSheet.Add(0);//////////////////
        MusicSheet.Add(5);
        MusicSheet.Add(0);
        MusicSheet.Add(5);
        MusicSheet.Add(5);
        MusicSheet.Add(2);
        MusicSheet.Add(5);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(12);
        MusicSheet.Add(14);
        MusicSheet.Add(7);
        MusicSheet.Add(6);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(19);//////////////
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(10);
        MusicSheet.Add(9);
        MusicSheet.Add(7);
        MusicSheet.Add(6);
        MusicSheet.Add(6);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(12);
        MusicSheet.Add(14);
        MusicSheet.Add(7);
        MusicSheet.Add(6);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(0);//////////////
        MusicSheet.Add(10);
        MusicSheet.Add(10);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(6);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(9);
        MusicSheet.Add(5);
        MusicSheet.Add(3);
        MusicSheet.Add(4);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(12);
        MusicSheet.Add(14);
        MusicSheet.Add(7);
        MusicSheet.Add(6);//////////////
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(10);
        MusicSheet.Add(9);
        MusicSheet.Add(7);
        MusicSheet.Add(6);
        MusicSheet.Add(6);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(9);
        MusicSheet.Add(9);//////////////
        MusicSheet.Add(12);
        MusicSheet.Add(14);
        MusicSheet.Add(7);
        MusicSheet.Add(6);
        MusicSheet.Add(9);
        MusicSheet.Add(0);
        MusicSheet.Add(4);
        MusicSheet.Add(6);
        MusicSheet.Add(8);
        MusicSheet.Add(8);
        MusicSheet.Add(9);
        MusicSheet.Add(9);
        MusicSheet.Add(7);
        MusicSheet.Add(7);
        MusicSheet.Add(6);
        MusicSheet.Add(6);
        MusicSheet.Add(7);
        MusicSheet.Add(6);
        MusicSheet.Add(9);
        MusicSheet.Add(12);
        MusicSheet.Add(14);
        MusicSheet.Add(14);
        MusicSheet.Add(14);
        MusicSheet.Add(0);
    }

    public void SetSheetB()
    {
        MusicSheet.Add(16);
        MusicSheet.Add(15);
        MusicSheet.Add(16);
        MusicSheet.Add(15);
        MusicSheet.Add(16);
        MusicSheet.Add(11);
        MusicSheet.Add(14);
        MusicSheet.Add(12);
        MusicSheet.Add(9);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(3);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(11);
        MusicSheet.Add(5);
        MusicSheet.Add(8);
        MusicSheet.Add(5);
        MusicSheet.Add(8);
        MusicSheet.Add(11);
        MusicSheet.Add(12);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(5);
        MusicSheet.Add(16);
        MusicSheet.Add(15);
        MusicSheet.Add(16);
        MusicSheet.Add(15);
        MusicSheet.Add(5);
        MusicSheet.Add(11);
        MusicSheet.Add(14);
        MusicSheet.Add(12);
        MusicSheet.Add(9);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(3);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(11);
        MusicSheet.Add(5);
        MusicSheet.Add(8);
        MusicSheet.Add(5);
        MusicSheet.Add(12);
        MusicSheet.Add(11);
        MusicSheet.Add(9);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(11);
        MusicSheet.Add(12);
        MusicSheet.Add(14);
        MusicSheet.Add(16);
        MusicSheet.Add(7);
        MusicSheet.Add(12);
        MusicSheet.Add(7);
        MusicSheet.Add(17);
        MusicSheet.Add(16);
        MusicSheet.Add(14);
        MusicSheet.Add(7);
        MusicSheet.Add(11);
        MusicSheet.Add(6);
        MusicSheet.Add(16);
        MusicSheet.Add(14);
        MusicSheet.Add(12);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(5);
        MusicSheet.Add(14);
        MusicSheet.Add(12);
        MusicSheet.Add(11);
        MusicSheet.Add(5);
        MusicSheet.Add(16);
        MusicSheet.Add(5);
        MusicSheet.Add(16);
        MusicSheet.Add(5);
        MusicSheet.Add(16);
        MusicSheet.Add(5);
        MusicSheet.Add(16);
        MusicSheet.Add(15);
        MusicSheet.Add(16);
        MusicSheet.Add(15);
        MusicSheet.Add(16);
        MusicSheet.Add(11);
        MusicSheet.Add(14);
        MusicSheet.Add(12);///////////
        MusicSheet.Add(9);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(3);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(11);
        MusicSheet.Add(5);
        MusicSheet.Add(8);
        MusicSheet.Add(5);
        MusicSheet.Add(8);
        MusicSheet.Add(11);
        MusicSheet.Add(12);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(5);
        MusicSheet.Add(16);
        MusicSheet.Add(15);
        MusicSheet.Add(16);
        MusicSheet.Add(15);
        MusicSheet.Add(5);
        MusicSheet.Add(11);
        MusicSheet.Add(14);
        MusicSheet.Add(12);
        MusicSheet.Add(9);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(3);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(11);
        MusicSheet.Add(5);///////////
        MusicSheet.Add(8);
        MusicSheet.Add(5);
        MusicSheet.Add(12);
        MusicSheet.Add(11);
        MusicSheet.Add(9);
        MusicSheet.Add(5);
        MusicSheet.Add(9);
        MusicSheet.Add(0);///////////
    }
}
public class DataHolder : ScriptableObject
{

    public string Name;
    public int Level;
    public float Exp;
    public int SongIPlay;
    public List<SongScoreData> SongScore = new List<SongScoreData>();
    public  List<SongInfoData> SongInfo =  new List<SongInfoData>();

    public void Initalize()
    {
        string holderAssetPath = "Assets/Resources/Saves/";

        SongInfoData tempA = ScriptableObject.CreateInstance<SongInfoData>() ;
        tempA.Number = 0;
        tempA.SetSheetA();
        SongInfo.Add(tempA);
        AssetDatabase.CreateAsset(tempA, holderAssetPath + "tempA.asset");

        SongInfoData tempB = ScriptableObject.CreateInstance<SongInfoData>();
        tempB.Number = 1;
        tempB.SetSheetB();
        SongInfo.Add(tempB);
        AssetDatabase.CreateAsset(tempB, holderAssetPath + "tempB.asset");

        SongScoreData tempZ = ScriptableObject.CreateInstance<SongScoreData>();
        tempZ.Number = 0;
        tempZ.MusicName = "千本櫻";
        SongScore.Add(tempZ);
        AssetDatabase.CreateAsset(tempZ, holderAssetPath + "tempZ.asset");
        SongScoreData tempY = ScriptableObject.CreateInstance<SongScoreData>();
        tempY.Number = 1;
        tempY.MusicName = "給愛麗絲";
        SongScore.Add(tempY);
        AssetDatabase.CreateAsset(tempY, holderAssetPath + "tempY.asset");
    }
}

public class DataScript : MonoBehaviour {


     string holderAssetPath = "Assets/Resources/Saves/";
    public static DataScript Instance;
    public DataHolder holder;
    public int PianoBlockBool = 0; //0不啟動1關上2開著
    void Awake()
    {
        PianoBlockBool = 0;
        if (!Instance)
        { Instance = this; }
        DontDestroyOnLoad(Instance.gameObject);
        holder = (DataHolder)Resources.Load("Saves/dataHolder", typeof(DataHolder));
        if (!holder)
        {
            Debug.Log("rewrite");
            holder = ScriptableObject.CreateInstance<DataHolder>();
            holder.Initalize();
            AssetDatabase.CreateAsset(holder, holderAssetPath + "dataHolder.asset");       
        }
    }

}
