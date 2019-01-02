using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    GameObject go;
    CharacterController m_Player;
    bool isFirst=false,isMs=false;
    Vector3 monl;
    // Use this for initialization
    void Start () {
        go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        m_Player = gameObject.GetComponent<CharacterController>();
    }

    RaycastHit hit;
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            
            //Debug.Log(Input.mousePosition);
            //Vector3 wordPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//屏幕坐标
            //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //go.transform.position = wordPos;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawLine(ray.origin, ray.GetPoint(1000));
            if (Physics.Raycast(ray, out hit, 200, LayerMask.GetMask("Ground")))//
            {
                Instantiate(GameSetting.Instance.mousefxNormal, hit.point, Quaternion.identity);
                //go.transform.position = hit.point;

                //transform.LookAt(new Vector3(hit.point.x,transform.position.y,hit.point.z));
                monl = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
            isMs = true;
            isFirst = true;
            
        }
        if (Vector3.Distance(hit.point, transform.position)<0.3f)
        {

            return;
        }
        if (isMs)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(monl - transform.position), 0.4f);
        }
        if (isFirst)
        {
            PlayerMove(monl - transform.position);
        }
       
       
    }
    void PlayerMove(Vector3 vet)
    {
        m_Player.SimpleMove(vet.normalized*Time.deltaTime*300);
    }
}
