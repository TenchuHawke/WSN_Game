using System;
using System.Collections.Generic;
namespace ConsoleApplication {
    public class Monster : Human {
        public int Number_of_legs = 2;
        public Monster (string name): base (name) {
            Name = name;
            Health = 50;
            Strength = 5;
            Dexterity = 10;
            Intelligence = 1;
            HumanClass = "Monster";
            ClassDesc = "Ferocious Monster";
        }
        public void Attack (Human target) {
            if (target.Immune) {
                System.Console.WriteLine (target.Name + " is immune to " + Name + "'s attack!");
            } else if (this.IsWeak ()) {
                target.Health -= 2 * this.Strength;
                System.Console.WriteLine ("A weakened " + this.Name + " hits " + target.Name + " for " + this.Strength * 2 + " points of damage!");
            } else {
                target.Health -= 5 * this.Strength;
                System.Console.WriteLine (this.Name + " hits " + target.Name + " for " + this.Strength * 5 + " points of damage!");
            }
        }
        public void Choose (List<Human> targets) {
            Random rand = new Random ();
            int choice = rand.Next (0, targets.Count);
            do {
                choice = rand.Next (0, targets.Count);
            }
            while (targets[choice].IsDead ());
            this.Attack (targets[choice]);
            if (targets[choice].IsDead ()) {
                Console.Clear ();
                System.Console.WriteLine (targets[choice].Name + " has died...");
                System.Console.ReadLine ();
            }
        }
    }
    public class Spider : Monster {
        public Spider (string name): base (name) {
            Name = name;
            Number_of_legs = 8;
            Health = 90;
            Strength = 6;
            Dexterity = 120;
            HumanClass = "Spider";
            ClassDesc = "Giant Spider";
        }
    }
    public class Zombie : Monster {
        public Zombie (string name): base (name) {
            Name = name;
            Health = 75;
            Strength = 7;
            Dexterity = 5;
            HumanClass = "Zombie";
            ClassDesc = "Horrid Zombie";
        }
    }
}