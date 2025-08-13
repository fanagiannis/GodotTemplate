using Godot;
using System;

public partial class Entity : Node3D
{
	[Export]
	private float health = 100f;
	[Export]
	private float maxHealth = 100f;
	[Export]
	private float stamina = 100f;
	[Export]
	private float maxStamina = 100f;
	//, maxHealth, stamina, maxStamina;
	private Health HP;
	private Stamina Stamina ;
	private bool isDead=false;

	public override void _Ready()
	{
		HP = new Health(health, maxHealth);
		Stamina = new Stamina(stamina,maxStamina);
	}

	public void TakeDamage(float value)
	{
		HP.TakeDamage(value);
	}

	public void DecStamina(float value)
	{
		Stamina.DecStamina(value);
	}

	public bool CheckDeath()
	{
		return isDead;
	}

	public float HealthPoints()
	{
		return HP.Value();
	}

	public float StaminaPoints()
	{
		return Stamina.Value();
	}

}
