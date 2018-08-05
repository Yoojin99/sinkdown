using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue{ //한 사람만 이야기 하는 dialogue
    public string name;
    [TextArea(3,10)]
    public string[] sentences;
}
