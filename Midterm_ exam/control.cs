using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public GameObject mainCamera;   //相機物件, 要在Unity手動拉物件連結
    int flag = 1;                   //"1"第三人稱, "0"第一人稱, "-1"從正面看
    float speedUp = 0;              //物件前後變數，初始為(0.1f)+speedUp
    float angle = 0;                //物件左右變數

    void Start () {
		
	}
	
	void Update () {
        //切換視角--------------------------------------------------
        //第三人稱&從正面看，要脫離主物件".parent = null"
        if (Input.GetKey(KeyCode.Z))    //第三人稱
        {
            flag = 1;
            mainCamera.transform.parent = null;
        }
        if (Input.GetKey(KeyCode.A))    //從正面看
        {
            flag = -1;
            mainCamera.transform.parent = null;
        }
        if (Input.GetKey(KeyCode.F))    //第一人稱
        {
            flag = 0;
            mainCamera.transform.position = this.transform.position + this.transform.forward * 2;
            mainCamera.transform.rotation = this.transform.rotation;
            mainCamera.transform.parent = this.transform;
        }

        //根據視角，改變攝影機位置------------------------------------
        if (flag == 1)
        {
            mainCamera.transform.position = this.transform.position + new Vector3(0, 13, -25);
            mainCamera.transform.eulerAngles = new Vector3(10, 0, 0);
        }
        if (flag == -1)
        {
            mainCamera.transform.position = this.transform.position + new Vector3(0, 10, 20);
            mainCamera.transform.eulerAngles = new Vector3(10, 180, 0);
        }

        //主物件移動控制-----------------------------------------------
        if (Input.GetKey(KeyCode.UpArrow))      speedUp += 0.01f;
        if (Input.GetKey(KeyCode.DownArrow))    speedUp -= 0.01f;
        if (Input.GetKey(KeyCode.LeftArrow))    angle -= 2;
        if (Input.GetKey(KeyCode.RightArrow))   angle += 2;

        this.transform.position += this.transform.forward * (0.1f + speedUp);
        this.transform.eulerAngles = new Vector3(0, angle, 0);
    }
}
