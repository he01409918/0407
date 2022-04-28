using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance;
    public Transform player;
    private void Start()
    {
        Instance = this;
    }
}
