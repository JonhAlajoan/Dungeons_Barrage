using UnityEngine;
using System.Collections;
using RAIN.Core;
using RAIN.Action;
public class Spawner : MonoBehaviour {

	public Wave[] waves;
	public int randomSort;
	Vector3 enemyPositionCorrection;
	public Transform spawnPos;
	Wave currentWave;
	int currentWaveNumber;
	public int enemiesRemainingToSpawn;
	public int enemiesRemainingAlive;
	float nextSpawnTime;
	GameObject sfxController;
	audioController auxSfxController;
	public LightOrbEnemy enemyLight;
	bool isBossAlive;

	void Start()
	{
		sfxController = GameObject.FindWithTag ("audioSource");
		auxSfxController = sfxController.GetComponent<audioController> ();

		enemyPositionCorrection = new Vector3 (spawnPos.position.x,3,spawnPos.position.z);
		randomSort = Random.Range (1, 101);
		isBossAlive = false;

	}

	void Update()
	{
		enemyPositionCorrection = new Vector3 (spawnPos.position.x, spawnPos.position.y, spawnPos.position.z);
		if (enemiesRemainingToSpawn<=0 && !isBossAlive)
		{
			NextWave ();
		}

		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime && !isBossAlive)
		{
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
			randomSort = Random.Range (1, 101);


			if (randomSort > 30)
            { 
				StartCoroutine ("delaySound","drop_Lotus");
				TrashMan.spawn ("WindOrbPrefab", spawnPos.transform.position, spawnPos.transform.rotation);
			}

			if (randomSort <= 10)
			{

				int randomChoose = Random.Range (0, 2);

                switch(randomChoose)
                {
                    case 0:
                        StartCoroutine("delaySound", "DropCarranca");
                        TrashMan.spawn("prefabCarranca", spawnPos.transform.position, spawnPos.transform.rotation);
                        break;

                    case 1:
                        StartCoroutine("delaySound", "drop_Frozen");
                        TrashMan.spawn("FrozenOrbePrefa", spawnPos.transform.position, spawnPos.transform.rotation);
                        break;
                }

			}
				
	
			if (randomSort > 10 && randomSort <= 30) {
               
				int randomChooses = Random.Range (0, 2);
                switch (randomChooses)
                {
                    case 0:
                        StartCoroutine("delaySound", "drop_Portal");
                        TrashMan.spawn("PortalOrbPrefab", spawnPos.transform.position, spawnPos.transform.rotation);
                        break;
                    case 1:
                        StartCoroutine("delaySound", "drop_hammer");
                        LightOrbEnemy newLight = Instantiate(enemyLight, spawnPos.position, spawnPos.rotation);
                        break;
                }
			}

		}
	}
	public void OnEnemyDeath()
	{
		enemiesRemainingAlive--;
	}

	void NextWave()
	{
		currentWaveNumber ++;
		if (currentWaveNumber - 1 < waves.Length)
		{
			if(currentWaveNumber >= 2)
			{
				Random.Range(0, 101);
				enemiesRemainingToSpawn = 0;

			}
			currentWave = waves [currentWaveNumber - 1];
			enemiesRemainingToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemainingToSpawn;
		}
	}
	IEnumerator nextWaveCooldown()
	{
		yield return new WaitForSeconds (10f);
		NextWave ();
	}
	IEnumerator delaySound(string typeSound)
	{
		yield return new WaitForSeconds (0.5f);
		auxSfxController.PlaySFXSounds (typeSound);
	}
	[System.Serializable]
	public class Wave {
		public int enemyCount;
		public float timeBetweenSpawns;
	}

}