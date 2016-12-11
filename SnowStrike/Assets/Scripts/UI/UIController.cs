using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {

    public Player _player;

    public int selectedIndex = 0;
    public GameObject template;
    public Transform showPos;
    public List<GameObject> weaponList = new List<GameObject>();

    private Transform uiTimer;
    // Use this for initialization
    void Start() {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        uiTimer = transform.FindChild("Timer");

    }

    // Update is called once per frame
    void Update() {
        ShowHP();
        ShowFire();
    }

    public void ShowHP()
    {
        Transform g = transform.FindChild("Health");
        g.FindChild("Text").GetComponent<Text>().text = _player.HP.ToString();
        Image i = g.FindChild("Image").GetComponent<Image>();
        i.fillAmount = ((float)_player.HP) / ((float)_player.maxHP);
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

    public void ShowFire()
    {
        
        Transform t = transform.FindChild("Torch").FindChild("Bar");
        float temp = 0f;
        if(_player.torchTimer - _player.duration < 0)
            temp = (1 - (_player.torchTimer / (float)_player.duration)) * 1.5f;
        temp = Mathf.Clamp(temp, 0, 1.5f);
        t.localScale = new Vector3(temp, t.localScale.y, t.localScale.z);
        
    }

    public void NewWeapon(GameObject wp)
    {
        weaponList.Add(wp);
        GameObject obj =Instantiate(template, showPos.position + Vector3.right * weaponList.Count * 20, Quaternion.identity);
        obj.transform.FindChild("Image").GetComponent<Image>().sprite = wp.GetComponent<SpriteRenderer>().sprite;
        obj.transform.FindChild("Text").GetComponent<Text>().text = "lv 1";
    }

    /*public void LevelUp(Weapon eq)
    {
        
        Text t = null;
        foreach(WeaponIcon wi in weapons)
        {
            if (wi.wp.getItemCode() == eq.getItemCode())
                t = wi.transform.FindChild("Text").GetComponent<Text>();
        }
        int id = eq.getItemCode();
        int lv = eq.getLevel();
        string str = t.text;
        int.TryParse(str.Split(' ')[1], out lv);
        t.text = "lv " + (++lv);
            
    }*/

    public void SelectWeapon()
    {

    }
}
