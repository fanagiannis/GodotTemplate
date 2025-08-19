using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Entity : Node3D
{
	[Signal]
	public delegate void DamageTakenEventHandler(float value);
	[Signal]
	public delegate void DeathEventHandler();
	[Export]
	private float health = 100f;
	[Export]
	private float maxHealth = 100f;
	[Export]
	private float stamina = 100f;
	[Export]
	private float maxStamina = 100f;
	//, maxHealth, stamina, maxStamina;
	protected Health HP;
	private Stamina Stamina ;
	private bool isDead=false;

	public override void _Ready()
	{
		HP = new Health(health, maxHealth);
		Stamina = new Stamina(stamina,maxStamina);
	}

	public virtual void Heal(float value)
	{
		HP.Heal(value);
	}

	public void TakeDamage(float value)
	{
		//HP.TakeDamage(value);
		EmitSignal(SignalName.DamageTaken, value);
	}

	public virtual void Damage(float value)
	{
		HP.TakeDamage(value);
		GD.Print("ouch");
		if (HP.Value() <= 0)
			EmitSignal(SignalName.Death);
	}

	public virtual void Kill()
	{
		isDead = true;
		SetProcess(false);
		Visible = false;
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
