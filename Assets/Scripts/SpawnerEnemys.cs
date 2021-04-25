using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemys : MonoBehaviour
{
	public GameObject[] enemys;

	public Vector2 sppos;
	private int random;
	private float timeBTWSpawn;
	public float starttimeBTWSpawn;
	public float minTime;
    public float minimumTime;
    public float minustime;

    public float timeBTWheartSpawn;
    public float starttimeBTWheartSpawn;
    public float minushearttime;

    void Start()
	{
		timeBTWSpawn = starttimeBTWSpawn;
	}

	void FixedUpdate()
	{
        if (timeBTWheartSpawn > 0)
        {
            timeBTWheartSpawn -= minushearttime;
        }
        else
        {
            timeBTWheartSpawn = starttimeBTWheartSpawn;
            Instantiate(enemys[3], sppos, Quaternion.identity);
        }

        if (timeBTWSpawn < 0f)
		{
			random = Random.Range(0, 3);
			Instantiate(enemys[random], sppos, Quaternion.identity);
			timeBTWSpawn = starttimeBTWSpawn;
		}
        else
		{
			timeBTWSpawn = timeBTWSpawn - minTime;
		}
        if (starttimeBTWSpawn > minimumTime)
        {
            starttimeBTWSpawn -= minustime * Time.deltaTime;
        }

	}
}
