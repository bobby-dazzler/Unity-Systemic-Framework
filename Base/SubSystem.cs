using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityTime;
using UnityElasticsearch;
using Nest;

namespace UnitySystemicFramework {
    [CreateAssetMenu(menuName="Systems/Sub System")]
    public class SubSystem : ScriptableObject {
        [HideInInspector]
        public int index; // Assigned in Awake on controller

        [Header("System Settings")]
        public string subSystemName;

        public float tickRate = 1f;

        public TimeData timeData;

        //public EntityBuilderType builderType;

        public bool runOnGameStart = false;

        public bool clearAgentsOnAwake = false;

        public bool recycleEntities = false;

        public bool logToElastic = false;

        public bool debugMode = false;

        [Header("References")]
        public ElasticsearchData esData;

        [Header("Entities")]
        public EntityRepository systemEntites;

        [HideInInspector]
        public float currentTick;

        public void GameLoop () {
            if (systemEntites != null && systemEntites.Count() > 0) {
                for (int i = 0; i < systemEntites.Count(); i++) {
                    DoTick(systemEntites.Get(i));
                }
            }

            if (logToElastic) {
                LogSubSystemDataToElastic();
            }
        }

        public void LogSubSystemDataToElastic() {
            LogData_SubSystem logData = new LogData_SubSystem(index, subSystemName, systemEntites.Count(),DateTime.Now, timeData.currentDayCount, timeData.currentHour, timeData.currentMinute);
            logData.Send(esData);
        }

        public void CreateEntity(EntityDefinition definition) {
            if (systemEntites == null) {
                Debug.Log("No EntityRepository assigned to SubSystem");
            }
            if (systemEntites.entityBuilder == null) {
                Debug.Log("No EntityBuilder assigned to SubSystem.systemEntites");
            }

            systemEntites.GetOrCreate(definition);
        }

        public void DestroyOrRecycleEntity (int index) {
            systemEntites.RemoveAt(index);
        }

        public void DoTick(GameEntity entity) {
            entity.TickAllBehaviour(timeData, logToElastic, esData);
        
        }

        public GameEntity GetEntity(int index) {
            return systemEntites.Get(index);
        }

        public void DebugAllRegisteredAgents () {
            systemEntites.Debug();
        }
    }
}

