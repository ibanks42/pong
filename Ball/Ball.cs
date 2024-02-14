using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	private float speed = 800;

	private Vector2 velocity = Vector2.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		// Set the ball's position to a random location
		Position = new Vector2(GetViewport().GetVisibleRect().Size.X / 2, GetViewport().GetVisibleRect().Size.Y / 2);

		// Set the ball's velocity to a random direction
		velocity.X = new Random().Next(2) == 0 ? 1 : -1;
		velocity.Y = new Random().Next(2) == 0 ? 0.8f : -0.8f;
	}

	public override void _PhysicsProcess(double delta)
	{
		var collision = MoveAndCollide(velocity * speed * (float)delta);
		if (collision != null)
		{
			var bounce = velocity.Bounce(collision.GetNormal());
			velocity = new Vector2(bounce.X < 0 ? -1 : 1, bounce.Y < 0 ? -1 : 1);

			var characterCollider = collision.GetCollider() as CharacterBody2D;

			if (characterCollider != null)
			{
				var aboveCharacterYAxis = Position.Y > characterCollider.Position.Y;

				velocity.Y = aboveCharacterYAxis ? 1 : -1;
			}

			Velocity = velocity * speed * (float)delta;
		}
	}
}
