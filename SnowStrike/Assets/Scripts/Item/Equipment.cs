using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : MonoBehaviour, Ownable {
    protected int level = 1;

    public Equipment()
    {
        level = 1;
    }

    public virtual string getName()
    {
        return "Equipment";
    }

    public int getLevel()
    {
        return level;
    }

    public void setLevel(int level)
    {
        this.level = level;
    }
    public void addlevel(int level)
    {
        this.level += level;
    }

    public virtual bool own()
    {
        
        return false;
    }

    public virtual bool attack(int attackType)
    {
        return false;
    }
}
