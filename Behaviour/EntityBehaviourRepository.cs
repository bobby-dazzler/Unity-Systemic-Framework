using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;
using Circus;

namespace UnitySystemicFramework {
    public class EntityBehaviourRepository : Repository<EntityBehaviour> {

        public EntityBehaviour Get (EntityBehaviourType behaviourType) {
            if (Count() > 0) {
                IEnumerable all = GetAll();
                foreach(EntityBehaviour item in all) {
                    if (item.behaviourType == behaviourType) {
                        return item;
                    }
                }               
            }
            UnityEngine.Debug.Log("Unable to find requested behaviour type on entity");
            return null;
        }

        public void RemoveBehaviourOfType(EntityBehaviourType behaviourType) {
            if (Count() > 0) {
                IEnumerable all = GetAll();
                foreach(EntityBehaviour item in all) {
                    if (item.behaviourType == behaviourType) {
                        RemoveAt(item.repositoryIndex);
                    }
                }
            }
        }

        public bool RepositoryContains (EntityBehaviourType behaviourType) {
            if (Count() > 0) {
                IEnumerable all = GetAll();
                foreach(EntityBehaviour item in all) {
                    if (item.behaviourType == behaviourType) {
                        return true;
                    }
                }
            }

            return false;           
        }
    }
}
 