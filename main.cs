using System;


namespace uwuu
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean vapmel = false; ///vap mit hydro getriggert, melt mit pyro --> 2x dmg
            Boolean vapmel2 = false; /// vap mit pyro getriggert, melt mit cryo --> 1,5x dmg

            void testo()
            {
                Console.WriteLine("triggers Melt with Pyro or Vaporize with Hydro? y/n");
                string elre2xs = Console.ReadLine();
                Boolean elre2;


                if (elre2xs == "y" || elre2xs == "n")
                {
                    if (elre2xs == "y")
                    { elre2 = true; }
                    else
                    { elre2 = false; }
                    vapmel = elre2;

                }
                else testo();
            }
            void testo2()
            {
                Console.WriteLine("triggers Melt with Pyro or Vaporize with Hydro? y/n");
                string elre2xs = Console.ReadLine();
                Boolean elre2;


                if (elre2xs == "y" || elre2xs == "n")
                {
                    if (elre2xs == "y")
                    { elre2 = true; }
                    else
                    { elre2 = false; }
                    vapmel2 = elre2;

                }
                else testo2();
            }
            String ElmeRea = " ";
            void testo3()
            {
                String ElementalRe = Console.ReadLine();
                if (ElementalRe!= "Swirl"&& ElementalRe != "Superconduct" && ElementalRe != "Shattered" && ElementalRe != "Overload" && ElementalRe != "none" && ElementalRe != "None" && ElementalRe != "NONE")
                {
                    Console.WriteLine("Please enter a valid Elemental reaction or type NONE to leave");
                    testo3();
                }
                else if (ElementalRe == "None" | ElementalRe == "none" | ElementalRe == "NONE")
                {
                    
                }
                else
                {
                    ElmeRea = ElementalRe;
                }
            }
            while(true)
            { 
            Console.WriteLine("char lvl?");
            int clvl = Convert.ToInt32(Console.ReadLine()); ///character lvl
            Console.WriteLine("input character atk");
            int atk = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input character EM");
            int EM = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("CritRate?");
            int CritR = Convert.ToInt32(Console.ReadLine());
            Console.Write("Critdmg?");
            int critdmg = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("elemental or physical damage bonus? -whole number-");
            int dmgbonus = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("dmg perc of ability? pls use a whole number");
            int abdmg = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Is there an elemental Reaction? y/n");
                String uwu = Console.ReadLine();
                void bruh()
                {
                    if (uwu == "y")
                    {
                        testo();
                        if (vapmel != true)
                        {
                            testo2();
                        }
                        if (vapmel != true && vapmel2 != true)
                        {
                            Console.WriteLine("enter different elemental reaction (Im too lazy to just include everything in one) (Overload/Shattered/Superconduct/Swirl - Charged comming soon");
                            testo3();
                        }
                    }
                    else if (uwu != "y" || uwu != "n")
                    {
                        bruh();
                    }
                }
                bruh();
            Console.WriteLine("enemy/target lvl?");
            int tlvl = Convert.ToInt32(Console.ReadLine()); ///enemy lvl
            Console.WriteLine("enemy resistence to damaging element? (if u dont know look up on genshinwiki -- please use a whole number");
            int enemyresistence = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("defense reduction:");
            int defred = Convert.ToInt32(Console.ReadLine());
            double e = 2.71828182846;
            double elementalresistence(int enemy_resistance)
            {
                double enemy_resistance_out;
                if (enemy_resistance < 0)
                {
                    enemy_resistance_out = 1 - enemy_resistance / 100 / 2.0;
                }
                else if (enemy_resistance >= 0 && enemy_resistance < 75)
                {
                    enemy_resistance_out = 1 - enemy_resistance / 100;
                }
                else
                {
                    enemy_resistance_out = 1 - (4 * (enemy_resistance / 100) + 1);
                }
                return (enemy_resistance_out);
            }

            double damageoutput = 1;
                double damage_out_noc = 1;
                if (vapmel == true)
                {
                    damageoutput = (abdmg / 100.0) * (atk * (1 + critdmg / 100.0) * (1 + (dmgbonus / 100.0)) * ((100 + clvl) / ((clvl + 100.0) + (tlvl + 100) * (1 - defred / 100.0))) * elementalresistence(enemyresistence) * (2 * (1 + 0.00189266831 * EM * Math.Pow(e, -0.000505 * EM))));
                    Console.WriteLine("ur dmg output with crit and melt with pyro/vaporize with hydro will be:" + damageoutput);
                    Console.WriteLine("without crit:" + (abdmg / 100.0) * (atk * (1) * (1 + (dmgbonus / 100.0)) * ((100 + clvl) / ((clvl + 100.0) + (tlvl + 100) * (1 - defred / 100.0))) * elementalresistence(enemyresistence) * (2 * (1 + 0.00189266831 * EM * Math.Pow(e, -0.000505 * EM)))));
                    Console.WriteLine("ur average damage will be:" + ((abdmg / 100.0) * (atk  * (1 + critdmg / 100.0) * (1 + (dmgbonus / 100.0)) * ((100 + clvl) / ((clvl + 100.0) + (tlvl + 100) * (1 - defred / 100.0))) * elementalresistence(enemyresistence) * (2 * (1 + 0.00189266831 * EM * Math.Pow(e, -0.000505 * EM))))* (CritR/100.0) * (1 - CritR/100.0) *(abdmg / 100.0) +  (atk * (1) * (1 + (dmgbonus / 100.0)) * ((100 + clvl) / ((clvl + 100.0) + (tlvl + 100) * (1 - defred / 100.0))) * elementalresistence(enemyresistence) * (2 * (1 + 0.00189266831 * EM * Math.Pow(e, -0.000505 * EM))))));
                }
                else if (vapmel2 == true)
                {
                    damageoutput = (abdmg / 100.0) * (atk * (1 + critdmg / 100.0) * (1 + (dmgbonus / 100.0)) * ((100 + clvl) / ((clvl + 100.0) + (tlvl + 100) * (1 - defred / 100.0))) * elementalresistence(enemyresistence) * (1.5 * (1 + 0.00189266831 * EM * Math.Pow(e, -0.000505 * EM))));
                    damage_out_noc = (abdmg / 100.0) * (atk * (1) * (1 + (dmgbonus / 100.0)) * ((100 + clvl) / ((clvl + 100.0) + (tlvl + 100) * (1 - defred / 100.0))) * elementalresistence(enemyresistence) * (1.5 * (1 + 0.00189266831 * EM * Math.Pow(e, -0.000505 * EM))));
                    Console.WriteLine("ur dmg output with crit and melt triggered with cryo/vaporize with pyro will be:" + damageoutput);
                    Console.WriteLine("without crit:" + damage_out_noc);
                    Console.WriteLine("ur average dmg will be:" + (damageoutput * (CritR / 100.0) + damage_out_noc * (1 - CritR / 100.0)));

                }
                else
                {
                    damageoutput = (abdmg / 100.0) * (atk * (1 + critdmg / 100.0) * (1 + (dmgbonus / 100.0)) * ((100 + clvl) / ((clvl + 100.0) + (tlvl + 100) * (1 - defred / 100.0))) * elementalresistence(enemyresistence));
                    damage_out_noc = (abdmg / 100.0) * (atk * (1) * (1 + (dmgbonus / 100.0)) * ((100 + clvl) / ((clvl + 100.0) + (tlvl + 100) * (1 - defred / 100.0))) * elementalresistence(enemyresistence));
                    Console.WriteLine("ur dmg output with crit and without any elemental reactions will be:" + damageoutput);
                    Console.WriteLine("without crit:" + damage_out_noc);
                    Console.WriteLine("Without crit:" + ((damageoutput * (CritR / 100.0) + damage_out_noc * (1 - CritR / 100.0))));
                    double weirdesEMZeug = (1 + (60 * EM) / (12609 + 9 * EM));
                    String uwuu = "Dein " + ElmeRea + "damage wird sein:";
                    String uwuuu = "dein Dmg mit " + ElmeRea + "wird ... sein:";
                    if (ElmeRea == "Swirl")
                    {
                        double Swirl = (-0.0000008854 * Math.Pow(clvl, 5) + 0.0001679502 * Math.Pow(clvl, 4) + 0.0103922088 * Math.Pow(clvl, 3) + 0.3097567417 * Math.Pow(clvl, 2) - 1.773381829 * clvl + 13.6167684329);
                        Console.WriteLine(uwuu + (weirdesEMZeug * Swirl ));
                        Console.WriteLine(uwuuu + (damageoutput + (weirdesEMZeug * Swirl)) + "mit crit," + (damage_out_noc + (weirdesEMZeug * Swirl)) + "ohne crit, " + (damageoutput * (CritR / 100.0) + damage_out_noc * (1 - CritR / 100.0) + (weirdesEMZeug * Swirl)) + "durchschnittlich");
                    }
                    if (ElmeRea == "Shattered")
                    {
                        double Shattered = (-0.0000020555 * Math.Pow(clvl, 5) + 0.0003895953 * Math.Pow(clvl, 4) + 0.0239673351 * Math.Pow(clvl, 3) + 0.7174530144 * Math.Pow(clvl, 2) - 3.7397755267 * clvl + 31.2160750111);
                        Console.WriteLine(uwuu + (weirdesEMZeug * Shattered ));
                        Console.WriteLine(uwuuu + (damageoutput + (weirdesEMZeug * Shattered)) + "mit crit," + (damage_out_noc + (weirdesEMZeug * Shattered)) + "ohne crit, " + (damageoutput * (CritR / 100.0) + damage_out_noc * (1 - CritR / 100.0) + (weirdesEMZeug * Shattered)) + "durchschnittlich");
                    }
                    if (ElmeRea == "Superconduct")
                    {
                        double Superconduct = (-0.0000001110078 * Math.Pow(clvl, 5) + 0.0001110078 * Math.Pow(clvl, 4) + 0.0064237710 * Math.Pow(clvl, 3) + 0.1836799174 * Math.Pow(clvl, 2) - 0.45509512 * clvl + 7.4972486411);
                        Console.WriteLine(uwuu + (weirdesEMZeug * Superconduct));
                        Console.WriteLine(uwuuu + (damageoutput + (weirdesEMZeug * Superconduct)) + "mit crit," + (damage_out_noc + (weirdesEMZeug * Superconduct)) + "ohne crit, " + (damageoutput * (CritR / 100.0) + damage_out_noc * (1 - CritR / 100.0) + (weirdesEMZeug * Superconduct)) + "durchschnittlich");
                    }
                    if (ElmeRea == "Overload")
                    {
                        double Overload = (-0.00000027646 * Math.Pow(clvl, 5) * 0.00051894401 * Math.Pow(clvl, 4) + 0.0314790536 * Math.Pow(clvl, 3) + 0.9268181504 * Math.Pow(clvl, 2) - 4.3991155718 * clvl + 37.2160750111);
                        Console.WriteLine(uwuu + (weirdesEMZeug * Overload));
                        Console.WriteLine(uwuuu + (damageoutput + (weirdesEMZeug * Overload)) + "mit crit," + (damage_out_noc + (weirdesEMZeug * Overload)) + "ohne crit, " + (damageoutput * (CritR / 100.0) + damage_out_noc * (1 - CritR / 100.0) + (weirdesEMZeug * Overload)) + "durchschnittlich");
                    }
                }
            }
        }
    }
}

