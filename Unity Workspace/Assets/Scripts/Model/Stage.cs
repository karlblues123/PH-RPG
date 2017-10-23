using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stage {

    private int chapterNumber, stageNumber;
    private GameObject[] enemyPrefabs;
    private string[][] waveData;
    
    public GameObject getEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public void setEnemyPrefab(GameObject prefab, int index)
    {
        this.enemyPrefabs[index] = prefab;
    }

    public string[] getWave(int index)
    {
        return this.waveData[index];
    }

    public Stage(int chapterNumber, int stageNumber)
    {
        this.chapterNumber = chapterNumber;
        this.stageNumber = stageNumber;
    }

    
}
