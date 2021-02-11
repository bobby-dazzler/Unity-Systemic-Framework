using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Circus;

namespace UnitySystemicFramework {
    [System.Serializable]
    public abstract class EntityBehaviourDefinition {

        [SerializeField]
        public EntityBehaviourType behaviourType;

        public abstract void Load (EntityBehaviourDefinition load);

        public virtual void DebugBehaviour () {
            Debug.Log(behaviourType);
        }
    }

}
