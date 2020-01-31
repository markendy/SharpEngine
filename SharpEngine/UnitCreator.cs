using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine
{
    public class Creator
    {
        protected Unit CreateLast(Unit unit_)
        {
            Core.Register_Objects.Add(unit_);
            Drawing.Draw(unit_);
            return unit_;
        }
    }

    public class CreateHumans:Creator
    {      
        public Unit Create_Knight(string name_, double x_, double y_)
        {        
            return CreateLast(new Knight(name_, x_, y_));
        }

        public Unit Create_Archer(string name_, double x_, double y_)
        {
            return CreateLast(new Archer(name_, x_, y_));
        }
    }

    public class CreateOrcs : Creator
    {
        public Unit Create_Warrior(string name_, double x_, double y_)
        {
            return CreateLast(new Warrior(name_, x_, y_));
        }

        public Unit Create_Berserker(string name_, double x_, double y_)
        {
            return CreateLast(new Berserker(name_, x_, y_));
        }
    }
}
