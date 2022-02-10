using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    private float _tapTimer;
    private float _keyBoardTimer;


    public KeyCode GameButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    
    public bool Jump()
    {
        return TapJump() || JumpKeyboard();
    }

    public bool Run()
    {
        return TapRun() || RunKeyboard();
    }

    private bool TapJump()
    {
        return GetTapType() == PressType.Single;
    }

    private bool TapRun()
    {
        return GetTapType() == PressType.Hold;
    }

    private PressType GetTapType()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _tapTimer = Time.time + 0.2f;
            }

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                if (Time.time >= _tapTimer)
                {
                    return PressType.Hold;
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (Time.time < _tapTimer)
                {
                    return PressType.Single;
                }
            }
        }
        return PressType.None;
    }


    private bool JumpKeyboard()
    {
        return GetKeyboardPressType() == PressType.Single;
    }

    private bool RunKeyboard()
    {
        return GetKeyboardPressType() == PressType.Hold;
    }

    private PressType GetKeyboardPressType()
    {
        if (Input.GetKeyDown(GameButton))
        {
            _keyBoardTimer = Time.time + 0.2f;
        }

        if (Input.GetKey(GameButton))
        {
            if (Time.time >= _keyBoardTimer)
            {
                return PressType.Hold;
            }
        }

        if (Input.GetKeyUp(GameButton))
        {
            if (Time.time < _keyBoardTimer)
            { 
                return PressType.Single;
            }
        }
        
        return PressType.None;
    }
}