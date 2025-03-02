using Godot;
using System;

public partial class ChickenEnter : Area3D
{

	public override void _Ready()
	{
		BodyEntered += _OnBodyEntered;
	}

	private void _OnBodyEntered(Node3D body)
	{
		GD.Print("Chicken " + Name + " hit " + body.Name);
		Player playerScript = body as Player;
		if (playerScript != null)
		{
			playerScript.TakeDamage(10);
		}
		QueueFree();
		// Something hit me
	}
}
