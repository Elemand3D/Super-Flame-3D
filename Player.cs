using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorWinForm
{
    class Player
    {
        //1. Поля

        // Параметры игрока.
        public bool life = true;
        public bool onJob = false;

        public int hp = 100;
        public int maxHp = 100;

        public double food;
        public int maxFood = 100;

        public double water = 100D;
        public int maxWater = 100;


        public double energy = 100D;
        public int maxEnergy = 100;

        public double intoxication = 0D;
        public int maxIntoxication = 100;

        public double money = 0D;
        public double debt = 0D;

        // Скиллы игрока.
        public int iq = 80;
        public int power = 1;
        public int driving = 1;
        public int speech = 1;
        public int virus = 1;
        public int ukraine = 1;


        // Прокачка игрока.
        public double exp = 0D;
        public int level = 0;
        public int point = 12;

        // Одежда игрока.
        public int hat = 0;
        public int suit = 0;
        public int boots = 0;
        public int glasses = 0;
        public int mask = 0;
        public int accessory = 0;

        //2. Конструтор
        public Player()
        {
            life = true;
            onJob = false;

            hp = 100;
            maxHp = 100;

            food = 100D;
            maxFood = 100;

            water = 100D;
            maxWater = 100;


            energy = 100D;
            maxEnergy = 100;

            intoxication = 0D;
            maxIntoxication = 100;

            money = 0D;
            debt = 0D;

        // Скиллы игрока.
            iq = 80;
            power = 1;
            driving = 1;
            speech = 1;
            virus = 1;
            ukraine = 1;


        // Прокачка игрока.
            exp = 0D;
            level = 0;
            point = 12;

        // Одежда игрока.
            hat = 0;
            suit = 0;
            boots = 0;
            glasses = 0;
            mask = 0;
            accessory = 0;
    
        }
        //3. Метод
        public void ParametersLogic(Double milSec)
        {
            if (milSec > 60)
            {

                food -= 0.1;
                water -= 0.2;
                intoxication -= 0.4;
                if (onJob)
                {
                    energy -= 0.3;
                }
                else
                {
                    energy += 0.3;
                }

            }
            if (hp > maxHp)         // hp
            {
                hp = maxHp;
            }
            if (hp < 0)
            {
                hp = 0;
            }

            if (food > maxFood)     // food
            {
                food = maxFood;
            }
            if (food < 0)
            {
                food = 0;
            }

            if (water > maxWater)   // water
            {
                water = maxWater;
            }
            if (water < 0)
            {
                water = 0;
            }

            if (energy > maxEnergy) // energy
            {
                energy = maxEnergy;
            }
            if (energy < 0)
            {
                energy = 0;
            }

            if (intoxication > maxIntoxication) //intoxication
            {
                intoxication = maxIntoxication;
            }
            if (intoxication < 0)
            {
                intoxication = 0;
            }
            /*
            if (!life)
            {
                labelDeath.Visible = true;
                labelDeath.Text = ($"{labelNick}, ты умер!");
                tabControl1.Enabled = false;

            }
            */
        }
    }
}
