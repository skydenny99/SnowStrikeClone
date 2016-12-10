using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Character {

    public int HP;

    //Horizontal movement
    public float acceleration;
    public float maxSpeed;

    public float toZero;
    private float _vx;
    private Rigidbody2D _rig;

    //Vertical movement
    public float jumpPower;
    public bool jumpAble = false;


    //Player Item
    //Equipment currentEquipment;
    //Equipment[] equipList;
    //int currentIndex = 0;

    //Animation Controller
    private Animator _anim;


	// Use this for initialization
	void Start () {
        _rig = transform.GetComponent<Rigidbody2D>();
        _anim = transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();

        if (Input.GetKeyDown(KeyCode.Z))
            Attack();

        if (Input.GetKeyDown(KeyCode.X))
            SwapWeapon();
 
	}

    public void Move()
    {
        float axis = Input.GetAxis("Horizontal");
        Vector2 v = new Vector2(axis * acceleration, 0);
        _rig.AddForce(v);

        float temp = Mathf.Clamp(_rig.velocity.x, -maxSpeed, maxSpeed);
        if(Mathf.Abs(axis) < 0.8)
            temp = Mathf.SmoothDamp(temp, 0, ref _vx, toZero);
        _rig.velocity = new Vector2(temp, _rig.velocity.y);

        if(Input.GetKeyDown(KeyCode.UpArrow) && jumpAble)
        {
            _rig.velocity = new Vector2(_rig.velocity.x, jumpPower);
        }
    }
    
    public void Attack()
    {
        //장비 호출해서 공격
        //currentWeapon.Attack();
    }

    public void SwapWeapon()
    {
        //장비를 다음 것으로 전환
        //index를 1추가하여 다음것과 교체
        
    }

    public void IsGrounded(bool grounded)
    {
        jumpAble = grounded;
    }

    public void Damaged(int amount)
    {
        HP -= amount;
    }

    public void PlayAnimation()
    {

    }
}
