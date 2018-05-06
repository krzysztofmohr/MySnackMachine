﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddInPractice.Logic
{
    public class Snack : Entity
    {
        public virtual string Name { get; protected set; }

        protected Snack() {}

        public Snack(string name) : this()
        {
            this.Name = name;
        }
    }
}
