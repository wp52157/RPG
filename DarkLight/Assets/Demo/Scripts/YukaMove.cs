using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukaMove : MonoBehaviour {

    public Rigidbody rig;
    public Animator anim;
    public Vector3 mon;
    public float speedMove;
    public GameObject g1;
    public GameObject g2;
    public Collider[] co;
   
    public static bool isJiance = false; 
	void Start () {
        rig = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {

        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        
        Quaternion qua = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        mon = new Vector3(moveH, 0, moveV);
        rig.MovePosition(transform.position + qua*mon * speedMove * Time.deltaTime);
        transform.rotation= Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);


        if (moveH != 0 || moveV != 0)
        {
            anim.SetBool("IsM", true);

            rig.MovePosition(transform.position + qua * mon * speedMove * Time.deltaTime);
        }
        else
        {
            anim.SetBool("IsM", false);

        };
        
        if (Input.GetKeyDown(KeyCode.J))
        {

            anim.SetBool("IsAtk2", true);
           

            isJiance = true;
        }
        else
        {
            anim.SetBool("IsAtk2", false);

        }
        if (Input.GetKeyDown(KeyCode.K))
        {

            anim.SetBool("IsAtk3",true);


            isJiance = true;
        }
        else
        {
            anim.SetBool("IsAtk3", false);

        }

    }
    void DaBeng()
    {
        Instantiate(g1,transform);
        co=Physics.OverlapSphere(transform.position, 1, LayerMask.NameToLayer("Enemy"));
        Debug.Log(co[0].name);
        Destroy(co[0]);

    }
    void XuanFengZhuan()
    {
        Instantiate(g2,transform);
        co = Physics.OverlapSphere(transform.position, 1, LayerMask.NameToLayer("Enemy"));
        Debug.Log(co[0].name);
        Destroy(co[0]);

    }

}
