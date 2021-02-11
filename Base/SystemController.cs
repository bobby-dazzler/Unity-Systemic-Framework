using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTime;

namespace UnitySystemicFramework {
    public class SystemController : MonoBehaviour {
        
        public SubSystem[] subSystems;
        public bool[] subSystemRunning;
        public TimeData timeData;

        void Awake () {
            for (int i = 0; i < subSystems.Length; i++) {
                subSystems[i].systemEntites.Clear();
                subSystems[i].index = i;
                subSystems[i].currentTick = 0;
                subSystemRunning[i] = false;
            }
        }

        void Start () {
            for (int i = 0; i < subSystems.Length; i++) {
                if (subSystems[i].runOnGameStart) {
                    RunGameLoopAtIndex(i);
                }
            }
        }

        public void Update () {
            for (int i = 0; i < subSystems.Length; i++) {
                if (subSystemRunning[i] == true) {
                    if (subSystems[i].currentTick > subSystems[i].tickRate) {
                        subSystems[i].GameLoop();
                        subSystems[i].currentTick = 0;
                    } else {
                        subSystems[i].currentTick += Time.deltaTime * timeData.timeScale;
                    }
                }
            }
        }

        public void RunGameLoopAtIndex(int index) {
/*             subSystemRunning[index] = true;
            StartCoroutine(subSystems[index].GameLoop(this)); */
            subSystems[index].currentTick = 0;
            subSystemRunning[index] = true;
        }

        public void StopGameLoopAtIndex(int index) {
/*             StopCoroutine(subSystems[index].GameLoop(this));
            subSystemRunning[index] = false; */
            subSystems[index].currentTick = 0;
            subSystemRunning[index] = false;
        }
    }
}
