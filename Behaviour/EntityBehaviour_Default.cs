using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySystemicFramework;
using UnityTime;
using UnityElasticsearch;

namespace UnitySystemicFramework {
    public class EntityBehaviour_Default : EntityBehaviour {

        // Dummy behaviour

        public EntityBehaviour_Default() {
            contentName = "Default";
        }

        public override void ConfigureBehaviour(GameEntity gameEntity) {
            
        } 

        public override void TickBehaviour() {
            
        }

        public override void BehaviourReceiveMessage(SystemMessage message) {
            
        }

        public override void LogToElastic(TimeData timeData, ElasticsearchData esData) {
            
        }

        public override void ConfigureFromDefinition(EntityBehaviourDefinition definition) {
        } 

        public override void Save() {

        }
        
        public override void Load(EntityBehaviour load) {

        }

        public override void Debug() {
            
        }
    }
}