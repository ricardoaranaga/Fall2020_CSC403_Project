﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 1591 // use this to disable comment warnings

namespace Fall2020_CSC403_Project.code
{
    /// <summary>
    /// This is the class for a BattleCharacter
    /// </summary>
    public class BattleCharacter : Character
    {
        /// <summary>
        /// This is the current health for a BattleCharacter
        /// </summary>
        public int Health { get; private set; }
       
        /// <summary>
        /// This is the Template for a BattleCharacter
        /// </summary>
        public Template CharacterTemplate { get; set; }

        /// <summary>
        /// sends the calculated damage to the frmBattle
        /// </summary>
        public event Action<int> AttackEvent;
        /// <summary>
        /// The Battle Character is the handler for combat mechanics
        /// </summary>
        /// <param name="initPos">initial position</param>
        /// <param name="collider">colision box</param>
        public BattleCharacter(Vector2 initPos, Collider collider) : base(initPos, collider)
        {
            CharacterTemplate = new EnemyTemplate();
            SetHPValues();
        }

        /// <summary>
        /// Returns the ammount of damage done by an attack
        /// </summary>
        /// <param name="amount"></param>
        public void OnAttack(int amount)
        {
            int damage = 0;
            switch (CharacterTemplate.Level)
            {
                case 1:
                    damage = CharacterTemplate.firstAttack();
                    break;
                case 2:
                    damage = CharacterTemplate.seccondAttack();
                    break;
                case 3:
                    damage = CharacterTemplate.thirdAttack();
                    break;
                default:
                    damage = 0;
                    break;
            }
            AttackEvent((int)(amount * damage));
        }

        public void SetLevel(int level)
        {
            CharacterTemplate.Level = level;
        }
        //Adds or subtracts from the health pool bounded by MaxHealth and zero
        public void AlterHealth(int amount)
        {
            int hp = Health += amount;
            if (hp <= 0)
            {
                Health = 0;
            }
            else if (hp <= CharacterTemplate.MaxHealth)
            {
                Health = hp;
            }
            else if (hp > CharacterTemplate.MaxHealth)
            {
                Health = CharacterTemplate.MaxHealth;
            }
        }

        public void AlterMAXHealth(int amount)
        {
            CharacterTemplate.MaxHealth += amount;
        }

        public void AlterStrength(int amount)
        {
            CharacterTemplate.Strength += amount;
        }

        public void SetHPValues()
        {
            Health = CharacterTemplate.MaxHealth;
        }
    }
}