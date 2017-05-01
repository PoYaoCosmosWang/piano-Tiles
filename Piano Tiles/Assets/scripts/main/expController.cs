using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class expController : MonoBehaviour {

    public Slider exp;
    public Text Level;
    public DataHolder holder;
    // Use this for initialization
    void Start () {
        holder = (DataHolder)Resources.Load("Saves/dataHolder", typeof(DataHolder));
        Level = GameObject.FindWithTag("Level").gameObject.GetComponent<Text>();
        Level.text = holder.Level.ToString();
        exp.value = holder.Exp / 100;
    }
	
	// Update is called once per frame
	void Update () {
        if(holder.Exp >= 100)
        {
            holder.Exp -= 100;
            holder.Level += 1;
        }
        Level.text = holder.Level.ToString();
        exp.value = holder.Exp / 100;
    }
}
