using Trove.PolymorphicStructs;
using Unity.Entities;

namespace PolymorphicState
{
    //This data cant be overrided outside. U can store here any cleanup data for correct exiting
    [PolymorphicStructInterface]
    public interface ISafeStateDate
    {
    }

    //This data will be overrided after state was changed, only runtime parameters
    [PolymorphicStructInterface]
    public interface IStateData
    {
    }

    //Prb useless state, but sometimes need state for deferred data. U cant store here ecb.create or another ecb deferred results
    //This state was never after transiting. Cuase wee need min. one tick for override this state.
    //U can use this data for cleanup data and set it with ecb
    [PolymorphicStructInterface]
    public interface ILazyStateData
    {
    }

    public partial struct LazyStateWrapped : IComponentData
    {
        public LazyStateData data;
    }

    public partial struct SafeStateWrapped : IComponentData
    {
        public SafeStateDate data;
    }

    public partial struct StateWrapped : IComponentData
    {
        public StateData data;

        public void To(StateData state)
        {
            this.data = state;
        }

        public bool Is(StateData.TypeId typeId)
        {
            return data.CurrentTypeId == typeId;
        }
    }

    public partial struct PreviousState : IComponentData
    {
        public StateData.TypeId previous;
    }
}