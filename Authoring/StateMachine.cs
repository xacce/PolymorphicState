#if UNITY_EDITOR
using PolymorphicState;
using Unity.Entities;
using UnityEngine;

namespace PolymorphicState.Authoring
{
    public class StateMachine : MonoBehaviour
    {
        private class StateMachineBaker : Baker<StateMachine>
        {
            public override void Bake(StateMachine authoring)
            {
                var e = GetEntity(TransformUsageFlags.None);
                AddComponent(e, new LazyStateWrapped());
                AddComponent(e, new StateWrapped());
                AddComponent(e, new SafeStateWrapped());
                AddComponent(e, new PreviousState());
            }
        }
    }
}
#endif