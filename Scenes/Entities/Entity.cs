using Godot;
using System;

public partial class Entity : CollisionShape3D
{
	private Health HP=new Health(100f,100f);
	private Stamina Stamina=new Stamina(100f,100f);
}

class Health
	{
		private float currentHealth, maxHealth;
		public Health(float currentValue,float maxValue)
		{
			currentHealth = currentValue;
			maxHealth=maxValue;
		}
		
		public float GetHealth()
		{
			return currentHealth;
		}
	}
	
	class Stamina
	{
		private float currentStamina, maxStamina;
		public Stamina(float currentValue,float maxValue)
		{
			currentStamina = currentValue;
			maxStamina=maxValue;
		}
		
		public float GetStamina()
		{
			return currentStamina;
		}
	}
