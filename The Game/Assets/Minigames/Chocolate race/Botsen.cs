using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botsen : MonoBehaviour {
    [SerializeField] private float _BumpStrength;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Tag 0")
        {
            GameObject Collided = collision.gameObject;
            float collSpeed, yourSpeed;
            collSpeed = Collided.GetComponent<PlayerMovement>().GetSpeed();
            yourSpeed = GetComponent<PlayerMovement>().GetSpeed();
            float dir = Collided.transform.position.x - transform.position.x;
            if (collSpeed > yourSpeed || collSpeed == yourSpeed)
            {
                GetComponent<Rigidbody>().AddForce(-Mathf.Sign(dir) * _BumpStrength, 0, 0, ForceMode.Impulse);
            }
        }
    }
}
