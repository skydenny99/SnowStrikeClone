using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {
    /*
     * 구현되어야 하는 기능
     * 
     * 몬스터 매니저
     * 아이템 매니저
     * 게임 종료
     * 
     */
    public List<MobSpawner> mobSpawnerList = new List<MobSpawner>();
    public ItemManager itemManager;
    public UIController ui;
    public string surviveTime = "";

    public bool isOver = false;

    private float fakeTimer = 0;

    
	// Use this for initialization
	void Start () {
        //ui = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIController>();
        
        surviveTime = "생존 시간 : 0분 0초";
	}
	
	// Update is called once per frame
	void Update () {
        if(!isOver)
            fakeTimer += Time.deltaTime;
        ui.gameObject.SendMessage("ShowTimer", fakeTimer);
	}

    public void GameOver()
    {
        isOver = true;
        ui.ShowResult(fakeTimer);
    }


}
