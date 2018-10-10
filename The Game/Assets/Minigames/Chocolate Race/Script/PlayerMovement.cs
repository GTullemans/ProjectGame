using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XBOXParty;

namespace ChocolateRace
{

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _Speed;
        private float _Dir;
        
        // Use this for initialization
        void Start()
        {
            
            InputManager.Instance.BindAxis("ChocolateRace_LR", 0, ControllerAxisCode.LeftStickX);
            InputManager.Instance.BindButton("R", KeyCode.D, ButtonState.OnPress);
            InputManager.Instance.BindButton("L", KeyCode.A, ButtonState.OnPress);
            InputManager.Instance.BindButton("Rlos", KeyCode.D, ButtonState.OnRelease);
            InputManager.Instance.BindButton("Llos", KeyCode.A, ButtonState.OnRelease);
        }

        private void FixedUpdate()
        {
            transform.Translate(new Vector3(_Dir * _Speed * Time.fixedDeltaTime, 0, 0));
        }

        private void Input()
        {
            //_Dir = _Input.GetAxis("ChocolateRace_LR"); 
            if (InputManager.Instance.GetButton("R"))
            {
                _Dir = 1;
            }
            if (InputManager.Instance.GetButton("Rlos"))
            {
                _Dir = 0;
            }
            if (InputManager.Instance.GetButton("L"))
            {
                _Dir = -1;
            }
            if (InputManager.Instance.GetButton("Llos"))
            {
                _Dir = 0;
            }
        }
    }
}
