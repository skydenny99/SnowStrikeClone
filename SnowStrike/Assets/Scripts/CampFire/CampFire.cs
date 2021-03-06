﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour {

    public int maxHP;
    public int HP;

    public float minRange;
    public float cycle;

    private Player _player;
    private float _timer = 0;
    private BoxCollider2D _col;

	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _col = transform.GetComponent<BoxCollider2D>();
        _col.size = new Vector2(minRange, _col.size.y);
        _timer = cycle;
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if(_timer > cycle)
        {
            _timer = 0;
            CheckDist();
            
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, (1-((float)HP / (float)maxHP)) * -1.25f);
	}

    void CheckDist()
    {
        float dist = Vector2.Distance(transform.position, _player.transform.position);
        if (minRange < dist)
        {
            _player.GettingCold((int)(dist / 2));
        }
        else
        {
            if(dist != 0)
                _player.GettingCold(-(int)(minRange/dist));
            
        }
    }

    public void Damaged(int amount)
    {
        HP -= amount;
        HP = Mathf.Clamp(HP, -10, maxHP);
    }
}
