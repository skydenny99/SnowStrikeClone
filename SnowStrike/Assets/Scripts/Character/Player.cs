using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Character {
    
    //body condition
    public int HP;
    public int bodyTemp;
    public int cold;
    public int freezing;
    public int freeze2death;

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
    private List<Equipment> equipmentList = new List<Equipment>();
    
    //Equipment currentEquipment;
    //Equipment[] equipList;
    int currentIndex = 0;

    //Animation Controller
    private Animator _anim;


    // Use this for initialization
    void Start() {
        _rig = transform.GetComponent<Rigidbody2D>();
        _anim = transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveWithoutForce();

        if (Input.GetKeyDown(KeyCode.Z))
            Attack();

        if (Input.GetKeyDown(KeyCode.X))
            SwapWeapon();
 
	}

    public void MoveWithoutForce()
    {
        float axis = Input.GetAxis("Horizontal");
        Vector2 v = new Vector2(axis * acceleration * Time.deltaTime, 0);

        _rig.transform.Translate(v);
        _anim.SetFloat("Speed", Mathf.Abs(axis));

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpAble)
        {
            _rig.velocity = new Vector2(_rig.velocity.x, jumpPower);
            _anim.SetTrigger("Jump");
        }
    }

    public void Move()
    {
        float axis = Input.GetAxis("Horizontal");
        Vector2 v = new Vector2(axis * acceleration, 0);
        _rig.AddForce(v);

        float temp = Mathf.Clamp(_rig.velocity.x, -maxSpeed, maxSpeed);
        if (Mathf.Abs(axis) < 0.8)
            temp = Mathf.SmoothDamp(temp, 0, ref _vx, toZero);
        _rig.velocity = new Vector2(temp, _rig.velocity.y);
        
        _anim.SetFloat("Speed", Mathf.Abs(axis));

        if(Input.GetKeyDown(KeyCode.UpArrow) && jumpAble)
        {
            _rig.velocity = new Vector2(_rig.velocity.x, jumpPower);
            _anim.SetTrigger("Jump");
        }
    }

    public bool isGrounded()
    {
        return false;
    }

    public void Attack()
    {
        //장비 호출해서 공격
        //currentWeapon.Attack();
        _anim.SetTrigger("Attack");
    }

    public void SwapWeapon()
    {
        //장비를 다음 것으로 전환
        //index를 1추가하여 다음것과 교체
        _anim.SetInteger("Index", currentIndex);
        _anim.SetTrigger("Swap");
    }

    public void IsGrounded(bool grounded)
    {
        jumpAble = grounded;
        _anim.ResetTrigger("Jump");
        _anim.SetBool("IsGrounded", grounded);
    }
    
    public void Damaged(int amount)
    {
        HP -= amount;
    }

    public void GettingCold(int amount)
    {
        bodyTemp -= amount;
        if (bodyTemp <= cold)
        {

        }
        else if(bodyTemp <= freezing)
        {

        }
        else if(bodyTemp <= freeze2death)
        {

        }
    }
    
    //animation event function
    //this function should be called end of every attack motion
    public void resetAttack()
    {
        _anim.ResetTrigger("Attack");
    }

    //this function should be called end of every swap motion
    public void resetSwap()
    {
        _anim.ResetTrigger("Swap");
    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            Equipment item = collision.gameObject.GetComponent<Equipment>();
            if (item == null)
                return;
            
            foreach(Equipment eq in equipmentList)
            {
                if(eq.getName().Equals( item.name ))
                {
                    eq.addlevel(1);
                    break;
                }
            }


            Destroy(collision.gameObject);


            /*
            Item item = collision.gameObject.GetComponent<Item>();
            Debug.Assert(item != null);
            
            if (item is Ownable)
            {

                (item as Ownable).own();
                // add to inventory;
                // own code;
            }
            else if (item is Usable) 
            {
                // 가질 수 없다면 바로 써버린다
                (item as Usable).use();
                // use code;
            }

            Destroy(collision.gameObject);*/
        }
    }
}
