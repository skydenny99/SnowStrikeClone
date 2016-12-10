using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Character {

    //body condition
    public int maxHP;
    public int HP;
    public int maxTemp;
    public int bodyTemp;
    public int cold;
    public int freezing;
    public int freeze2death;

    //Horizontal movement
    public float acceleration;
    private float _oriAcc;
    public float maxSpeed;
 //   public float maxSpeed;

    public float toZero;
    private float _vx;
    private Rigidbody2D _rig;

    //Vertical movement
    public float jumpPower;
    public bool jumpAble = false;
    
    //Player Item
    private List<Equipment> equipmentList = new List<Equipment>();
    private Equipment currentEquipment;
    int currentIndex = 0;

    //Animation Controller
    private Animator _anim;
    private Vector3 scale;


    // Use this for initialization
    void Start() {
        scale = transform.localScale;
        _rig = transform.GetComponent<Rigidbody2D>();
        _anim = transform.GetComponent<Animator>();
        _oriAcc = acceleration;
        //equipmentList.Add()
        currentEquipment = equipmentList[0];
	}
	
	// Update is called once per frame
	void Update () {
        MoveWithoutForce();

        if (Input.GetKeyDown(KeyCode.Z))
            Attack();

        if (Input.GetKeyDown(KeyCode.X))
            SwapWeapon();

        if (HP <= 0)
            Death();
 
	}

    public void MoveWithoutForce()
    {
        float axis = Input.GetAxis("Horizontal");
        Vector2 v = new Vector2(axis * acceleration * Time.deltaTime, 0);
        if (axis > 0)
        {
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }
        else if(axis < 0)
        {
            transform.localScale = scale;
        }
        
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
        // Debug.Log("Swaping Weapon");
        /*if(currentIndex == equipmentList.Count-1)
            currentIndex = (currentIndex+1)%equipmentList.Count;
        else
            currentIndex++;
        currentEquipment = equipmentList[currentIndex];*/

        if (currentIndex == 1)
            currentIndex = (currentIndex + 1) % 2;
        else
            currentIndex++;
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
        HP = Mathf.Clamp(HP, -10, maxHP);
    }

    public void GettingCold(int amount)
    {
        bodyTemp -= amount;

        bodyTemp = Mathf.Clamp(bodyTemp, 0, maxTemp);
        
        if (bodyTemp <= freeze2death)
        {
            Death();
        }
        else if (bodyTemp <= freezing)
        {
            acceleration = _oriAcc * 0.5f;
            Damaged(5);
        }
        else if (bodyTemp <= cold)
        {
            acceleration = _oriAcc * 0.75f;
            Damaged(3);
        }
        else
        {
            acceleration = _oriAcc;
        }
    }
    public void Death()
    {
        //Game Over;
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
                if(eq.itemcode == item.itemcode)
                {
                    eq.level++;
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
