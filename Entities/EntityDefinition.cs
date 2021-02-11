using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Circus;

namespace UnitySystemicFramework {
        [System.Serializable]
        public class EntityDefinition : RepositoryContent<EntityDefinition> {

        public EntityDefinition (string name) {
            contentName = name;
            requiredBehaviourTypes = new List<EntityBehaviourType>();
            requiredBehaviours = new List<EntityBehaviourDefinition>();
        }

        public List<EntityBehaviourType> requiredBehaviourTypes;
        [SerializeField]
        public List<EntityBehaviourDefinition> requiredBehaviours;

        public EntityBehaviourDefinition GetBehaviourDefinitionOfType(EntityBehaviourType behaviourType) {
            for (int i = 0; i < requiredBehaviours.Count; i++) {
                if (requiredBehaviours[i].behaviourType == behaviourType) {
                    return requiredBehaviours[i];
                }
            }
            return null;
        }

        public override void Save () {
            
        }

        public override void Load(EntityDefinition load) {
            contentName = load.contentName;
            for (int i = 0; i < load.requiredBehaviours.Count; i++) {
                EntityBehaviourDefinition behaviourRequired = load.requiredBehaviours[i];
                for (int j = 0; j < requiredBehaviours.Count; j++) {
                    EntityBehaviourDefinition existingBehaviour = requiredBehaviours[j];
                    if (behaviourRequired.behaviourType == existingBehaviour.behaviourType) {
                        existingBehaviour.Load(behaviourRequired);
                        break;
                    }
                } 
               
                // create the behaviour
                EntityDefinitionBuilder builder = new EntityDefinitionBuilder();
                EntityBehaviourDefinition behaviourDefintion = builder.AddBehaviourToEntityDefinition(this, behaviourRequired.behaviourType);
                behaviourDefintion.Load(behaviourRequired);
            }
        }

        public override void Debug() {
            UnityEngine.Debug.Log("Debugging entity definition: " + contentName);
            UnityEngine.Debug.Log("Has the following behaviours: ");
            for (int i = 0; i < requiredBehaviours.Count; i++) {
                requiredBehaviours[i].DebugBehaviour();
            }
        }
    }
}
