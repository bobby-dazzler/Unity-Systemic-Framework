using System.Collections;
using System.Collections.Generic;
using Circus;

namespace UnitySystemicFramework {
    public class EntityDefinitionBuilder { 
        
        public EntityDefinition Create(string entityName, List<EntityBehaviourType> requiredBehaviourTypes){
            EntityDefinition definition = new EntityDefinition(entityName);
            for (int i = 0; i < requiredBehaviourTypes.Count; i++) {
                definition.requiredBehaviourTypes.Add(requiredBehaviourTypes[i]);
                EntityBehaviourDefinition def = AddBehaviourToEntityDefinition(definition, requiredBehaviourTypes[i]);
            }
            return definition;
        }

        public EntityBehaviourDefinition AddBehaviourToEntityDefinition(EntityDefinition definition, EntityBehaviourType behaviourType) {
            for (int i = 0; i < definition.requiredBehaviours.Count; i++) {
                if (definition.requiredBehaviours[i].behaviourType == behaviourType) {
                    return definition.requiredBehaviours[i];
                }
            }
            EntityBehaviourDefinition newDefinition = new EntityBehaviourDefinition_Default();
            switch(behaviourType) {
                case EntityBehaviourType.Growable: 
                    newDefinition = new EntityBehaviourDefinition_Growable(100, 150);
                    break;
            }

            definition.requiredBehaviours.Add(newDefinition);
            return newDefinition;
        }
    } 
}
