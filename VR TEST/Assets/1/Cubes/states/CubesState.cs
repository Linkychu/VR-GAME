using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CubesState : MonoBehaviour
{
    public abstract CubesState RunCurrentState();
}
