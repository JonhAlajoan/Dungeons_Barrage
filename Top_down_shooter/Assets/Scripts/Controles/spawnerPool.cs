using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerPool : MonoBehaviour {
	public Wave[] waves;
	public int randomSort;
	Vector3 enemyPositionCorrection;
	public Transform spawnPos;
	Wave currentWave;
	int currentWaveNumber;
	public int enemiesRemainingToSpawn;
	public int enemiesRemainingAlive;
	float nextSpawnTime;

	void Start() {
		enemyPositionCorrection = new Vector3 (spawnPos.position.x,3,spawnPos.position.z);
		randomSort = Random.Range (1, 5);
		NextWave ();
	}

	void Update() {
		enemyPositionCorrection = new Vector3 (spawnPos.position.x,spawnPos.position.y,spawnPos.position.z);

		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

			if (currentWaveNumber <= 7) {
				randomSort = Random.Range (1, 4);
			} else {
				randomSort = Random.Range (1, 6);
			}

			if(randomSort == 1){
				TrashMan.spawn ("WindOrbPrefab", transform.position, transform.rotation);
			}

			if (randomSort == 2) {
				TrashMan.spawn ("prefabCarranca", transform.position, transform.rotation);	

			}

			if (randomSort == 3) {
				TrashMan.spawn ("LightOrbePref 1", transform.position, transform.rotation);
			}

			if (randomSort == 4) {
				TrashMan.spawn ("FrozenOrbePrefa", transform.position, transform.rotation);
			}

			if (randomSort == 5) {
				TrashMan.spawn ("PortalOrbePrefab", transform.position, transform.rotation);
			}

		}
	}

	public void OnEnemyDeath() {
		enemiesRemainingAlive --;
		if (enemiesRemainingAlive == 0 || enemiesRemainingAlive <=3) {
			NextWave();
		}
	}

	void NextWave() {
		currentWaveNumber ++;
		if (currentWaveNumber - 1 < waves.Length) {
			currentWave = waves [currentWaveNumber - 1];
			enemiesRemainingToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemainingToSpawn;
		}
	}

	[System.Serializable]
	public class Wave {
		public int enemyCount;
		public float timeBetweenSpawns;
	}
}
