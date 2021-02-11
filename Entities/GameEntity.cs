using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Circus;
using UnityTime;
using UnityElasticsearch;

namespace UnitySystemicFramework {
    [Serializable]
    public class GameEntity : RepositoryContent<GameEntity> {

        EntityBehaviourRepository behaviourRepository;

        public void CreateBehaviourRepostory() {
            behaviourRepository = (EntityBehaviourRepository)ScriptableObject.CreateInstance("EntityBehaviourRepository");
        }

        public void Configure(EntityDefinition definition) {

        } 

        public void TickAllBehaviour (TimeData timeData, bool logToElastic, ElasticsearchData esData) {
            IEnumerable behaviorList = behaviourRepository.GetAll();

            foreach(EntityBehaviour behaviour in behaviorList) {
                behaviour.Tick(timeData, logToElastic, esData);
            }    
        }

        public void EntityRecieveMessage(SystemMessage message) {
            IEnumerable behaviours = behaviourRepository.GetAll();
            foreach(EntityBehaviour behaviour in behaviours) {
                behaviour.BehaviourReceiveMessage(message);
            }
        } 

        public void RegisterEntityWithBehaviourOfType(GameEntity entity, EntityBehaviourType behaviourType) {
            EntityBehaviour behaviour = behaviourRepository.Get(behaviourType);
            if (behaviour != null) {
                behaviour.RegisterEntityWithBehaviour(entity);
            }
        }

        public void AddBehaviour(EntityBehaviour behaviour) {
            behaviourRepository.Add(behaviour);
        }

        public void RemoveBehaviourOfType(EntityBehaviourType behaviourType) {
            behaviourRepository.RemoveBehaviourOfType(behaviourType);
        }

        public bool RepositoryContains(EntityBehaviourType type) {
            if (behaviourRepository.RepositoryContains(type)) {
                return true;
            } else {
                return false;
            }
        }

        public override void Save () {

        }

        public override void Load (GameEntity load) {
            contentName = load.contentName;
        }

        public override void Debug () {
            UnityEngine.Debug.Log("Debugging entity " + contentName);
            behaviourRepository.Debug();
        }
    }
}