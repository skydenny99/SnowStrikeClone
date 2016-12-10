using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("Ground"))
            transform.parent.gameObject.SendMessage("IsGrounded", true, SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Ground"))
            transform.parent.gameObject.SendMessage("IsGrounded", false, SendMessageOptions.DontRequireReceiver);
    }
}
