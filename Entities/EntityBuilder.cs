using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Circus;

namespace UnitySystemicFramework {
    public abstract class EntityBuilder : ScriptableObject {

        public abstract EntityBehaviour AddBehaviourOfType(GameEntity entity, EntityBehaviourType behaviourType);

        public GameEntity CreateEntity(EntityDefinition definition) {
            GameEntity entity = new GameEntity();
            entity.contentName = definition.contentName;
            entity.CreateBehaviourRepostory();
            AddBehaviours(entity, definition);
            return entity;
        }

        public void AddBehaviours(GameEntity entity, EntityDefinition definition) {
            for (int i = 0; i < definition.requiredBehaviours.Count; i++) {
                if (entity.RepositoryContains(definition.requiredBehaviours[i].behaviourType)) {
                    continue;
                } else {
                    EntityBehaviour behaviour = AddBehaviourOfType(entity, definition.requiredBehaviours[i].behaviourType);
                    behaviour.ConfigureFromDefinition(definition.requiredBehaviours[i]);
                    entity.AddBehaviour(behaviour);
                }
            }
        }
    }
}