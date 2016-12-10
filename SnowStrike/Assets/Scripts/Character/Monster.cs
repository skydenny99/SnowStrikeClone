using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, Character {

    public int HP;

    //Horizontal movement
    public float acceleration;
    private Rigidbody2D _rig;

    //Attack
    public int damage;
    public float range;
    public float delay;
    private float attackTimer;

    //Suicide
    public float explosiveRange;

    private GameObject _player;
    private GameObject _campFire;
    private Transform _transform;

    private Animator _anim;

    // Use this for initialization
    void Start ()
    {
        attackTimer = delay;
        _transform = transform;
        _rig = _transform.GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _campFire = GameObject.FindGameObjectWithTag("Camp Fire");
        _anim = _transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        attackTimer += Time.deltaTime;
        Vector2 pos = _player.transform.position;
        if((pos.x-_transform.position.x)*_transform.localScale.x < 0)
        {
            if (range > Vector2.Distance(_transform.position, _player.transform.position))
                if(delay < attackTimer)
                {
                    attackTimer = 0;
                    _anim.SetTrigger("Attack");
                }
        }
        if(!_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
         Move();


        if (HP <= 0)
            Death();

        if (explosiveRange > Vector2.Distance(_transform.position, _campFire.transform.position))
            Suicide();
        
        
    }

    public void Move()
    {
        float axis = -_transform.localScale.x;
        Vector2 v = new Vector2(axis * acceleration * Time.deltaTime, 0);

        _anim.SetTrigger("Walk");
        _transform.Translate(v);
        
    }

    public void Attack()
    {
        _player.SendMessage("Damaged", damage, SendMessageOptions.DontRequireReceiver);
    }

    public void Suicide()
    {
        _campFire.SendMessage("Damaged", damage, SendMessageOptions.DontRequireReceiver);
        //Instantiate(particle, transform.position, Quaternion.identity);
        _anim.SetTrigger("Suicide");
    }

    public void Damaged(int amount)
    {
        HP -= amount;
    }

    public void Death()
    {
        _anim.SetTrigger("Death");
    }

    public void Disappear()
    {
        Destroy(gameObject);
    }
}
