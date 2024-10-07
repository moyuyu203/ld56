using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "AntSoldierSettingSO", menuName = "Antopia/AntSoldierSettingSO")]
    public class AntSoldierSettingSO : ScriptableObject {
        public int attackDamage;
        public float attackSpeed;

        public int probabilityToDieAtEachAttack = 40; //40 percent of dying.

    }
}