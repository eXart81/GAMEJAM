using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VaguesManager : MonoBehaviour
{
    // ... (autre code)

    public GameManager gameManager;

    [SerializeField] GameObject chemin;

    public Wave[] waves;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private Text waveCountdownTimer;

    private int waveIndex = 0;

    // Utilisez plutôt une propriété privée pour stocker le nombre d'ennemis vivants.
    private int enemiesAlive;

    public int EnemiesAlive
    {
        get { return enemiesAlive; }
        set { enemiesAlive = value; }
    }

    private PlayerStats playerStats;

    private void Start()
    {
        EnemiesAlive = 0;  // Assurez-vous d'initialiser le nombre d'ennemis vivants.
        playerStats = GetComponent<PlayerStats>();
    }

    public void DecrementEnemiesAlive()
    {
        EnemiesAlive--;
    }

    public void StartNextWave()
    {
        // Vérifiez si une vague est en cours ou si on a terminé toutes les vagues
        if (EnemiesAlive <= 0 && waveIndex < waves.Length)
        {
            StartCoroutine(SpawnWave());
        }
    }

    void Update()
    {
        // Utilisez "EnemiesAlive" au lieu de "DecrementEnemiesAlive".
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

    }

    IEnumerator SpawnWave()
    {
        playerStats.Rounds++;

        Wave wave = waves[waveIndex];

        int[] totalCounts = new int[wave.subwaves.Length];
        EnemiesAlive = wave.GetTotal();
        for (int i = 0; i < wave.GetTotal(); i++)
        {
            int prefabToPickFrom;
            do
            {
                prefabToPickFrom = Random.Range(0, wave.subwaves.Length);
            }
            while (totalCounts[prefabToPickFrom] == wave.subwaves[prefabToPickFrom].count);

            totalCounts[prefabToPickFrom]++;

            SpawnEnemy(wave.subwaves[prefabToPickFrom].enemy);
            yield return new WaitForSeconds((1f / (wave.rate)) + wave.subwaves[prefabToPickFrom].rateOffset+Random.Range(0f,0.15f));
        }
       
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        AgentNavigation ag = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation, transform).GetComponent<AgentNavigation>();
        if (ag != null)
        {
            Debug.Log(ag.name);
            ag.chemin = chemin;
        }
    }
}
