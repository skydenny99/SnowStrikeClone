using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ownable : Item {
    // 인벤토리에 들어갔을 경우 true
    bool own();
}
