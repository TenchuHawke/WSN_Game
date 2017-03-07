using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace ConsoleApplication {
    public class Program {
        public static void Main (string[] args) {
            //build teams.
            List<Human> Allies = new List<Human> ();
            Wizard Gandalf = new Wizard ("Gandalf");
            Ninja Shinobi = new Ninja ("Shinobi");
            Samurai Ashitaka = new Samurai ("Ashitaka");
            Allies.Add (Gandalf);
            Allies.Add (Shinobi);
            Allies.Add (Ashitaka);
            List<Human> Enemies = new List<Human> ();
            Zombie Ogg = new Zombie ("Ogg");
            Zombie Grogg = new Zombie ("Grogg");
            Spider Shelob = new Spider ("Shelob");
            Enemies.Add (Ogg);
            Enemies.Add (Grogg);
            Enemies.Add (Shelob);
            Terrain battlefield = new Terrain (Allies, Enemies);
            //run game
            bool GameOn = true;
            while (GameOn) {
                int init = 4;
                while (battlefield.VillianCount > 0 && battlefield.HeroCount > 0) {
                    //main game loop
                    System.Console.Clear ();
                    System.Console.WriteLine (battlefield.Show ());
                    foreach (Human combatant in battlefield.Combatants) {
                        combatant.Immune = false;
                    }
                    foreach (Human hero in Allies) {
                        battlefield.Calculate ();
                        if (battlefield.VillianCount > 0) {
                            if (hero.IsDead ()) {
                                // Skip if dead
                            } else if (hero.Dexterity > init * 100) {
                                if (hero is Wizard) {
                                    Wizard Hero = hero as Wizard;
                                    Hero.Ask (battlefield.Villians);
                                } else if (hero is Ninja) {
                                    Ninja Hero = hero as Ninja;
                                    Hero.Ask (battlefield.Villians);
                                } else if (hero is Samurai) {
                                    Samurai Hero = hero as Samurai;
                                    Hero.Ask (battlefield.Villians);
                                } else {
                                    Human Hero = hero as Human;
                                    Hero.Ask (battlefield.Villians);
                                }
                                System.Console.WriteLine ("Press Enter to continue");
                                System.Console.ReadLine ();
                            }
                        }
                    }
                    battlefield.Calculate ();
                    if (battlefield.HeroCount > 0) {
                        foreach (Monster villian in Enemies) {
                            if (villian.IsDead ()) { } else if (villian.Dexterity > init * 100) {
                                villian.Choose (Allies);
                                System.Console.WriteLine ("Press Enter to continue");
                                System.Console.ReadLine ();
                            }
                        }
                    }
                    battlefield.Calculate ();
                    init--;
                    if (init == -1) {
                        init = 4;
                    }
                }
                if (battlefield.HeroCount > 0) {
                    System.Console.Clear ();
                    System.Console.WriteLine ("YOU WIN!!!");
                    System.Console.WriteLine ("Press Enter to continue");
                    System.Console.ReadLine ();
                    GameOn = false;
                } else {
                    System.Console.Clear ();
                    System.Console.WriteLine ("You LOSE!");
                    System.Console.WriteLine ("Press Enter to continue");
                    System.Console.ReadLine ();
                    GameOn = false;
                }
            }
        }
    }
}