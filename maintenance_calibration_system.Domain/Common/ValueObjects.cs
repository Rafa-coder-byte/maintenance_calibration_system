using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Domain.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject)obj;
                
                
                return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
