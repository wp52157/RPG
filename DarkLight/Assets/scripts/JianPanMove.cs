using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JianPanMove : MonoBehaviour {
    public CharacterController playerCharContr;
    public Rigidbody rig;
    public float speedMove,speedRot;
    public Animator animator;
    public GameObject g;
	// Use this for initialization
	void Start () {
        //playerCharContr = gameObject.GetComponent<CharacterController>();
        rig = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        //rig.velocity = new Vector3(moveH, 0, moveV) * speed;
        Vector3 movement = transform.forward * moveV;
        rig.MovePosition(transform.position + movement * speedMove * Time.deltaTime);
        rig.MoveRotation(transform.rotation * Quaternion.Euler(0, moveH * speedRot, 0));
        if (moveV!=0)
        {
            animator.SetBool("IsMove", true);
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetFloat("Speed", moveV*2);
                rig.MovePosition(transform.position + movement * speedMove * Time.deltaTime*2);
                return;
            }
            animator.SetFloat("Speed",moveV);
            rig.MovePosition(transform.position + movement * speedMove * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMove", false);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Skill1");
            
        }




        //playerRig.MoveRotation(Quaternion.Euler(new Vector3(0, Hmove * Time.deltaTime * speedRot, 0)));
    }
    void MySkill1()
    {
        Instantiate(g, transform);
        Camera.main.DOShakePosition(0.5f);
    }
}
