using System;
using System.Collections.Generic;
using ETAPI.Enums;
using JetBrains.Annotations;
using PluginFramework.Classes;
using UnityEngine;
using VirtualBrightPlayz.SCP_ET.NPCs;
using VirtualBrightPlayz.SCP_ET.NPCs.Interfaces;
using VirtualBrightPlayz.SCP_ET.NPCs.SCP;

namespace ETAPI.Features
{
    public class Entity
    {
        private static Dictionary<Type, Role> roles = new Dictionary<Type, Role>()
        {
            {typeof(SCP008), Role.Scp008},
            {typeof(SCP049), Role.Scp049},
            {typeof(SCP096), Role.Scp096},
            {typeof(SCP106), Role.Scp106},
            {typeof(SCP1499), Role.Scp1499},
            {typeof(SCP173), Role.Scp173},
            {typeof(SCP939), Role.Scp939},
            {typeof(SCP966), Role.Scp966},
            {typeof(NPCClassD), Role.ClassD}
        };
        
        private IEntity entity;
        
        /// <summary>
        /// Create an entity from an IEntity.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        public Entity(IEntity entity)
        {
            this.entity = entity;
        }

        /// <summary>
        /// Get the role of the entity.
        /// </summary>
        public Role Role
        {
            get
            {
                foreach (var component in entity.gameObject.GetComponents<IEntity>())
                {
                    if (component is IPlayer p)
                    {
                        return (Role) p.PlayerController.stats.ClassId;
                    }

                    if (roles.TryGetValue(component.GetType(), out var role))
                    {
                        return role;
                    }
                }
                
                return Role.None;
            }
        }

        /// <summary>
        /// Gets the entity's gameobject.
        /// </summary>
        public GameObject GameObject => this.entity.gameObject;

        /// <summary>
        /// Create a player from the entity. If the entity is not a player, this will return null.
        /// </summary>
        [CanBeNull]
        public Player Player => Player.From(this.GameObject);
        
        /// <summary>
        /// Gets or sets the entity's dimension.
        /// </summary>
        public Dimension CurrentDimension
        {
            get => (Dimension) this.entity.CurrentDimension;

            set => this.entity.CurrentDimension = (int) value;
        }
        
        /// <summary>
        /// Gets the entity's transform.
        /// </summary>
        public Transform Transform => this.GameObject.transform;

        /// <summary>
        /// Gets or sets the entity's position.
        /// </summary>
        public Vector3 Position
        {
            get => this.Transform.position;
            set => this.Transform.position = value;
        }

        /// <summary>
        /// Gets or sets the entity's rotation.
        /// </summary>
        public Quaternion Rotation
        {
            get => this.Transform.rotation;
            set => this.Transform.rotation = value;
        }

        /// <summary>
        /// Gets or sets the entity's scale.
        /// </summary>
        public Vector3 Scale
        {
            get => this.Transform.localScale;
            set => this.Transform.localScale = value;
        }
    }
}