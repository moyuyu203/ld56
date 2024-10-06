using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Antopia {
    public class AntColony : MonoBehaviour {
        
        
        public static AntColony instance { get; private set; }

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

        [SerializeField] private int m_StartAntWorkers = 2;
        [SerializeField] private Creature m_AntWorkerPrefab;

        public Graph graph { get; set; }
        private List<Creature> m_AntWorkersPool = new List<Creature>();


        private void Awake() {
            Assert.IsNull(instance);

            instance = this;
        }

        private void Start() {
            for(int i = 0; i < m_StartAntWorkers; i++) {
                Creature worker = Instantiate(m_AntWorkerPrefab);
                m_AntWorkersPool.Add(worker);
                worker.Deactivate();

            }
        }

        public Creature RequestAntWorker() {
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
