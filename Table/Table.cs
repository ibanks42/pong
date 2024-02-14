using Godot;

public partial class Table : Node
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("restart_scene"))
		{
			GetTree().ReloadCurrentScene();
		}
	}
}

