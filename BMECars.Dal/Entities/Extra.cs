using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.Entities
{
    public class Extra
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CarExtra> CarExtras { get; set; }
    }
}
