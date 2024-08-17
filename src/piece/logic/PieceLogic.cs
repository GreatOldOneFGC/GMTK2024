namespace GMTKJam;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public interface IPieceLogic : ILogicBlock<PieceLogic.State>;

[Meta]
[LogicBlock(typeof(State), Diagram = true)]
public partial class PieceLogic : LogicBlock<PieceLogic.State>, IPieceLogic
{
    public override Transition GetInitialState() => To<State.Released>();

    public static class Input
    {
        // Inputs should be readonly record structs.
        public readonly record struct Grab;
        public readonly record struct Release;
        public readonly record struct PhysicsTick(double delta);
    }

    public static class Output
    {
        // Outputs should be public readonly record structs.
    }

    public record Data
    {
        public float DragSpeed { get; set; }
    }

    public abstract partial record State : StateLogic<State>
    {
        private IPiece Piece => Get<IPiece>();
        private Data Data => Get<Data>();

        [Meta]
        public partial record Released : State, IGet<Input.Grab>
        {
            public Released()
            {
                this.OnEnter(() =>
                {
                    Piece.Freeze = false;
                });
            }
            public Transition On(in Input.Grab input) => To<Grabbed>();
        }

        [Meta]
        public partial record Grabbed : State, IGet<Input.Release>, IGet<Input.PhysicsTick>
        {
            public Grabbed()
            {
                this.OnEnter(() =>
                {
                    Piece.Freeze = true;
                });
            }
            public Transition On(in Input.Release input) => To<Released>();

            public Transition On(in Input.PhysicsTick input)
            {
                Piece.GlobalTransform = Piece.GlobalTransform with { Origin = Piece.GetGlobalMousePosition() };
                return ToSelf();
            }
        }
    }
}
