using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySystemicFramework;

namespace UnitySystemicFramework {
    [CreateAssetMenu(menuName="Systems/Entities/Entity Builder")]
    public class EntityBuilder_Example : EntityBuilder {

        public override EntityBehaviour AddBehaviourOfType(GameEntity entity, EntityBehaviourType type) {
            EntityBehaviour behaviour = new EntityBehaviour_Default();
/*             switch (type) {
                case EntityBehaviourType.Growable:
                    behaviour = new EntityBehaviour_Growable();
                    break;
                case EntityBehaviourType.Harvestable:
                    behaviour = new EntityBehaviour_Harvestable();
                    break;
                case EntityBehaviourType.Raining:
                    behaviour = new EntityBehaviour_Raining();
                    break;
            } */

            return behaviour;
        }
    }
}