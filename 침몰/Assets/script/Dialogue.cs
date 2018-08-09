using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//한 프레임에 표시되는 이름_대화 쌍
public class Dialogue{ 

    public string name;

    [TextArea(3,10)]
    public string sentences;
}
