using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GameLoopCoroutine());
    }
    
    private void Update()
    {
    }

    public IEnumerator GameLoopCoroutine()
    {
        yield return StartCoroutine(GameStartCoroutine());
        
        Debug.Log("ゲーム：開始");
        yield return new WaitForSeconds(2.0f);
        Debug.Log("ゲーム：終了");

        yield return StartCoroutine(GameEndCoroutine());
    }


    public IEnumerator GameStartCoroutine()
    {
        Debug.Log("ゲーム開始の演出：開始");
        yield return new WaitForSeconds(2.0f);
        Debug.Log("ゲーム開始の演出：終了");
    }

    public IEnumerator GameEndCoroutine()
    {
        Debug.Log("ゲーム終了の演出：開始");
        yield return new WaitForSeconds(2.0f);
        Debug.Log("ゲーム終了の演出：終了");
    }
}
