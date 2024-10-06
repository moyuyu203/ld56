using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "AntWorkerSettingSO", menuName = "Antopia/AntWorkerSetting")]
    public class AntWorkerSettingSO : ScriptableObject {
        public float moveSpeed = 0.3f;
        public float collectingFoodDuration = 5f;
        public int collectingFoodAmount = 5;


    }
}
