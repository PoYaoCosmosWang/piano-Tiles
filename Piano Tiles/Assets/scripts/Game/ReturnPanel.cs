using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ReturnPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
            this.gameObject.transform.GetChild(5).GetChild(0).GetComponent<Button>().onClick.AddListener(Retry);
            this.gameObject.transform.GetChild(6).GetChild(0).GetComponent<Button>().onClick.AddListener(GetOut);
	}
	void Retry()
    {
        if (DataScript.Instance.PianoBlockBool == 2)
        {
            HW_StageManager.Instance.StartMovePianoBlock(1);
        }
        
    }
    void GetOut()
    {
        if (DataScript.Instance.PianoBlockBool == 2)
        {
            HW_StageManager.Instance.StartMovePianoBlock(0);
        }
    }
}
