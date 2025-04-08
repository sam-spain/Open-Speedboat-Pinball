using Godot;
using System;

public partial class Chicken : CharacterBody3D
{

	[Export]
	public int Speed { get; set; } = 125;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	private Vector3 _targetVelocity = Vector3.Zero;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		_targetVelocity.X = -1 * Speed;
		Velocity = _targetVelocity;
		MoveAndSlide();
	}

}
