using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Antopia {
    public class AntColony : MonoBehaviour {
        public static AntColony instance { get; private set; }

        public int numberOfAntWorkers { get { return m_AntWorkersPool.Count; } }
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

        [SerializeField] private AntWorker m_AntWorkerPrefab;

        public Graph graph { get; set; }
        public int remainingFood { get;  set; }
        private List<AntWorker> m_AntWorkersPool = new List<AntWorker>();

        private float m_TimeTillNextFoodReduction;

        private void Awake() {
            Assert.IsNull(instance);

            instance = this;
        }

        private void Start() {
            for(int i = 0; i < m_ColonySetting.startingWorkers; i++) {
                AntWorker worker = Instantiate(m_AntWorkerPrefab);
                m_AntWorkersPool.Add(worker);
                worker.Deactivate();

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


    }
}
