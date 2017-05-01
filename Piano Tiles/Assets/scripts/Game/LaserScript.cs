using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class LaserScript : MonoBehaviour {
    public Vector3 EnePos;
 
    public float Speed;
    public float Angel;
    // Use this for initialization
    void Start () {
        EnePos = new Vector3(0, 365);
        Speed = 3000f;
    }
	
	// Update is called once per frame
	public void Create()
    {
        EnePos = new Vector3(0, 365);
        Speed = 100f;
        Vector3 Point = this.gameObject.transform.localPosition;
        Angel = Mathf.Atan( (EnePos.y - Point.y) / (EnePos.x - Point.x) );
        //this.gameObject.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, Angel, 0);
    }
    void Update()
    {
        this.gameObject.transform.eulerAngles = new Vector3(0, 0, -Angel*3);
        if(Angel>0)
        this.gameObject.transform.localPosition += new Vector3(Speed * Time.deltaTime * Mathf.Cos(Angel), Speed * Time.deltaTime * Mathf.Sin(Angel));
        else
            this.gameObject.transform.localPosition += new Vector3(-Speed * Time.deltaTime * Mathf.Cos(Angel), -Speed * Time.deltaTime * Mathf.Sin(Angel));
    }
    void OnTriggerEnter2D(Collider2D TouchObject)
    {
        if(TouchObject.tag == "Enemy")
        Destroy(this.gameObject);
    }
}
