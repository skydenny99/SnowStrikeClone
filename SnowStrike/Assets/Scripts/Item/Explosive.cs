using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

    public float damage;
    public GameObject explosion;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("Monster"))
        {
            /*
            foreach (ContactPoint2D hiit in col.contacts)
            {
                Vector2 hitPoint = hiit.point;
                Instantiate(explosion, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
            }*/
            col.gameObject.SendMessage("Damaged", CalculateDmg());
        }
        Destroy(gameObject);
    }

    int CalculateDmg()
    {
        int dmg = (int)damage;
        return dmg;
    }
}
