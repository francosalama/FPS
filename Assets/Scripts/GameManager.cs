using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text txtTotalEnemiesKilled;
    public int totalKills;
    public GameObject enemyContainer;

    float timer;
    public Text txtTimer;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        totalKills = enemyContainer.GetComponentsInChildren<EnemyController>().Length;
        txtTotalEnemiesKilled.text = "Total Enemies: " + totalKills.ToString();
        timer = 0.0f;
        txtTimer.text = "TIME: " + timer.ToString("n2"); 
    }
    public void AddEnemyKill()
    {
        totalKills--;
        txtTotalEnemiesKilled.text = "Total Enemies: " + totalKills.ToString();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        txtTimer.text = "TIME: " + timer.ToString("n2");
    }

}
