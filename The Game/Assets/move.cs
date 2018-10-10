using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    [SerializeField] private float _Speed;
    private float _Timer;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        _Timer += Time.deltaTime;
        if (_Timer > 1)
        {
            transform.Translate(0, 0, _Speed * Time.deltaTime, Space.World);
        }
    }
}
