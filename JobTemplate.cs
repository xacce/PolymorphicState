using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Entities;

namespace PolymorphicState
{
    [BurstCompile]
    [WithAll(typeof(Simulate))]
    internal partial struct StateMachine : IJobEntity, IJobEntityChunkBeginEnd
    {
        public int index;

        [BurstCompile]
        private void Execute(
            ref StateWrapped state,
            ref SafeStateDate safeState,
            ref PreviousState previousState,
            in LazyStateWrapped lazyState,
            Entity entity)
        {
            #region On exit handlers

            switch (previousState.previous)
            {
                case StateData.TypeId.IdleState when !state.Is(StateData.TypeId.IdleState):
                    OnIdleExit();
                    break;
                case StateData.TypeId.MoveState when !state.Is(StateData.TypeId.MoveState):
                    OnMoveExit();
                    break;
            }

            #endregion

            previousState.previous = state.data.CurrentTypeId;

            switch (state.data.CurrentTypeId)
            {
                case StateData.TypeId.IdleState:
                    IdleStateUpdate();
                    break;
                case StateData.TypeId.MoveState:
                    MoveStateUpdate();
                    break;
            }
        }

        private void OnIdleExit()
        {
            throw new System.NotImplementedException();
        }

        private void OnMoveExit()
        {
            throw new System.NotImplementedException();
        }

        private void MoveStateUpdate()
        {
            throw new System.NotImplementedException();
        }

        private void IdleStateUpdate()
        {
            throw new System.NotImplementedException();
        }


        public bool OnChunkBegin(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask,
            in v128 chunkEnabledMask)
        {
            index = unfilteredChunkIndex;
            return true;
        }

        public void OnChunkEnd(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask,
            in v128 chunkEnabledMask, bool chunkWasExecuted)
        {
        }
    }
}