using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, Character {

    public int HP;

    //Horizontal movement
    public float acceleration;
    public float maxSpeed;

    public float toZero;
    private float _vx;
    private Rigidbody2D _rig;

    //Attack
    public int damage;
    public int range;

    //Suicide
    public int iceDamage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move()
    {
        float axis = transform.localScale.x;
        Vector2 v = new Vector2(axis * acceleration, 0);
        _rig.AddForce(v);

        float temp = Mathf.Clamp(_rig.velocity.x, -maxSpeed, maxSpeed);
        temp = Mathf.SmoothDamp(temp, 0, ref _vx, toZero);
        _rig.velocity = new Vector2(temp, _rig.velocity.y);
    }

    public void Attack()
    {
     //   if()
    }

    public void Suicide()
    {
        //Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Damaged(int amount)
    {
        HP -= amount;
    }
}
