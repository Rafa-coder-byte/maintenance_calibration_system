﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Domain.Common
{
    public abstract class Entity
    {
        #region Properties

        public Guid Id { get; set; }

        #endregion
        
        protected Entity() { }
        public Entity(Guid id) 
        { 
            Id = id;
        }
    }
}
