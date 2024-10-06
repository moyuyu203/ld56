using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Antopia {
    public class AntColonyInfo : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI m_NumberOfWorkers;
        [SerializeField] private TextMeshProUGUI m_NumberOfSoldiers;
        [SerializeField] private TextMeshProUGUI m_RemainingFood;


        private void Update() {
            m_NumberOfWorkers.text = AntColony.instance.numberOfAntWorkersAvailable.ToString() + "/" + AntColony.instance.numberOfAntWorkers.ToString();

            m_RemainingFood.text = AntColony.instance.remainingFood.ToString();
        }
    }
}
