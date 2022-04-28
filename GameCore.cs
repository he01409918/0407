using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance;
    [Header("生玩家位置")]
    public Transform player;
    [Header("生成殭屍Prefab")]
    public GameObject zombie;
    [Header("生成殭屍的座標")]
    public Transform[] zombiePoint;
    [Header("生成殭屍間隔")]
    public float nextZombieTime = 5;
    private void Start()
    {
        Instance = this;
        InitZombie();
    }
    public void InitZombie()
    {
        GameObject newZombie = Instantiate(zombie, zombiePoint[Random.Range(0, zombiePoint.Length)].position, zombie.transform.rotation);
        Invoke(nameof(InitZombie), nextZombieTime);
    }

}
