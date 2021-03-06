﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barebones.Components;
using Barebones.Dependencies;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Meat.Input;

namespace _2dgame.Components
{
    class MainCharacter : EntityComponent, Barebones.Framework.IUpdateable
    {
        float m_Speed;
        PhysicsComponent m_Physics;
        KeyboardReader m_Keyboard;

        public override IEnumerable<Barebones.Dependencies.IDependency> GetDependencies()
        {
            yield return new Dependency<KeyboardReader>(item => m_Keyboard = item);
            yield return new Dependency<PhysicsComponent>(item => m_Physics = item);
        }

        public MainCharacter(float speed)
        {
            m_Speed = speed;
        }

        public void Update(float dt)
        {
            Vector2 vel = m_Physics.LinearVelocity;
            vel.X = 0;
            vel.Y = 0;
            
            if (m_Keyboard.IsKeyDown(Keys.Right))
                vel.X += m_Speed;

            if (m_Keyboard.IsKeyDown(Keys.Left))
                vel.X -= m_Speed;

            if (m_Keyboard.IsKeyDown(Keys.Up))
                vel.Y += m_Speed;

            if (m_Keyboard.IsKeyDown(Keys.Down))
                vel.Y -= m_Speed;


            m_Physics.LinearVelocity = vel * m_Speed;
        }
    }
}
