using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Usable : Item {
    // 사용 성공시 true
    bool use();
}
