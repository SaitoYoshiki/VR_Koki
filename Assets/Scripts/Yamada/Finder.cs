using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour {

    [SerializeField]
    private List<EnemyData> targets = new List<EnemyData>();
    private float searchAngle = 45.0f;

    public Camera eye;
    public Warning warningScr;
    
    private int front = 0;
    private int back = 0;
    private int right = 0;
    private int left = 0;

    void OnDisable()
    {
        targets.Clear();
    }

	void Awake()
    {
        var serching = GetComponentInChildren<SearchEnemy>();

        // SearchEnemyスクリプトに敵を見つけた時の関数を追加
        serching.Found += Found;
        // SearchEnemyスクリプトに敵を見失った時の関数を追加
        serching.Lost += Lost;
    }

    void Update()
    {
        front = 0;
        back = 0;
        right = 0;
        left = 0;

        foreach (var target in targets)
        {
            GameObject enemy = target.EnemyObj;

            if (enemy == null)
                continue;

            WhereEnemy(target);
        }

        SetDirection();
    }

    // 見つけた
    private void Found(GameObject foundObj)
    {
        GameObject target = foundObj;
        // 索敵範囲内に入ったオブジェクトをターゲットリストに追加
        if(target.tag == "Enemy") {
            if (targets.Find( obj => obj.EnemyObj == foundObj) == null)
                targets.Add(new EnemyData(target));
        }
    }

    // 見失った
    private void Lost(GameObject lostObj)
    {
        GameObject target = lostObj;
        // 索敵範囲外に出たオブジェクトをターゲットリストから削除
        if (target.tag == "Enemy") {
            var lost = targets.Find(obj => obj.EnemyObj == target);

            Debug.Log(lost);
            if (lost != null)
                targets.Remove(lost);
        }
    }


    private void WhereEnemy(EnemyData data)
    {
        Vector3 PlayerPos = this.transform.position;
        Vector3 EnemyPos = data.EnemyPos;

        // 正面に敵がいるかどうか
        /*if(Vector3.Angle((EnemyPos-PlayerPos).normalized, eye.transform.forward) <= 90.0f && eye.transform.rotation.x < -40.0f)
        {
            if (data.EnemyDirection != EnemyData.Direction.FRONT) { 
                data.EnemyDirection = EnemyData.Direction.FRONT;
            }
            front++;
        }*/

        // 後ろに敵がいるかどうか
        if (Vector3.Angle((EnemyPos - PlayerPos).normalized, -eye.transform.forward) <= searchAngle)
        {
            if (data.EnemyDirection != EnemyData.Direction.BACK)
            {
                data.EnemyDirection = EnemyData.Direction.BACK;
            }
            back++;
        }

        // 右に敵がいるかどうか
        else if (Vector3.Angle((EnemyPos - PlayerPos).normalized, eye.transform.right) <= searchAngle)
        {
            if (data.EnemyDirection != EnemyData.Direction.RIGHT)
            {
                data.EnemyDirection = EnemyData.Direction.RIGHT;
            }
            right++;
        }

        // 左に敵がいるかどうか
        else if (Vector3.Angle((EnemyPos - PlayerPos).normalized, -eye.transform.right) <= searchAngle)
        {
            if (data.EnemyDirection != EnemyData.Direction.LEFT)
            {
                data.EnemyDirection = EnemyData.Direction.LEFT;
            }
            left++;
        }
        else
            data.EnemyDirection = EnemyData.Direction.NONE;
    }

    private void SetDirection()
    {
        if (front > 0)
            warningScr.isFront = true;
        else
            warningScr.isFront = false;

        if (back > 0)
            warningScr.isBack = true;
        else
            warningScr.isBack = false;

        if (right > 0)
            warningScr.isRight = true;
        else
            warningScr.isRight = false;

        if (left > 0)
            warningScr.isLeft = true;
        else
            warningScr.isLeft = false;

        if (targets.Count == 0)
        {
            warningScr.isFront = false;
            warningScr.isBack = false;
            warningScr.isLeft = false;
            warningScr.isRight = false;
        }
    }

    // 発見した敵の管理クラス
    private class EnemyData
    {
        // 見つけた敵のゲームオブジェクト
        private GameObject m_enemy = null;
        public enum Direction
        {
            FRONT,
            BACK,
            RIGHT,
            LEFT,
            NONE
        }

        private Direction dir = Direction.NONE;

        public EnemyData( GameObject found )
        {
            m_enemy = found;
        }
        
        public GameObject EnemyObj
        {
            get { return m_enemy; }
        }

        public Vector3 EnemyPos
        {
            get { return m_enemy.transform.parent.transform.position; }
        }

        public Direction EnemyDirection
        {
            get { return dir; }
            set { dir = value; }
        }
    }
}