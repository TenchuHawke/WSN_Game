using System;
using System.Collections.Generic;

namespace ConsoleApplication {
    public class Human {
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public string Name { get; set; }
        public bool Immune { get; set; }
        public string HumanClass { get; set; }
        public string ClassDesc { get; set; }

        public Human (string name) {
            Name = name;
            Health = 100;
            Dexterity = 3;
            Intelligence = 3;
            Strength = 3;
            Immune = false;
            HumanClass = "Peasant";
            ClassDesc = "Ordinary Peasant";
        }
        public Human (string name, int health, int strength, int dexterity, int intelligence) {
            Name = name;
            Health = health;
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Immune = false;
            HumanClass = "Peasant";
            ClassDesc = "Ordinary Peasant";
        }
        public void attack (object target) {
            if (target is Human) {
                Human Target = target as Human;
                if (!Target.Immune) {
                    Target.Health -= (this.Strength * 5);
                    System.Console.WriteLine ("Your attack does " + (this.Strength * 5) + " damage to " + Target.Name);
                } else {
                    System.Console.WriteLine (Target.Name + " is immune to " + Name + "'s attack!");
                }
            } else {
                System.Console.WriteLine ("Your Attack is ineffective on that target!");
            }
        }
        public bool IsDead () {
            return this.Health < 1;
        }
        public bool IsWeak () {
            return this.Health < 21;
        }
        public void Ask (List<Human> Enemies) {
            System.Console.WriteLine ("A normal human can't do anything.");
        }
    }
    public class Ninja : Human {
        public Ninja (string name): base (name) {
            Name = name;
            Dexterity = 175;
            HumanClass = "Ninja";
            ClassDesc = "Elusive Ninja";
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
                System.Console.WriteLine ("Dodging out of combat, you take 15 damage but you successfully escaped!");
                this.Immune = true;
            }
        }
        public new void Ask (List<Human> Enemies) {
            bool input = true;
            string fromPlayer = "";
            while (input) {
                System.Console.WriteLine (this.Name + ", What action would you like to take:");
                System.Console.WriteLine ("1)  Attack");
                System.Console.WriteLine ("2)  Steal Health");
                System.Console.WriteLine ("3)  Get Out of Combat");
                fromPlayer = System.Console.ReadLine ();
                if (fromPlayer == "3" || fromPlayer == "1" || fromPlayer == "2") {
                    input = false;
                }
            }
            input = true;
            string fromPlayer2 = "";
            int selection = 0;
            while (input) {
                if (fromPlayer == "3") {
                    break;
                }
                System.Console.WriteLine ("Who do you want to target");
                int count = 0;
                foreach (Monster monster in Enemies) {
                    count++;
                    if (monster.IsDead ()) {
                        continue;
                    }
                    if (monster.Immune) {
                        continue;
                    }
                    string output = "";
                    output = count + ") " + monster.Name + " " + monster.ClassDesc + ".";
                    System.Console.WriteLine (output);
                }
                fromPlayer2 = System.Console.ReadLine ();
                int.TryParse (fromPlayer2, out selection);
                if (!(selection<1 || selection> count)) {
                    if (Enemies[selection - 1].Immune) {
                        System.Console.WriteLine ("That creature is immune to your attack!");
                    } else if (!(Enemies[selection - 1].IsDead ())) {
                        input = false;
                    } else {
                        System.Console.WriteLine ("That creature is already Dead!");
                    }
                }
            }
            int target = (int) selection - 1;
            switch (fromPlayer) {
                case "1":
                    this.attack (Enemies[target]);
                    if (Enemies[target].IsDead ()) {
                        System.Console.WriteLine (Enemies[target].Name + " has died from the damage!");
                    }
                    break;
                case "2":
                    this.Steal (Enemies[target]);
                    if (Enemies[target].IsDead ()) {
                        System.Console.WriteLine (Enemies[target].Name + " has died from the damage!");
                    }
                    break;
                case "3":
                    this.Get_Away ();
                    break;
                default:
                    break;
            }

        }
    }

    public class Samurai : Human {
        static int count = 0;

        public Samurai (string name): base (name) {
            count++;
            Health = 200;
            Strength = 10;
            Name = name;
            HumanClass = "Samurai";
            ClassDesc = "Stalwart Samurai";
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
        public new void Ask (List<Human> Enemies) {
            bool input = true;
            string fromPlayer = "";
            while (input) {
                System.Console.WriteLine (this.Name + ", What action would you like to take:");
                System.Console.WriteLine ("1)  Attack");
                System.Console.WriteLine ("2)  Death Blow");
                System.Console.WriteLine ("3)  Meditate");
                fromPlayer = System.Console.ReadLine ();
                if (fromPlayer == "3" || fromPlayer == "1" || fromPlayer == "2") {
                    input = false;
                }
            }
            input = true;
            string fromPlayer2 = "";
            int selection = 0;
            while (input) {
                if (fromPlayer == "3") {
                    break;
                }
                System.Console.WriteLine ("Who do you want to target");
                int count = 0;
                foreach (Monster monster in Enemies) {
                    count++;
                    if (monster.IsDead ()) {
                        continue;
                    }
                    if (monster.Immune) {
                        continue;
                    }
                    string output = "";
                    output = count + ") " + monster.Name + " " + monster.ClassDesc + ".";
                    System.Console.WriteLine (output);
                }
                fromPlayer2 = System.Console.ReadLine ();
                int.TryParse (fromPlayer2, out selection);
                if (!(selection<1 || selection> count)) {
                    if (Enemies[selection - 1].Immune) {
                        System.Console.WriteLine ("That creature is immune to your attack!");
                    } else if (!(Enemies[selection - 1].IsDead ())) {
                        input = false;
                    } else {
                        System.Console.WriteLine ("That creature is already Dead!");
                    }
                }
            }
            int target = (int) selection - 1;
            switch (fromPlayer) {
                case "1":
                    this.attack (Enemies[target]);
                    if (Enemies[target].IsDead ()) {
                        System.Console.WriteLine (Enemies[target].Name + " has died from the damage!");
                    }
                    break;
                case "2":
                    this.Death_Blow (Enemies[target]);
                    if (Enemies[target].IsDead ()) {
                        System.Console.WriteLine (Enemies[target].Name + " has died from the damage!");
                    }
                    break;
                case "3":
                    this.Meditate ();
                    break;
                default:
                    break;
            }
        }
    }
    public class Wizard : Human {
        public Wizard (string name): base (name) {
            Name = name;
            Intelligence = 25;
            Health = 50;
            HumanClass = "Wizard";
            ClassDesc = "Powerful Wizard";
        }
        public void heal () {
            this.Health += (5 * this.Intelligence);
            System.Console.WriteLine (this.Name + " heals " + this.Intelligence * 5);
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
        public new void Ask (List<Human> Enemies) {
            bool input = true;
            string fromPlayer = "";
            while (input) {
                System.Console.WriteLine (this.Name + ", What action would you like to take:");
                System.Console.WriteLine ("1)  Attack");
                System.Console.WriteLine ("2)  Fireball");
                System.Console.WriteLine ("3)  Heal");
                fromPlayer = System.Console.ReadLine ();
                if (fromPlayer == "3" || fromPlayer == "1" || fromPlayer == "2") {
                    input = false;
                }
            }
            input = true;
            string fromPlayer2 = "";
            int selection = 0;
            while (input) {
                if (fromPlayer == "3") {
                    break;
                }
                System.Console.WriteLine ("Who do you want to target");
                int count = 0;
                foreach (Monster monster in Enemies) {
                    count++;
                    if (monster.IsDead ()) {
                        continue;
                    }
                    if (monster.Immune) {
                        continue;
                    }
                    string output = "";
                    output = count + ") " + monster.Name + " " + monster.ClassDesc + ".";
                    System.Console.WriteLine (output);
                }
                fromPlayer2 = System.Console.ReadLine ();
                int.TryParse (fromPlayer2, out selection);
                if (!(selection<1 || selection> count)) {
                    if (Enemies[selection - 1].Immune) {
                        System.Console.WriteLine ("That creature is immune to your attack!");
                    } else if (!(Enemies[selection - 1].IsDead ())) {
                        input = false;
                    } else {
                        System.Console.WriteLine ("That creature is already Dead!");
                    }
                }
            }
            int target = (int) selection - 1;
            switch (fromPlayer) {
                case "1":
                    this.attack (Enemies[target]);
                    if (Enemies[target].IsDead ()) {
                        System.Console.WriteLine (Enemies[target].Name + " has died from the damage!");
                    }
                    break;
                case "2":
                    this.fireball (Enemies[target]);
                    if (Enemies[target].IsDead ()) {
                        System.Console.WriteLine (Enemies[target].Name + " has died from the damage!");
                    }
                    break;
                case "3":
                    this.heal ();
                    break;
                default:
                    break;
            }
        }
    }
}