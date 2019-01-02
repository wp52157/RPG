using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCtrl : MonoBehaviour {

    public bool  isActive=false;
    public Animator m_Animator;
    public Transform rightHandObj=null, lookObj=null,rightFootObj=null, leftFootObj = null;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnAnimatorIK()
    {
        if (m_Animator)
        {
            if (isActive)
            {
                if (lookObj)
                {
                    m_Animator.SetLookAtWeight(1);
                    m_Animator.SetLookAtPosition(lookObj.position);
                }
                if (rightHandObj)
                {
                    m_Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    m_Animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    m_Animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    m_Animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }
                if (rightFootObj)
                {
                    m_Animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                    m_Animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
                    m_Animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootObj.position);
                    m_Animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootObj.rotation);
                }
                if (leftFootObj)
                {
                    m_Animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                    m_Animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                    m_Animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootObj.position);
                    m_Animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootObj.rotation);
                }
            }
            else
            {
                m_Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                m_Animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                m_Animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
                m_Animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
                m_Animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
                m_Animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
                m_Animator.SetLookAtWeight(0);
            }
        }
    }
}
