using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startBtnController : MonoBehaviour {
    private Button startBtn;
	// Use this for initialization
	void Start () {
        startBtn = GetComponent<Button>();
        startBtn.onClick.AddListener(changeScene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void changeScene()
    {
        SceneManager.LoadScene("mainScene");
    }
}
