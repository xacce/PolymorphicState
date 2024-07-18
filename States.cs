using Trove.PolymorphicStructs;

namespace PolymorphicState
{
    [PolymorphicStruct]
    public partial struct IdleState : IStateData
    {
    }

    [PolymorphicStruct]
    public partial struct MoveState : IStateData
    {
    }
}