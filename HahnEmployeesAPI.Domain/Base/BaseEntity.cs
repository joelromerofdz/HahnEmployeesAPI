using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnEmployeesAPI.Domain.Base
{
    public abstract class BaseEntity
    {
        private DateTime _created;

        public BaseEntity()
        {
            this.Created = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime Created 
        { 
            get => this._created;
            set => this._created = value;
        }
        public DateTime? Updated { get; set; }
    }
}
