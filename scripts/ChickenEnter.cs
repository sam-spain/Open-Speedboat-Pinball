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
		if (body is Player player)
		{
			player.TakeDamage(10);
		}
		GD.Print($"Chicken {Name} hit {body.Name}");
		QueueFree();
	}
}
