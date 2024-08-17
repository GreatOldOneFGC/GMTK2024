namespace GMTKJam;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;

using Godot;

public interface IGame : INode;

[Meta(typeof(IAutoNode))]
public partial class Game : Node, IGame
{
	public override void _Notification(int what) => this.Notify(what);

	#region Constants

	#endregion

	#region Save

	#endregion

	#region Provisions

	#endregion

	#region Dependencies

	#endregion

	#region Exports

	#endregion

	#region Nodes

	#endregion

	#region State

	#endregion

	#region Private Fields

	#endregion

	#region Public Fields

	#endregion

	#region IAutoNode

	public void Initialize()
	{
		// Called before OnReady. Perform non-Node setup here.
		//this.Provide();
	}

	public void OnReady()
	{
		// Called when the node enters the scene tree.
	}

	public void Setup()
	{
		// Called after dependencies are resolved, but before OnResolved.
	}

	public void OnResolved()
	{
		// Called after dependencies are resolved.
	}

	public void OnExitTree()
	{
		// Called when the node is about to leave the scene tree.
	}

	public void OnProcess(double delta)
	{
		// Called every frame.
	}

	public void OnPhysicsProcess(double delta)
	{
		// Called every physics frame.
	}

	#endregion

	#region Public Methods

	#endregion

	#region Private Methods

	#endregion
}

