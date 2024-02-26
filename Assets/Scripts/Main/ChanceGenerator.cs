using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ChanceGenerator
{
    public static bool ThrowACoin(){
        if(UnityEngine.Random.Range(0, 2) == 1)return true;
        else return false;
    }
}
