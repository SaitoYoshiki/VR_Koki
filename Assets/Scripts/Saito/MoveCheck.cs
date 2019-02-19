using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCheck : MonoBehaviour
{
    bool beforeMove = false;

    private void Start()
    {
    }
    
    private void Update()
    {
        UpdateIsMove();
    }

    Vector3 beforePosition;

    void UpdateIsMove() {

        bool isMove = false;
        if((beforePosition - transform.position).magnitude >= 0.001f)
        {
            isMove = true;
        }

        //動きだした瞬間なら
        if(beforeMove == false && isMove == true)
        {
            Debug.Log("動いた");
            StartMove();
        }

        //止まった瞬間なら
        if (beforeMove == true && isMove == false)
        {
            Debug.Log("止まった");
            EndMove();
        }

        //位置の更新
        beforePosition = transform.position;
        beforeMove = isMove;
    }

    public UnityEngine.Events.UnityEvent startMoveEvent = new UnityEngine.Events.UnityEvent();

    public void StartMove()
    {
        startMoveEvent.Invoke();
    }

    public UnityEngine.Events.UnityEvent endMoveEvent = new UnityEngine.Events.UnityEvent();

    public void EndMove()
    {
        endMoveEvent.Invoke();
    }
}
