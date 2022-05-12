using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [Header("擊殺數文本")]
    public Text killCountText;

    private int currentKillCount;

    private void Start()
    {
        Instance = this;
        InitZombie();
        UpdateKillText(0);
    }
    public void InitZombie()
    {
        GameObject newZombie = Instantiate(zombie, zombiePoint[Random.Range(0, zombiePoint.Length)].position, zombie.transform.rotation);
        Invoke(nameof(InitZombie), nextZombieTime);
    }
    public void OnKill()
    {
        currentKillCount++;
        UpdateKillText(currentKillCount);

    }
    private void UpdateKillText(int value)
    {
        killCountText.text = $"擊殺數 : {value}";
    }
}
