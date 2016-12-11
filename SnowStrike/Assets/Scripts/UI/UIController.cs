using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {

    public Player _player;

    public int selectedIndex = 0;
    public GameObject torch;
    public List<WeaponIcon> weapons = new List<WeaponIcon>();

    private Transform uiTimer;
    // Use this for initialization
    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        uiTimer = transform.FindChild("Timer");
    }
	
	// Update is called once per frame
	void Update () {
        ShowHP();
	}

    public void ShowHP()
    {
        //transform.FindChild("Health").FindChild("Text").GetComponent<Text>().text = _player.HP.ToString();
    }

    public void ShowTimer(float fakeTimer)
    {
        string surviveTime = "생존 시간 : " + (int)(fakeTimer / 60) + "분 " + (int)((int)fakeTimer % 60) + "초";
        uiTimer.GetComponent<Text>().text = surviveTime;

    }
    public void ShowResult(float result)
    {
        string surviveTime = "생존 시간 : " + (int)(result / 60) + "분 " + (int)((int)result % 60) + "초";
        Text resultUI = transform.FindChild("Result").GetComponent<Text>();
        resultUI.text = surviveTime;
        resultUI.gameObject.SetActive(true);
    }

    public void NewWeapon()
    {

    }

    public void LevelUp(int id)
    {
            Text t = null;
            //t = weapons[index].transform.FindChild("Text").GetComponent<Text>();
            int lv = 0;
            string str = t.text;
            int.TryParse(str.Split(' ')[1], out lv);
            t.text = "lv " + (++lv);
            
    }

    public void SelectWeapon()
    {

    }
}
