using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class EnemyStucture
{
    [HideInInspector] public string name;
    public GameObject enemytype;
    public float timetoNextEnemy;
}
[System.Serializable]
public class waves
{
    [HideInInspector] public string name;
    public EnemyStucture[] enemisInwave;
}
public class waveSpawner : MonoBehaviour
{

    public Text wavedisplay;
    public GameObject gameover;
    public GameObject carend;

    [Header("Wave")]
    [SerializeField] int currentwave;
    [SerializeField] bool spawing;
    [NonReorderable]
    [SerializeField] waves[] totalwaves;
    [Header("setup")]
    [SerializeField] Transform spawnpoint;
    [SerializeField] Transform enemyholder;
    [Header("properties")]
    [SerializeField] float timeBetweenWaves;

    float waveCoundown;
    private void OnValidate()
    {
        RewriteArrayes();

    }
    void RewriteArrayes()
    {
        for (int i = 0; i < totalwaves.Length; i++)
        {
            totalwaves[i].name = "wave" + (i + 1);
            for (int x = 0; x < totalwaves[i].enemisInwave.Length; x++)
            {
                totalwaves[i].enemisInwave[x].name = "enemy" + (x + 1);
            }
        }
    }
    void Start()
    {



        spawing = false;
        waveCoundown = timeBetweenWaves;
        currentwave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        wavedisplay.text = string.Format("{0}", currentwave);

        if (!spawing && enemyholder.childCount == 0)
        {
            waveCoundown -= Time.deltaTime;
            if (waveCoundown <= 0)
            {
                currentwave++;
                StartCoroutine(SpawnWave());
               
            }
           
        }

        if (currentwave > 4) { 
            gameover.SetActive(true);
            carend.SetActive(false);
        }
    }
    IEnumerator SpawnWave()
    {
        int WaveIndex = currentwave;
        spawing = true;
        waveCoundown = timeBetweenWaves;
        for (int i = 0; i < totalwaves[WaveIndex - 1].enemisInwave.Length; i++)
        {
            spawnEnemy(totalwaves[WaveIndex - 1].enemisInwave[i].enemytype);
            yield return new WaitForSeconds(totalwaves[WaveIndex - 1].enemisInwave[i].timetoNextEnemy);
        }
        spawing = false;
    }
    void spawnEnemy(GameObject enemy)
    {
        GameObject spawnedEnemy = Instantiate(enemy, spawnpoint.position, Quaternion.identity);
        spawnedEnemy.transform.SetParent(enemyholder);
    }
}
