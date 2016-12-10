using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Item {
    string getName();
    int getItemCode();
    int getLevel();
    void setLevel(int level);
}
