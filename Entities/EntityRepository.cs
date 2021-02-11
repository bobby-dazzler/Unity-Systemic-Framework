using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Circus;

namespace UnitySystemicFramework {
        [CreateAssetMenu(menuName="Systems/Entities/Entity Repository")]
        public class EntityRepository : Repository<GameEntity> {
 
        public EntityBuilder entityBuilder;

        public void GetOrCreate(EntityDefinition definition) { 
            GameEntity entity;
            if (allowRecycling) {
                int lastIndex = CacheCount() - 1;
                if (lastIndex >= 0) {
                    entity = GetFromCache();
                } else {
                    entity = CreateEntity(definition);
                } 
            } else {
                entity = CreateEntity(definition);
            }            
            
            Add(entity);
        } 

        GameEntity CreateEntity(EntityDefinition definition) {
            UnityEngine.Debug.Log("Entity Repository creating entity");
            GameEntity entity = entityBuilder.CreateEntity(definition);
            return entity;
        }    
    }
}