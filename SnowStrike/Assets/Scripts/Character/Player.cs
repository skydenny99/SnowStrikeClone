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
    

    //Torch
    public int level = 1;
    public int duration = 10;
    private float torchTimer;
    private Light torchLight;
    private int intensity = 2;

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
    public bool canClimb = false;
    
    //Player Item
    private List<Weapon> weaponList = new List<Weapon>();
    private Weapon currentWeapon;
    public GameObject defaultWeapon;
    int currentIndex = 0;

    //Animation Controller
    private Animator _anim;
    private Vector3 scale;

    //UI
    public GameObject panel;
    private UIController ui;


    // Use this for initialization
    void Start() {
        scale = transform.localScale;
        _rig = transform.GetComponent<Rigidbody2D>();
        _anim = transform.GetComponent<Animator>();
        _oriAcc = acceleration;
        //weaponList.Add()
        torchLight = transform.FindChild("Torch").GetComponent<Light>();
        ui = panel.GetComponent<UIController>();
        if(defaultWeapon != null )
        {
            weaponList.Add(defaultWeapon.GetComponent<Weapon>());
            currentWeapon = weaponList[0];
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        torchTimer += Time.deltaTime;
        if(HP > 0)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Z))
                _anim.SetTrigger("Attack");

            if (Input.GetKeyDown(KeyCode.X))
                SwapWeapon();
        }
        else
            if(!GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isOver)
                Death();

        TorchFliker();
	}

    public void Move()
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

        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(!canClimb&& jumpAble)
            {
                _rig.velocity = new Vector2(_rig.velocity.x, jumpPower);
                _anim.SetTrigger("Jump");
            }
            else if(canClimb)
            {
                _rig.transform.Translate(new Vector2(0, jumpPower * Time.deltaTime));
                _rig.velocity = new Vector2(_rig.velocity.x, 0);
            }
        }
    }
    
    public bool isGrounded()
    {
        return false;
    }

    public void Attack()
    {
        currentWeapon.Attack();
    }

    public void SwapWeapon()
    {
        if(currentIndex == weaponList.Count-1)
            currentIndex = 0;
        else
            currentIndex++;
        currentWeapon = weaponList[currentIndex];
        
        _anim.SetInteger("Index", currentWeapon.getItemCode());
        ui.LevelUp(-1);
        ui.SelectWeapon();
        _anim.SetTrigger("Swap");
      _anim.SetFloat("Attack Speed", weaponList[0].getAttackSpeed());
    }

    public void IsGrounded(bool grounded)
    {
        jumpAble = grounded;
        _anim.ResetTrigger("Jump");
        _anim.SetBool("IsGrounded", grounded);
    }

    public void TorchFliker()
    {
        torchLight.intensity = intensity * (1 - (torchTimer/duration)) + Random.Range(-0.3f, 0.3f);
    }
    
    public void Damaged(int amount)
    {
        HP -= amount;
        HP = Mathf.Clamp(HP, -10, maxHP);
        _anim.SetTrigger("Hurt");
    }

    public void GettingCold(int amount)
    {
        if (duration > torchTimer && amount > 0)
            return;
        else if(amount < 0)
        {
            bodyTemp -= amount;
            bodyTemp = Mathf.Clamp(bodyTemp, 0, maxTemp);
            acceleration = _oriAcc;
            torchTimer = 0;
            return;
        }
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
        HP = 0;
        _anim.SetTrigger("Death");
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver();
        
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
            Weapon item = collision.gameObject.GetComponent<Weapon>();
            if (item == null)
                return;
            
            foreach(Weapon eq in weaponList)
            {
                if(eq.getItemCode() == item.getItemCode())
                {
                    eq.setLevel(eq.getLevel() + 1);
                    break;
                }
            }

            //collision.transform.parent.gameObject.SendMessage("Take");

            Destroy(collision.gameObject);
        }
    }
    public void CanClimb(bool can)
    {
        canClimb = can;
    }
}
