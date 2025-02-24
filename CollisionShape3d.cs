using Godot;
using System;

public partial class CollisionShape3d : Area3D
{

	public override void _Ready()
	{
		AreaEntered += OnBodyEntered;
		
	}


	private void OnBodyEntered(Node3D body)
	{
		GD.Print("I am a box and " + body.Name + "was mean to me");
		body.QueueFree();
		// Something hit me
	}
}
