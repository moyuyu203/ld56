using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Antopia {
    public class AntColonyInfo : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI m_NumberOfWorkers;
        [SerializeField] private TextMeshProUGUI m_NumberOfSoldiers;
        [SerializeField] private TextMeshProUGUI m_RemainingFood;

        [SerializeField] private Image m_FoodBar;


        private void Update() {
            m_NumberOfWorkers.text = AntColony.instance.numberOfAntWorkersAvailable.ToString() + "/" + AntColony.instance.numberOfAntWorkers.ToString();
            m_NumberOfSoldiers.text = AntColony.instance.numberOfAntSoldiersAvailable.ToString() + "/" + AntColony.instance.numberOfAntSoldier.ToString();
            m_RemainingFood.text = AntColony.instance.remainingFood.ToString();

            m_FoodBar.fillAmount = AntColony.instance.foodComsumptionBar;
        }
    }
}
