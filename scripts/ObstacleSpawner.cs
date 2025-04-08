using Godot;
using System;
using static Godot.GD;

public partial class ObstacleSpawner : Node3D
{
	
	private PackedScene chickenScene = GD.Load<PackedScene>("res://scenes/chicken.tscn");

	[Export]
	public float spawnInterval = 0.25f;

	private const float speedIncreaseInterval = 30f;
	private const int speedIncreaseAmountOnInterval = 25;
	private int speedIncreaseAmount = 0;
	private float speedIncreaseTimer = 0f;

	private const float spawnIntervalMin = 0.085f;
	private float spawnIntervalMax = 2.5f;
	private float spawnIntervalDecrement = 0.01f;


	RandomNumberGenerator rng = new RandomNumberGenerator();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		speedIncreaseTimer += (float)delta;
		if(speedIncreaseTimer >= speedIncreaseInterval) {
			speedIncreaseTimer = 0f;
			speedIncreaseAmount += speedIncreaseAmountOnInterval;
			spawnIntervalMax -= spawnIntervalDecrement;
			if(spawnIntervalMax < spawnIntervalMin) {
				spawnIntervalMax = spawnIntervalMin;
			}
		}
		spawnInterval -= (float)delta;
		if(spawnInterval <= 0) {
			SpawnChicken();
			spawnInterval = rng.RandfRange(spawnIntervalMin, spawnIntervalMax);
		}	
	}

	private void SpawnChicken() {
		Node3D instance = (Node3D)chickenScene.Instantiate();
		AddChild(instance);
		Chicken chickenInstance = instance as Chicken;
		if (chickenInstance != null)
		{
			chickenInstance.Speed += speedIncreaseAmount;
		}
		instance.GlobalPosition = GlobalPosition;
	}
}
