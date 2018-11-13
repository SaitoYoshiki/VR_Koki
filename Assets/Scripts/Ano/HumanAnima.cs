using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnima : MonoBehaviour {
    public enum AnimaList { Wait, Move };
    Animator HumanAnimaData;
    // Use this for initialization
    void Awake()
    {
        HumanAnimaData = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartAnimation(AnimaList.Wait);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartAnimation(AnimaList.Move);
        }

    }
    //各アニメーション再生関数
    public void StartAnimation(AnimaList AnimaSelect)
    {
        switch (AnimaSelect)
        {
            case AnimaList.Wait:
                AllEndAnimation();
                HumanAnimaData.SetBool("Wait", true);
                break;
            case AnimaList.Move:
                AllEndAnimation();
                HumanAnimaData.SetBool("Move", true);
                break;

        }
    }
    //各アニメーション停止関数
    public void EndAnimation(AnimaList AnimaSelect)
    {
        switch (AnimaSelect)
        {
            case AnimaList.Wait:
                HumanAnimaData.SetBool("Wait", false);
                break;
            case AnimaList.Move:
                HumanAnimaData.SetBool("Move", false);
                break;
        }
    }
    //全アニメーション停止関数
    public void AllEndAnimation()
    {
        HumanAnimaData.SetBool("Wait", false);
        HumanAnimaData.SetBool("Move", false);
    }
}
