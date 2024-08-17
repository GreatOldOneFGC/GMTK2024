namespace GMTKJam;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public interface IGameLogic : ILogicBlock<GameLogic.State>;

[Meta]
[LogicBlock(typeof(State), Diagram = true)]
public partial class GameLogic : LogicBlock<GameLogic.State>, IGameLogic
{
	public override Transition GetInitialState() => To<State.Disabled>();

	public static class Input
	{
		// Inputs should be readonly record structs.
		public readonly record struct Enable;
		public readonly record struct Disable;
	}

	public static class Output
	{
		// Outputs should be public readonly record structs.
	}

	public record Data
	{
		// Shared data for the LogicBlock goes in here.
	}

	[Meta]
	public abstract partial record State : StateLogic<State>
	{
		[Meta]
		public partial record Disabled : State, IGet<Input.Enable>
		{
			public Transition On(in Input.Enable input) => To<Enabled>();
		}
		[Meta]
		public partial record Enabled : State, IGet<Input.Disable>
		{
			public Transition On(in Input.Disable input) => To<Disabled>();
		}
	}
}
