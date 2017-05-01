using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HB2Library : MonoBehaviour {

    public static HB2Library Instance;
    public enum DirectionSet { Up, Right, Down, Left };
    public enum Item { Null, Pistol };
    public enum ItemCombine { Pistol_X, Pistol_Pistol };
    public enum BlockCondition { Normal, Crack, Break, Danger, BeBlocking ,  X }
    public enum PlayerCondition { Normal, Moving, Attacking, Hurting, X }
    public float ScaleWidth ;
    public float ScaleHeight ;

    void Awake()
    {
        ScaleWidth = GameObject.FindWithTag("Canvas").GetComponent<RectTransform>().rect.width / 720f;
        ScaleHeight = GameObject.FindWithTag("Canvas").GetComponent<RectTransform>().rect.height / 1280f;
        //declear script
        if (!Instance)
            Instance = this;

    }

    }
