using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Antopia {
    public class AntColony : MonoBehaviour {
        public static AntColony instance { get; private set; }

        public int numberOfAntsAvailable { get; set; }

        private void Awake() {
            Assert.IsNull(instance);

            instance = this;
        }


    }
}
