using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class EnemyBase : MonoBehaviour
    {
        public GameObject chillingTroops; // ako su svi oni mrtvi započni spawnovanje
        private bool level2started = false;

        public GameObject enemyHut;
        private bool enemyHutDestroyed = false;
        public GameObject enemyBoss;
        private bool enemyBossDestroyed = false;

        public Transform[] enemySpawnpoints;
        public GameObject enemyPrefab;

        public Transform spawnedTroopsContainer;

        public GameObject altar;

        float spawnTimer = 0;

        private void FixedUpdate()
        {
            if (chillingTroops.transform.childCount == 0)
                level2started = true;

            if (enemyHut == null)
                enemyHutDestroyed = true;
            
            if (enemyBoss == null)
                enemyBossDestroyed = true;

            if (enemyHutDestroyed && enemyBossDestroyed)
                altar.SetActive(true);

            if (level2started && !enemyHutDestroyed)
                HandleSpawnLogic();
        }

        private void HandleSpawnLogic()
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer > 15)
            {
                SpawnEnemies();
                spawnTimer = 0;
            }
        }

        private void SpawnEnemies()
        {
            var somePlayerTroop = GameObject.FindObjectsOfType<Troop>()
                                    .ToList()
                                    .Where(troop => troop.Team == 1) // playerovi
                                    .FirstOrDefault();

            if (somePlayerTroop == null)
                return; // nema trupe, pustićemo ga

            foreach (Transform spawnpoint in enemySpawnpoints)
            {
                var troop = GameObject.Instantiate(enemyPrefab);
                troop.transform.position = spawnpoint.position;
                troop.transform.SetParent(spawnedTroopsContainer);

                var enemyTroop = troop.GetComponent<Troop>();

                enemyTroop.movement.SetDestination(somePlayerTroop.transform.position);

                //troop.GetComponent<Troop>().movement.agent.SetDestination(somePlayerTroop.transform.position);
            }
        }
    }
}
