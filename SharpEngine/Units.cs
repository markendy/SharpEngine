using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine
{   
    public interface IDraw
    {
        void Draw();
    }

    public abstract class Unit
    {
        List<object> SkillList;
        static Dictionary<string, int> FactionRelations;
        //=================================base
        private int Id;
        public int ID { get; set; }
        private int healsPoint;
        public int HealsPoint { get; set; }
        private int manaPool;
        public int ManaPool { get; set; }
        private int damage;
        public int Damage { get; set; }
        private double x = 10;
        public double X { get; set; }
        private double y = 10;
        public double Y { get; set; }
        private double speed = 1;
        public double Speed { get; set; }
        //================================addition
        private int armor = 1;
        public int Armor { get; set; }
        private string name;
        public string Name { get; set; }
        private string fraction;
        public string Fraction { get; set; }

        public Unit(string name_, double x_, double y_)
        {
            ID = Core.Register_Objects.Count;
            X = x_;
            Y = y_;
            Name = name_;
            Speed = 3;
        }

        public virtual void Draw()
        {
            Interface.graphics.DrawEllipse(Interface.pen, (float)X, (float)Y, 5, 5);
        }

        public virtual void Attack()        
        {

        }
    }    

    public class Knight : Unit
    {
        public Knight(string name_, double x_, double y_) : base(name_, x_, y_)
        {
            Fraction = ListFraction.GetHuman();
            HealsPoint = 200;
            ManaPool = 80;
            Damage = 50;
            Armor = 10;
        }
    }
    public class Archer : Unit
    {
        public Archer(string name_, double x_, double y_) : base(name_, x_, y_)
        {
            Fraction = ListFraction.GetHuman();
            HealsPoint = 100;
            ManaPool = 200;
            Damage = 80;
            Armor = 5;
        }
    }
    public class Warrior : Unit
    {
        public Warrior(string name_, double x_, double y_) : base(name_, x_, y_)
        {
            Fraction = ListFraction.GetOrc();
            HealsPoint = 300;
            ManaPool = 50;
            Damage = 50;
            Armor = 5;
        }
    }
    public class Berserker : Unit
    {
        public Berserker(string name_, double x_, double y_) : base(name_, x_, y_)
        {
            Fraction = ListFraction.GetOrc();
            HealsPoint = 450;
            ManaPool = 50;
            Damage = 60;
            Armor = 2;
        }
    }
}
