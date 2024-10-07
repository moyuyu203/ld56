using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "EnemySO", menuName = "Antopia/Enemy")]
    public class EnemySO : ScriptableObject {
        public string enemyName;
        public int chanceToBeFound = 33;
        public int maxHp;
        public int food;
    }
}