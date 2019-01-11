using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour {

    public enum WarningDir
    {
        FRONT,
        BACK,
        RIGHT,
        LEFT
    }

    private struct WarningUI
    {
        public WarningDir direction;
        public GameObject displayObj;
        public Image image;
        public bool isTransparent;
    }

    WarningUI[] warningUI = new WarningUI[4];

    private float speed = 0.05f;

    private bool WhetherFront = false;
    private bool WhetherBack = false;
    private bool WhetherRight = false;
    private bool WhetherLeft = false;

    // Use this for initialization
    void Start () {
        for(int i=0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;

            switch (obj.name)
            {
                case "front":
                    warningUI[(int)WarningDir.FRONT].direction = WarningDir.FRONT;
                    warningUI[(int)WarningDir.FRONT].displayObj = obj;
                    warningUI[(int)WarningDir.FRONT].image = obj.GetComponent<Image>();
                    break;

                case "back":
                    warningUI[(int)WarningDir.BACK].direction = WarningDir.BACK;
                    warningUI[(int)WarningDir.BACK].displayObj = obj;
                    warningUI[(int)WarningDir.BACK].image = obj.GetComponent<Image>();
                    break;

                case "right":
                    warningUI[(int)WarningDir.RIGHT].direction = WarningDir.RIGHT;
                    warningUI[(int)WarningDir.RIGHT].displayObj = obj;
                    warningUI[(int)WarningDir.RIGHT].image = obj.GetComponent<Image>();
                    break;

                case "left":
                    warningUI[(int)WarningDir.LEFT].direction = WarningDir.LEFT;
                    warningUI[(int)WarningDir.LEFT].displayObj = obj;
                    warningUI[(int)WarningDir.LEFT].image = obj.GetComponent<Image>();
                    break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i=0; i < transform.childCount; i++)
        {
            switch (warningUI[i].direction)
            {
                case WarningDir.FRONT:
                    if (warningUI[i].displayObj.activeSelf != WhetherFront)
                        warningUI[i].displayObj.SetActive(WhetherFront);

                    if (WhetherFront == true)
                    {
                        ChangeColor(i);
                    }
                    else
                    {
                        warningUI[i].image.color = new Color(warningUI[i].image.color.r, warningUI[i].image.color.g,
                                                               warningUI[i].image.color.b, 1.0f);
                    }
                    break;

                case WarningDir.BACK:
                    if (warningUI[i].displayObj.activeSelf != WhetherBack)
                        warningUI[i].displayObj.SetActive(WhetherBack);

                    if (WhetherBack == true)
                    {
                        ChangeColor(i);
                    }
                    else
                    {
                        warningUI[i].image.color = new Color(warningUI[i].image.color.r, warningUI[i].image.color.g,
                                                               warningUI[i].image.color.b, 1.0f);
                    }
                    break;

                case WarningDir.RIGHT:
                    if (warningUI[i].displayObj.activeSelf != WhetherRight)
                        warningUI[i].displayObj.SetActive(WhetherRight);

                    if (WhetherRight == true)
                    {
                        ChangeColor(i);
                    }
                    else
                    {
                        warningUI[i].image.color = new Color(warningUI[i].image.color.r, warningUI[i].image.color.g,
                                                               warningUI[i].image.color.b, 1.0f);
                    }
                    break;

                case WarningDir.LEFT:
                    if (warningUI[i].displayObj.activeSelf != WhetherLeft)
                        warningUI[i].displayObj.SetActive(WhetherLeft);

                    if (WhetherLeft == true)
                    {
                        ChangeColor(i);
                    }
                    else
                    {
                        warningUI[i].image.color = new Color(warningUI[i].image.color.r, warningUI[i].image.color.g,
                                                               warningUI[i].image.color.b, 1.0f);
                    }
                    break;
            }
        }
	}

    private void ChangeColor(int num)
    {
        if(warningUI[num].image.color.a > 0 && !warningUI[num].isTransparent)
        {
            warningUI[num].image.color = new Color(warningUI[num].image.color.r, warningUI[num].image.color.g,
                                                   warningUI[num].image.color.b, warningUI[num].image.color.a - speed);
            if(warningUI[num].image.color.a <= 0)
            {
                warningUI[num].isTransparent = true;
                warningUI[num].image.color = new Color(warningUI[num].image.color.r, warningUI[num].image.color.g,
                                                       warningUI[num].image.color.b, 0);
            }
        }

        if (warningUI[num].image.color.a < 1.0f && warningUI[num].isTransparent)
        {
            warningUI[num].image.color = new Color(warningUI[num].image.color.r, warningUI[num].image.color.g,
                                                   warningUI[num].image.color.b, warningUI[num].image.color.a + speed);
            if (warningUI[num].image.color.a <= 1.0f)
            {
                warningUI[num].isTransparent = false;
                warningUI[num].image.color = new Color(warningUI[num].image.color.r, warningUI[num].image.color.g,
                                                       warningUI[num].image.color.b, 1.0f);
            }
        }
    }

    public bool isFront
    {
        get { return WhetherFront; }
        set { WhetherFront = value; }
    }

    public bool isBack
    {
        get { return WhetherBack; }
        set { WhetherBack = value; }
    }

    public bool isRight
    {
        get { return WhetherRight; }
        set { WhetherRight = value; }
    }

    public bool isLeft
    {
        get { return WhetherLeft; }
        set { WhetherLeft = value; }
    }
}
