using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class HW_BlockClick : MonoBehaviour, IPointerDownHandler
{
    public int Position;
    public int Music;
    public int BlackPosition = 0;
    public GameObject Laser, LaserUI;
    void Start()
    {
        LaserUI = GameObject.FindWithTag("LaserUI");
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        if (HW_BlockInfo.Instance.HWBlockGroup[Position].Black)
        {
            //遊戲開始
            if (Position / 4 == 6 && HW_BlockInfo.Instance.Stop == true && HW_BlockInfo.Instance.StartStop == true)
            {
                HW_BlockInfo.Instance.Stop = false;
                HW_BlockInfo.Instance.StartStop = false;
            }
            //攻擊
            if (!HW_BlockInfo.Instance.Stop)
            {
                this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                HW_StageManager.Instance.Attack();
                CreateLaser(eventData);
                HW_StageManager.Instance.PlayMusic(this.gameObject, Music);
            }
        }
        //按錯
        else if (!HW_BlockInfo.Instance.Stop)
        {
            this.gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
            HW_StageManager.Instance.Hurt();
        }
    }
    void CreateLaser(PointerEventData eventData)
    {
        GameObject Temp = Instantiate(Laser, LaserUI.transform);
        Temp.transform.position = eventData.pressPosition;
        Temp.GetComponent<LaserScript>().Create();
    }
   
}

