using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.SharedCore
{
        public abstract class DomainEntity<T> : IDomainEntity
        {
            public T Id { get; set; }

            public bool IsTrantSient()
            {
                return Id.Equals(default(T));
            }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int DeleteFlag { get; set; }
        }
        public interface IDomainEntity
        {
            DateTime DateCreated { get; set; }
            DateTime DateModified { get; set; }

        }
}
