using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Antopia {
    public class AntColony : MonoBehaviour {
        public static AntColony instance { get; private set; }

        public int numberOfAntWorkers { get { return m_AntWorkersPool.Count; } }

        public int numberOfAntSoldier { get { return m_AntSoldiersPool.Count; } }

        public float foodComsumptionBar { get {
                return m_TimeTillNextFoodReduction / m_ColonySetting.foodReductionTimeInSeconds; 
            } 
        }
        public int numberOfAntSoldiersAvailable { get {
                int count = 0;
                foreach (var soldier in m_AntSoldiersPool) {
                    if (!soldier.isBusy) {
                        count++;
                    }
                }
                return count;

            } 
        }

        public int numberOfAntWorkersAvailable { get {
                int count = 0;
                foreach(var worker in m_AntWorkersPool) {
                    if (!worker.isBusy) {
                        count++;
                    }
                }
                return count;
            } 
        }

        [SerializeField] private AntColonySettingSO m_ColonySetting;
        [SerializeField] private AntSoldier m_AntSoldierPrefab;
        [SerializeField] private AntWorker m_AntWorkerPrefab;

        public Graph graph { get; set; }
        public int remainingFood { get;  set; }
        private List<AntWorker> m_AntWorkersPool = new List<AntWorker>();
        private List<AntSoldier> m_AntSoldiersPool = new List<AntSoldier>();

        private float m_TimeTillNextFoodReduction;

        private void Awake() {
            Assert.IsNull(instance);

            instance = this;
        }

        public void AntDie(AntWorker antWorker) {
            m_AntWorkersPool.Remove(antWorker);

            Destroy(antWorker.gameObject);
        }

        public void AntDie(AntSoldier antSoldier) {
            m_AntSoldiersPool.Remove(antSoldier);

            Destroy(antSoldier.gameObject);
        }

        private void Start() {
            for(int i = 0; i < m_ColonySetting.startingWorkers; i++) {
                AntWorker worker = Instantiate(m_AntWorkerPrefab);
                m_AntWorkersPool.Add(worker);
                worker.Deactivate();

            }

            for (int i = 0; i < m_ColonySetting.startingSoldier; i++) {
                var soldier = Instantiate(m_AntSoldierPrefab);
                m_AntSoldiersPool.Add(soldier);
                soldier.Deactivate();

            }

            remainingFood = m_ColonySetting.startingFood;
            m_TimeTillNextFoodReduction = m_ColonySetting.foodReductionTimeInSeconds;
        }

        private void Update() {
            FoodUpdate();
        }

        private void FoodUpdate() {
            m_TimeTillNextFoodReduction -= Time.deltaTime;

            if(m_TimeTillNextFoodReduction <= 0) {
                m_TimeTillNextFoodReduction = m_ColonySetting.foodReductionTimeInSeconds;

                remainingFood -= m_ColonySetting.baseFoodComsumption + numberOfAntWorkers * m_ColonySetting.workerFoodComsumption;

                if(remainingFood < 0) {
                    remainingFood = 0;
                    Starve();
                }
            }
        }

        private void Starve() {
            Debug.Log("Starve");
            WinManager.instance.Loss();
        }

        public bool CanAddAnt(AntType antType) {
            if(antType == AntType.Worker && remainingFood  >= m_ColonySetting.workerCost) {
                return true;
            }
            if (antType == AntType.Soldier && remainingFood >= m_ColonySetting.soldierCost) {
                return true;
            }

            return false;

        }

        public void AddAnt(AntType antType) {
            if (antType == AntType.Worker && remainingFood >= m_ColonySetting.workerCost) {
                AntWorker worker = Instantiate(m_AntWorkerPrefab);
                m_AntWorkersPool.Add(worker);
                worker.Deactivate();
                remainingFood -= m_ColonySetting.workerCost;
            }
            if (antType == AntType.Soldier && remainingFood >= m_ColonySetting.soldierCost) {
                var soldier = Instantiate(m_AntSoldierPrefab);
                m_AntSoldiersPool.Add(soldier);
                soldier.Deactivate();
                remainingFood -= m_ColonySetting.soldierCost;
            }

        }



        public AntWorker RequestAntWorker() {
            Assert.IsTrue(numberOfAntWorkersAvailable > 0);

            foreach(var worker in m_AntWorkersPool) {
                if (!worker.isBusy) {
                    worker.Setup(graph.homeColony);
                    worker.Activate();
                    return worker;
                }
            }

            return null;
        }
        public AntSoldier RequestAntSoldier() {
            Assert.IsTrue(numberOfAntSoldiersAvailable > 0);

            foreach (var soldier in m_AntSoldiersPool) {
                if (!soldier.isBusy) {
                    soldier.Setup(graph.homeColony);
                    soldier.Activate();
                    return soldier;
                }
            }

            return null;
        }


    }
}
