using Godot;

public partial class Player : CharacterBody2D
{
	private Vector2 InitialPosition;
	private float speed = 25;

	public override void _Ready()
	{
		Position = new Vector2(Position.X, GetViewport().GetVisibleRect().Size.Y / 2);
	}

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Vector2.Zero;

		// Move the player
		if (Input.IsActionPressed("ui_up"))
			velocity.Y -= speed;
		else if (Input.IsActionPressed("ui_down"))
			velocity.Y += speed;

		MoveAndCollide(velocity * speed * (float)delta);
	}
}
