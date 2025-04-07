using Godot;
using System;
using static Godot.GD;

public partial class ObstacleSpawner : Node3D
{
	
	private PackedScene chickenScene = GD.Load<PackedScene>("res://chicken.tscn");

	[Export]
	public float spawnInterval = 0.25f;

	RandomNumberGenerator rng = new RandomNumberGenerator();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		spawnInterval -= (float)delta;
		if(spawnInterval <= 0) {
			SpawnChicken();
			spawnInterval = rng.RandfRange(0.085f, 2.5f);
		}	
	}

	private void SpawnChicken() {
		Node3D instance = (Node3D)chickenScene.Instantiate();
		AddChild(instance);
		instance.GlobalPosition = GlobalPosition;
		//Print("Spawned instance " + instance.Name);
	}
}
