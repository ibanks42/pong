using Godot;
using System.Linq;

public partial class Enemy : CharacterBody2D
{
	private Vector2 InitialPosition;
	private float speed = 25;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InitialPosition = Position;
		Position = new Vector2(Position.X, GetViewport().GetVisibleRect().Size.Y / 2);
	}

	public override void _PhysicsProcess(double delta)
	{
		// find ball node and get its position
		var ball = GetTree().GetNodesInGroup("Ball").FirstOrDefault() as Ball;
		if (ball == null)
			return;

		if (ball.Velocity.X < 0) { return; }
		var ballPosition = ball.Position.Y;

		var velocity = new Vector2(0, ballPosition > Position.Y ? speed : -speed);

		MoveAndCollide(velocity * speed * (float)delta);
	}
}
