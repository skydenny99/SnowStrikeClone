using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour {

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
	}

    void CheckDist()
    {
        float dist = Vector2.Distance(transform.position, _player.transform.position);
        if (minRange < dist)
        {
            _player.GettingCold((int)(dist / 3));
        }
        else
        {
            if(dist != 0)
                _player.GettingCold(-(int)(1/dist));
            
        }
    }
}
