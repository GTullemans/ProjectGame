using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XBOXParty;

public class PlayerMovement : MonoBehaviour {
    private InputManager _Input;
    [SerializeField] private float _MaxSpeed;
    [SerializeField] private float _TurnSpeed;
    [SerializeField] private float _Acceleration;
    [SerializeField] private float _Deceleration;
    [SerializeField] private float _BreakDeceleration;
    private float _Turndir;
    private float _Speed;
    private Vector3 _Dir;
    
    [SerializeField] private int _PlayerNumber;

    private bool gas;
    private bool rem;
    // Use this for initialization
    void Start () {
        _Input = InputManager.Instance;
        _PlayerNumber--;
        _Input.BindAxis("LRMovement", KeyCode.D, KeyCode.A);
        _Input.BindButton("Gas", KeyCode.W, ButtonState.Pressed);
        _Input.BindButton("Break", KeyCode.S, ButtonState.Pressed);
        _Input.BindAxis("LRMovement2", KeyCode.RightArrow, KeyCode.LeftArrow);
        _Input.BindButton("Gas2", KeyCode.UpArrow, ButtonState.Pressed);
        _Input.BindButton("Break2", KeyCode.DownArrow, ButtonState.Pressed);
        _Input.BindButton("F1", KeyCode.Alpha1, ButtonState.OnPress);
        _Input.BindButton("F2", KeyCode.Alpha2, ButtonState.OnPress);

    }

    // Update is called once per frame
    void Update () {
        if (_Input.GetButton("F1"))
         {
            if (_PlayerNumber == 0)
            {
                _Input.BindAxis("LRMovement", KeyCode.D, KeyCode.A);
                _Input.BindButton("Gas", KeyCode.W, ButtonState.Pressed);
                _Input.BindButton("Break", KeyCode.S, ButtonState.Pressed);
            }

            if (_PlayerNumber == 1)
            {
                _Input.BindAxis("LRMovement2", KeyCode.RightArrow, KeyCode.LeftArrow);
                _Input.BindButton("Gas2", KeyCode.UpArrow, ButtonState.Pressed);
                _Input.BindButton("Break2", KeyCode.DownArrow, ButtonState.Pressed);
            }

        }

        if (_Input.GetButton("F2"))
        {
            _Input.BindAxis("LRMovement", _PlayerNumber, ControllerAxisCode.LeftStickX);
            _Input.BindButton("Gas", _PlayerNumber, ControllerButtonCode.A, ButtonState.Pressed);
            _Input.BindButton("Break", _PlayerNumber, ControllerButtonCode.X, ButtonState.Pressed);

            
        }
        if (_PlayerNumber == 0)
        {
            _Turndir = _Input.GetAxis("LRMovement");
            rem = _Input.GetButton("Break");
            gas = _Input.GetButton("Gas");
        }
        else if(_PlayerNumber == 1)
        {
            _Turndir = _Input.GetAxis("LRMovement2");
            rem = _Input.GetButton("Break2");
            gas = _Input.GetButton("Gas2");
        }


        if (gas)
        {
            
            

            if (_Speed >= _MaxSpeed)
            {
                _Speed = _MaxSpeed;
            }
            else
            {
                _Speed += _Acceleration;
            }

        }
        else if (rem)
        {
            _Speed *= _BreakDeceleration;

        }
        else
        {
            _Speed *= _Deceleration;
        }


        if (_Speed < 1)
        {
            _Speed = 0;
        }

        _Dir.x = _Turndir * _TurnSpeed;
        _Dir.z = _Speed;

       transform.Translate(_Dir * Time.fixedDeltaTime);
    }

    public float GetSpeed()
    {
        float sideSpeed = _Dir.x;
        

        return Mathf.Abs(sideSpeed);

    }
    
}
