using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTime;
using Circus;
using UnityElasticsearch;

namespace UnitySystemicFramework {
    public abstract class EntityBehaviour : RepositoryContent<EntityBehaviour> {

        //
        // New EntityBehaviour types must be added to the approriate EntityBuilder derived class
        //

        public EntityBehaviourType behaviourType; 

        List<GameEntity> listeners = new List<GameEntity>();

        public abstract void ConfigureBehaviour(GameEntity gameEntity);

        public virtual void Tick(TimeData timeData, bool logToElastic, ElasticsearchData esData) {
            TickBehaviour();
            if (logToElastic) {
                LogToElastic(timeData, esData);
            }
        }

        public virtual void RegisterEntityWithBehaviour(GameEntity entity) {
            if (!listeners.Contains(entity)) {
                listeners.Add(entity);
            } else {
                UnityEngine.Debug.Log("Entity already registered with this behaviour");
            }
        }

        public abstract void TickBehaviour();
        public abstract void LogToElastic(TimeData timeData, ElasticsearchData esData);

        public virtual void SendMessageToListeners(SystemMessage message) {
            for (int i = 0; i < listeners.Count; i++) {
                listeners[i].EntityRecieveMessage(message);
            }
        }
        public abstract void BehaviourReceiveMessage(SystemMessage message);
        
        public abstract void ConfigureFromDefinition(EntityBehaviourDefinition definition);

        

    }
}
