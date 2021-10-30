using NLayerProject.Core.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Core.Models
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
    }
}
