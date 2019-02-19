using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFade : MonoBehaviour{
    [SerializeField, Tooltip("フェードの速さ"), Range(0.001f, 0.05f)]
    private float speed;

    public enum FadeState
    {
        SetIn,
        SetOut,
        In,
        Out,
        Complete,
        None
    }

    private SpriteMask fadeMask;
    private FadeState state = FadeState.None;

    // Use this for initialization
    void Start () {
        fadeMask = GetComponent<SpriteMask>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case FadeState.SetIn:
                fadeMask.alphaCutoff = 0;
                state = FadeState.In;
                break;

            case FadeState.In:
                if(fadeMask.alphaCutoff < 1)
                {
                    fadeMask.alphaCutoff += speed;
                }
                else
                {
                    state = FadeState.Complete;
                }
                break;

            case FadeState.SetOut:
                fadeMask.alphaCutoff = 1;
                state = FadeState.Out;
                break;

            case FadeState.Out:
                if (fadeMask.alphaCutoff > 0)
                {
                    fadeMask.alphaCutoff -= speed;
                }
                else
                {
                    state = FadeState.Complete;
                }
                break;

            case FadeState.Complete:
                break;
        }

        if (Input.GetKeyDown(KeyCode.F1))
            ChangeFadeState = FadeState.SetIn;

        if (Input.GetKeyDown(KeyCode.F2))
            ChangeFadeState = FadeState.SetOut;
	}

    public FadeState ChangeFadeState
    {
        get { return state; }
        set { if (state == FadeState.None || state == FadeState.Complete) state = value; }
    }
}
