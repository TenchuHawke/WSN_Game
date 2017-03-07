using System;
using System.Threading;

namespace ConsoleApplication {
    public class Program {
        public static void Main (string[] args) {
            Human Bob = new Human ("Bob");
            Human Lenny = new Human ("Lenny", 120, 4, 2, 1);
            Bob.attack (Lenny);
            string table = "";
            Bob.attack (table);
            Wizard Gandalf = new Wizard ("Gandalf");
            Ninja Shinobi = new Ninja ("Shinobi");
            Samurai Ashitaka = new Samurai ("Ashitaka");
            Gandalf.fireball (Shinobi);
            Gandalf.fireball (table);
            Shinobi.Steal (Ashitaka);
            Ashitaka.Meditate ();
            Shinobi.Get_Away ();
            Gandalf.fireball (Shinobi);
            Ashitaka.Death_Blow (Shinobi);
            Ashitaka.attack (Gandalf);
            Gandalf.heal ();
            Samurai Aoi = new Samurai("Aoi");
           System.Console.WriteLine("There are " + Aoi.How_Many() + " Samurai.");
        }
    }
    public class Wizard : Human {

        public Wizard (string name): base (name) {
            Name = name;
            Intelligence = 25;
            Health = 50;
        }
        public void heal () {
            this.Health += (10 * this.Intelligence);
            System.Console.WriteLine(this.Name + " heals "+this.Intelligence*10);
        }
        public void fireball (object target) {
            Random rand = new Random ();
            if (target is Human) {
                int damage = rand.Next (20, 50);
                Human Target = target as Human;
                Target.Health -= damage;
                System.Console.WriteLine ("Your attack does " + damage + " damage to " + Target.Name);
            } else {
                System.Console.WriteLine ("Your Attack is ineffective on that target!");
            }
        }
    }
    public class Ninja : Human {
        public Ninja (string name): base (name) {
            Name = name;
            Dexterity = 175;
        }
        public void Steal (object target) {
            if (target is Human) {
                int damage = 10;
                Human Target = target as Human;
                Target.Health -= damage;
                this.Health += damage;
                System.Console.WriteLine ("You steal " + damage + " health from " + Target.Name);
            } else {
                System.Console.WriteLine ("Your Attack is ineffective on that target!");
            }
        }
        public void Get_Away () {
            this.Health -= 15;
            if (this.Health < 1) {
                System.Console.WriteLine ("You died trying to escape...");
            } else {
                System.Console.WriteLine ("You successfully escaped!");
            }
        }
    }
    public class Samurai : Human {
        static int count = 0;

        public Samurai (string name): base (name) {
            count++;
            Health = 200;
            Name = name;
        }
        public int How_Many () {
            return count;
        }
        public void Meditate () {
            this.Health = 200;
            System.Console.WriteLine (this.Name + " meditates back to full health!");
        }
        public void Death_Blow (object target) {
            if (target is Human) {
                Human Target = target as Human;
                if (Target.Health < 51) {
                    int damage = Target.Health;
                    Target.Health = 0;
                    System.Console.WriteLine ("Your death blow does " + damage + " damage to " + Target.Name + ", Killing them instantly!");
                } else {
                    System.Console.WriteLine ("The target still has too much health to use Death Blow, your attack fails!");
                }
            } else {
                System.Console.WriteLine ("Your Attack is ineffective on that target!");
            }
        }
    }
    public class Human {
        public int Health;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        public string Name;

        public Human (string name) {
            Name = name;
            Health = 100;
            Dexterity = 3;
            Intelligence = 3;
            Strength = 3;
        }
        public Human (string name, int health, int strength, int dexterity, int intelligence) {
            Name = name;
            Health = health;
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }
        public void attack (object target) {
            if (target is Human) {
                Human Target = target as Human;
                Target.Health -= (this.Strength * 5);
                System.Console.WriteLine ("Your attack does " + (this.Strength * 5) + " damage to " + Target.Name);
            } else {
                System.Console.WriteLine ("Your Attack is ineffective on that target!");
            }
        }
    }
}