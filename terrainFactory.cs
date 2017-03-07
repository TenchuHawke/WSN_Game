using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApplication {
    public class Terrain {
        public string Type { get; set; }
        public List<Human> Heroes { get; set; }
        public List<Human> Villians { get; set; }
        public int HeroCount { get; set; }
        public int VillianCount { get; set; }
        public List<Human> Combatants { get; set; }
        public Terrain (List<Human> heroes, List<Human> villians) {
            Random rand = new Random ();
            int choice = rand.Next (1, 5);
            switch (choice) {
                case 1:
                    Type = "Desert";
                    break;
                case 2:
                    Type = "Arctic";
                    break;
                case 3:
                    Type = "Forest";
                    break;
                case 4:
                    Type = "Cliffside";
                    break;
                default:
                    Type = "Urban";
                    break;
            }
            Heroes = heroes;
            Villians = villians;
            HeroCount = heroes.Count;
            VillianCount = villians.Count;
            List<Human> combatants = new List<Human> ();
            foreach (Human person in Heroes) {
                combatants.Add (person);
            }
            foreach (Human person in Villians) {
                combatants.Add (person);
            }
            Combatants = combatants;
        }
        public Terrain (string type, List<Human> heroes, List<Human> villians) {
            Type = type;
            Heroes = heroes;
            Villians = villians;
            HeroCount = heroes.Count;
            VillianCount = villians.Count;
            List<Human> combatants = new List<Human> ();
            foreach (Human person in Heroes) {
                combatants.Add (person);
            }
            foreach (Human person in Villians) {
                combatants.Add (person);
            }
            Combatants = combatants;
        }
        public void Calculate () {
            int Count = 0;
            foreach (Human person in Heroes) {
                if (!person.IsDead ()) {
                    Count++;
                }
            }
            HeroCount = Count;
            Count = 0;
            foreach (Human person in Villians) {
                if (!person.IsDead ()) {
                    Count++;
                }
            }
            VillianCount = Count;
        }
        public string Show () {
            string Output = "";
            switch (Type) {
                case "Desert":
                    Output += "Looking across the sandy desert landscape you see: \n";
                    break;
                case "Arctic":
                    Output += "The chill wind blows across the frozen battlefiled as you see: \n";
                    break;
                case "Forest":
                    Output += "Darting in and out of the trees are several creatures: \n";
                    break;
                case "Urban":
                    Output += "Between the buildings and in the alleys the combatants are: \n";
                    break;
                case "Cliffside":
                    Output += "The following combatants are precariously fighting on the cliffside: \n";
                    break;
                default:
                    Output += "The combatants are there, looking across the " + Type + ": \n";
                    break;
            }
            foreach (Human person in Heroes) {
                Output += "     * " + person.Name + " the " + person.ClassDesc;
                if (person.IsDead ()) {
                    Output += "(dead).\n";
                } else {
                    Output += ".\n";
                };
            }
            foreach (Monster creature in Villians) {
                Output += "     * " + creature.Name + " the " + creature.ClassDesc;
                if (creature.IsDead ()) {
                    Output += "(dead).\n";
                } else {
                    Output += ".\n";
                };
            }
            return Output;
        }
    }
}