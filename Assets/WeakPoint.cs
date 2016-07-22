using UnityEngine;
using System.Collections;

public class WeakPoint : MonoBehaviour {

    float hp = 4; 

    public void Damage()
    {
        hp--;
        if (hp == 0)
            Destroy(gameObject); 
    }
}
