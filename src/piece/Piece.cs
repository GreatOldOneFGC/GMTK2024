namespace GMTKJam;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;

using Godot;

public interface IPiece : IRigidBody2D;

[Meta(typeof(IAutoNode))]
public partial class Piece : RigidBody2D, IPiece
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

    [Export] private float DragSpeed { get; set; } = 100;

    #endregion

    #region Nodes

    // [Node] private ICollisionShape2D CollisionShape2D { get; set; } = default!;
    // [Node] private ISprite2D Sprite2D { get; set; } = default!;

    #endregion

    #region State

    private IPieceLogic PieceLogic { get; set; } = default!;
    private PieceLogic.IBinding PieceBinding { get; set; } = default!;

    #endregion

    #region Private Fields

    #endregion

    #region Public Fields

    #endregion

    #region IAutoNode

    public void Setup()
    {
        PieceLogic = new PieceLogic();
        PieceLogic.Set(this as IPiece);
        PieceLogic.Set(new PieceLogic.Data { DragSpeed = DragSpeed });

        // Sprite.Texture = DefaultSprite;
        // CollisionShape.Shape = DefaultShape;
    }

    public void OnResolved()
    {
        PieceBinding = PieceLogic.Bind();

        SetPhysicsProcess(true);
    }

    public void OnExitTree()
    {
        PieceLogic.Stop();
        PieceBinding.Dispose();
    }

    public void OnPhysicsProcess(double delta)
    {
        PieceLogic.Input(new PieceLogic.Input.PhysicsTick(delta));
    }

    #endregion

    #region Override Methods

    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event.IsActionPressed(GameInputs.Grab))
        {
            PieceLogic.Input(new PieceLogic.Input.Grab());
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionReleased(GameInputs.Grab))
        {
            PieceLogic.Input(new PieceLogic.Input.Release());
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}

