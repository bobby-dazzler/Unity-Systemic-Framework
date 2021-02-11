using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
//using Circus;

namespace UnitySystemicFramework {
    [CreateAssetMenu(menuName="Systems/Entity/Entity Definition Repository")]
    public class EntityDefinitionRepository : Repository<EntityDefinition> {

        public EntityDefinition Create (EntityDefinition create) {
            if (!allowDuplicates && RepositoryContains(create.contentName)) {
                UnityEngine.Debug.Log("Entity Definition Repository already contains a definition for " + create.contentName);
                return null;
            } 
                
            EntityDefinitionBuilder builder = new EntityDefinitionBuilder();
            EntityDefinition definition = builder.Create(create.contentName, create.requiredBehaviourTypes);
            definition.Load(create);
            Add(definition); 

            return definition;
        }
    }
}
