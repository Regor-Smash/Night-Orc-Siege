using Godot;
using System;

public partial class PlayerMove : CharacterBody2D
{
	[Export]
	private const float Speed = 300.0f;

	public static PlayerMove Instance { get; private set; }

	public override void _Ready()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			GD.PrintErr("There are two players");
		}
	}

	public override void _ExitTree()
	{
		if(Instance == this) { Instance = null; }
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 newVelocity = Vector2.Zero;

		// Get the input direction
		Vector2 direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
		if (direction != Vector2.Zero)
		{
			//If moving, set velocity
			newVelocity = direction * Speed;
		}

		this.Velocity = newVelocity;
		MoveAndSlide();
	}
}