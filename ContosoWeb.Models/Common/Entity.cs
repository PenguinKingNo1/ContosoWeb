using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoWeb.Models.Common
{
    public abstract class Entity : IEntity
    {
        public virtual int Id { get; set; } // virtual for future
    }
}
