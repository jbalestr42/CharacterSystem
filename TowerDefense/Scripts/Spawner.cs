using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject _nextPoint;
    public bool IsOver = false;

	public void StartSpawn(WaveData p_waveData) {
        IsOver = false;
        StartCoroutine(Spawn(p_waveData));
	}

    IEnumerator Spawn(WaveData p_waveData) {
        int count = p_waveData._count;
        while (count > 0) {
            Enemy enemy = FindObjectOfType<GameManager>().GetNewEnemy(p_waveData._gameObject);
            enemy.transform.position = transform.position;
            enemy.SetDestination(_nextPoint);
            count--;
            yield return new WaitForSeconds(p_waveData._interval);
        }
        IsOver = true;
        FindObjectOfType<GameManager>().EndLevel();
    }	
}
