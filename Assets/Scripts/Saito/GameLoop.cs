using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    GameState gameState;

    private void Start()
    {
        gameState = FindObjectOfType<GameState>();
        StartCoroutine(GameLoopCoroutine());
    }
    
    private void Update()
    {
    }

    public IEnumerator GameLoopCoroutine()
    {
        yield return StartCoroutine(GameStartCoroutine());
        
        while(true)
        {
            if(IsGameover())
            {
                yield return StartCoroutine(GameoverEffectCoroutine());
                break;
            }

            if (IsClear())
            {
                yield return StartCoroutine(ClearEffectCoroutine());
                break;
            }

            yield return null;
        }

        yield return StartCoroutine(FadeCoroutine());
    }


    IEnumerator GameStartCoroutine()
    {
        yield return null;
    }

    IEnumerator FadeCoroutine()
    {
        yield return null;
    }

    bool IsGameover()
    {
        return gameState.IsGameOver;
    }

    IEnumerator GameoverEffectCoroutine()
    {
        yield return null;
    }


    bool IsClear()
    {
        return gameState.IsGameClear;
    }

    IEnumerator ClearEffectCoroutine()
    {
        yield return null;
    }
}
