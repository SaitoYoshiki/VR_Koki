using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    GameState gameState;

    GameObject clearCanvas;

    CircleFade fade;

    [SerializeField]
    AudioSource resultBGM;

    private void Start()
    {
        fade = FindObjectOfType<CircleFade>();
        clearCanvas = GameObject.Find("[CameraRig]/Camera (head)/ClearCanvas");

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

        fade.ChangeFadeState = CircleFade.FadeState.SetOut;

        while (true)
        {
            if (fade.ChangeFadeState == CircleFade.FadeState.Complete)
            {
                break;
            }
            yield return null;
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }


    IEnumerator GameStartCoroutine()
    {
        fade.ChangeFadeState = CircleFade.FadeState.SetIn;

        while(true)
        {
            if(fade.ChangeFadeState == CircleFade.FadeState.Complete)
            {
                break;
            }
            yield return null;
        }
    }
   

    bool IsGameover()
    {
        return gameState.IsGameOver;
    }

    IEnumerator GameoverEffectCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
    }


    bool IsClear()
    {
        return gameState.IsGameClear;
    }

    IEnumerator ClearEffectCoroutine()
    {
        resultBGM.Play();

        float time = 0.0f;

        clearCanvas.SetActive(true);
        while(true)
        {
            time += 1.0f / 1.0f * Time.deltaTime;
            clearCanvas.GetComponent<CanvasGroup>().alpha = time;

            if(time >= 1.0f)
            {
                break;
            }

            yield return null;
        }

        yield return new WaitForSeconds(2.0f);
    }
}
