using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HWBlockInfoDetail
{
    public int Position;
    public bool Black = false;
    public int High;
    public GameObject BlockInstance;
    public bool Moving;

    public void Copy(HWBlockInfoDetail Other)
    {
        Position = Other.Position;
        Black = Other.Black;
        High = Other.High;
        BlockInstance = Other.BlockInstance;
        Moving = Other.Moving;

    }
}
public class HW_BlockInfo : MonoBehaviour {

    public List<HWBlockInfoDetail> HWBlockGroup = new List<HWBlockInfoDetail>();
    public static HW_BlockInfo Instance;
    public GameObject Canvas, BlockGroupGameObject;
    public GameObject BlockObject;
    public float MoveSpeed, ScaleWidth, ScaleHeight, BlockWidth, BlockHeight;
    int RowCreate, PassageLong;
    public bool Stop,StartStop;
    bool PrepareForBossArea;
    int MusicPoint;
    public float PlayTime = 0;
    public DataHolder holder;
    void Awake()
    {
        holder = (DataHolder)Resources.Load("Saves/dataHolder", typeof(DataHolder));
        if (!Instance)
            Instance = this;
        Canvas = GameObject.FindWithTag("Canvas");
        ScaleWidth = Canvas.GetComponent<RectTransform>().rect.width / 720f;
        ScaleHeight = Canvas.GetComponent<RectTransform>().rect.height / 1280f;
        BlockWidth = BlockObject.GetComponent<RectTransform>().rect.width;
        BlockHeight = BlockObject.GetComponent<RectTransform>().rect.height;
        MoveSpeed = 600f;
        PassageLong = 1;

        ResetBlockGroup();

        MusicPoint = 8;
         Stop = true;
        StartStop = true;
        PlayTime = 0;


    }

    public int BlockAt = 0;
    public int LastBlockAt = 0;

    void ResetBlockGroup()
    {

        //delete all old block
        HWBlockGroup.Clear();
        int BlockExist = BlockGroupGameObject.transform.childCount;
        for (int i = 0; i < BlockExist; i++)
        {
            Destroy(BlockGroupGameObject.transform.GetChild(i).gameObject);
        }

        //Create new block

        for (int i = 0; i < 8; i++)
        {   
            //設定黑格位置
            if (i==0)
            {
                BlockAt = Random.Range(0, 4);
            }
            else if (MusicRequire(7 - i) == MusicRequire(7 - i +1))
            {
                //同音BlockAt不變
            }
            else
            {
                //不同音BlockAt要不同               
                int temp = Random.Range(0, 4);
                while (BlockAt == temp)
                {
                    temp = Random.Range(0, 4);
                }
                BlockAt = temp;
            }

            for (int j=0;j<4;j++)
            {
                //Create Block Gameobject
                GameObject CreatedBlock = Instantiate(BlockObject, BlockGroupGameObject.transform);
                CreatedBlock.transform.localPosition = new Vector3((-270 + BlockWidth * (j % 4)) * ScaleWidth, 860 - BlockHeight * (i) * ScaleHeight);
                CreatedBlock.GetComponent<HW_BlockClick>().Position = i * 4 + j;

                //Write Down the info of each block
                HWBlockInfoDetail Block = new HWBlockInfoDetail();
                Block.Position = i*4+j;
                Block.BlockInstance = CreatedBlock;
                Block.Black = false;

                //設定黑格
                if (BlockAt == j && i!=7)
                {
                    CreatedBlock.GetComponent<HW_BlockClick>().Music = MusicRequire(7-i);
                    CreatedBlock.GetComponent<Image>().color = new Color(0, 0, 0);
                    Block.Black = true;
                }

                HWBlockGroup.Add(Block);
            }
        }
    }

    void Update()
    {
        if (!Stop)
        {
            Move();
            PlayTime += Time.deltaTime;
        }
       // MoveSpeed += Time.deltaTime * 12f;
    }
    void Move()
    {
        float deltaTime = Time.deltaTime;
        float ScaleHeight = HB2Library.Instance.ScaleHeight;
        for (int i = 0; i < 32; i++)
        {
            HWBlockGroup[i].BlockInstance.GetComponent<RectTransform>().localPosition += new Vector3(0, -MoveSpeed * deltaTime * ScaleHeight);
        }

        if (HWBlockGroup[0].BlockInstance.GetComponent<RectTransform>().localPosition.y - 660 * ScaleHeight < 3)
        {
            CreateNewAndDestroyOld();
        }

    }

    int MusicRequire(int a)
    {
        return holder.SongInfo[DataScript.Instance.holder.SongIPlay].MusicSheet[a];
    }

    void CreateNewAndDestroyOld()
    {

        if (MusicRequire(MusicPoint) == MusicRequire(MusicPoint - 1))
        { }
        else
        {
            int temp = Random.Range(0, 4);
            while (BlockAt == temp)
            {
                temp = Random.Range(0, 4);
            }
            BlockAt = temp;
        }

        for (int i = 31; i >= 0; i--)
        {
            if (i / 4 > 0)
            {
                //消除最尾列
                if (i / 4 == 7)
                { Destroy(HWBlockGroup[i].BlockInstance); }

                //把此行參數丟給下行
                HWBlockGroup[i].Copy(HWBlockGroup[i - 4]);
                HWBlockGroup[i].BlockInstance.GetComponent<HW_BlockClick>().Position += 4;
            }
            else if (i / 4 == 0)
            {            
                GameObject CreatedBlock = Instantiate(BlockObject, BlockGroupGameObject.transform);
                CreatedBlock.transform.localPosition = new Vector3((-270 + BlockWidth * (i % 4)) * ScaleWidth, HWBlockGroup[i + 4].BlockInstance.GetComponent<RectTransform>().localPosition.y + 200 * ScaleHeight);
             
                HWBlockGroup[i].Position = i;
                HWBlockGroup[i].BlockInstance = CreatedBlock;
                HWBlockGroup[i].BlockInstance.GetComponent<HW_BlockClick>().Position = i;
                HWBlockGroup[i].Moving = true;
                HWBlockGroup[i].Black = false;

                if (i % 4 == BlockAt)
                {
                    CreatedBlock.GetComponent<HW_BlockClick>().Music = MusicRequire(MusicPoint);
                    MusicPoint++;
                    if(MusicPoint >= holder.SongInfo[DataScript.Instance.holder.SongIPlay].MusicSheet.Count)
                    {
                        MusicPoint = 0;
                    }          
                    CreatedBlock.GetComponent<Image>().color = new Color(0, 0, 0);
                    HWBlockGroup[i].Black = true;
                }

            }
        }

    }


}
