using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace SimulatorWinForm
{
    
    public partial class Form1 : Form
    {
        // Время.
        int day = 1;       // Номер дня.
        int houre = 6;     // Номер часа (0-23).
        int tenMinute = 0; // Номер десятиминуток (0-5).
        int oneMinute = 0; // Номер нормальных минут (0-9).
        double milSec = 49D;// Номер секунд 00.00-60.00

       





        // Параметры игрока.
        bool life = true;
        bool onJob = false;

        int hp = 100;
        int maxHp = 100;

        double food = 100D;
        int maxFood = 100;

        double water = 100D;
        int maxWater = 100;

        
        double energy = 100D;
        int maxEnergy = 100;

        double intoxication = 0D;
        int maxIntoxication = 100;

        double money = 0D;
        double debt = 0D;

        // Скиллы игрока.
        int iq = 80;
        int power = 1;
        int driving = 1;
        int speech = 1;
        int virus = 1;
        int ukraine = 1;


        // Прокачка игрока.
        double exp = 0D;
        int level = 0;
        int point = 12;

        // Одежда игрока.
        int hat = 0;
        int suit = 0;
        int boots = 0;
        int glasses = 0;
        int mask = 0;
        int accessory = 0;

        // Состояние машины.
        double wheels = 60D;
        double suspension = 60D;
        double engine = 60D;
        double carBody = 60D;
        double dirt = 60D;
        double gas = 60D;


        WindowsMediaPlayer player = new WindowsMediaPlayer();
        
       



        public Form1()
        {
            InitializeComponent();
            // player.URL = "Ninurta.mp3";
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // player.controls.play();
            
        }

        public void ListBoxAdd()
        {
            if (food <= 0 || water <= 0 || energy <= 0)
            {
                listBox1.Items.Insert(0, "Здоровью нанесён урон!");
            }
            if (exp > 9999)
            {
                listBox1.Items.Insert(0, "Уровень повышен! Добавлено очко!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)       // Таймер 10 мс.
        {
            TimeLogic();
            ParametersLogic();
            LabelUpdate();
            LabeColorUpdate();


            // Настройка прокачки.
            if (exp > 9999)
            {
                exp -= 10000;
                level++;
                point++;
            }
            progressBar1.Value = (int)exp;
            


        }

        public void TimeLogic()
        {
            // Настройка времени.
            if (houre > 23)     // Если час больше чем 23, то +день и -24 часа.
            {
                houre -= 24;
                day++;
            }

            if (tenMinute > 5)  // Если десятиминутка больше чем 5 часа, то +час и -6 десятиминуток.
            {
                tenMinute -= 6;
                houre++;
            }

            if (oneMinute > 9)  // Если минута больше чем 9, то +десятиминутка и -10 минут.
            {
                oneMinute -= 10;
                tenMinute++;
            }

            if (milSec > 60)    // Если секунд больше чем 60, то +минута и -60 секунд.
            {
                milSec -= 60;
                oneMinute++;
                
            }

            Double m = Math.Round(milSec, 2);                           // Округлять милисекуды.
            if (m < 10)
            {                                                               // Обновлять лейбл времени.
                labelTime.Text = ($"{houre}:{tenMinute}{oneMinute}:0{m}");  // Корректное отображение секунд.
            }
            else
            {
                labelTime.Text = ($"{houre}:{tenMinute}{oneMinute}:{m}");
            }


            labelDay.Text = ($"{day}");                                 // Обновлять лейбл дня.
            milSec += 0.01d;                                            // Добавить 0.01 секунды.

        }
        
        private void ParametersLogic()
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

            if (intoxication > maxIntoxication) // intoxication
            {
                intoxication = maxIntoxication;
            }
            if (intoxication < 0)
            {
                intoxication = 0;
            }
            if (!life)
            {
                labelDeath.Visible = true;
                labelDeath.Text = ($"{labelNick}, ты умер!");
                tabControl1.Enabled = false;

            }
        }
        public void LabelUpdate()
        {
            // Обновление параметров игрока.
            labelHp.Text = ($"hp:{hp}%");
            labelMaxHp.Text = ($"Max Hp: {maxHp}%");

            Double f = Math.Round(food, 1);
            labelFood.Text = ($"Еда:{f}%");
            labelMaxFood.Text = ($"Макс. Еды: {maxFood}%");

            Double w = Math.Round(water, 1);
            labelWater.Text = ($"Вода:{w}%");
            labelMaxWater.Text = ($"Макс. Воды: {maxWater}%");

            Double e = Math.Round(energy, 1);
            labelEnergy.Text = ($"Энергия:{e}%");
            labelMaxEnergy.Text = ($"Макс. Энергии: {maxEnergy}%");

            Double i = Math.Round(intoxication, 1);
            labelIntoxication.Text = ($"Интоксикация:{i}%");
            labelMaxIntoxication.Text = ($"Макс. Интоксикации: {maxIntoxication}%");

            Double mo = Math.Round(money, 1);
            labelMoney.Text = ($"Деньги:{mo} руб.");
            Double de = Math.Round(debt, 1);
            linkDebt.Text = ($"Долг: {de} руб.");

            // Обновление скиллов игрока.
            labelIQ.Text = ($"IQ:{iq}");
            labelPower.Text = ($"Сила:{power}");
            labelDriving.Text = ($"Вождение:{driving}");
            labelSpeech.Text = ($"Харизма:{speech}");
            labelVirus.Text = ($"коронавирусу:{virus}");
            labelUkraine.Text = ($"Украины:{ukraine}");

            // Обновление прокачки игрока.
            labelLevel.Text = ($"Уровень: {level}");
            Double ex = Math.Round(exp, 0);
            labelExp.Text = ($"exp: {ex}/10000");
            labelPoint.Text = ($"Нераспределённых очков:{point}");

            // Обновление состояния машины.
            Double wh = Math.Round(wheels, 1);
            labelWheels.Text = ($"Колёса: {wh}%");
            Double su = Math.Round(suspension, 1);
            labelSuspension.Text = ($"Подвеска: {su}%");
            Double en = Math.Round(engine, 1);
            labelEngine.Text = ($"Двигатель: {en}%");
            Double cb = Math.Round(carBody, 1);
            labelCarBody.Text = ($"Кузов: {cb}%");
            Double di = Math.Round(dirt, 1);
            labelDirt.Text = ($"Грязь: {di}%");
            Double ga = Math.Round(gas, 1);
            labelGas.Text = ($"Бензин: {ga}%");
        }

        private void LabeColorUpdate()
        {
            if (milSec > 59.8)
            {
                labelFood.ForeColor = System.Drawing.Color.Red;
                labelWater.ForeColor = System.Drawing.Color.Red;
                labelIntoxication.ForeColor = System.Drawing.Color.Red;
            }

            if (milSec < 59.8)
            {

                labelFood.ForeColor = System.Drawing.Color.Black;
                labelWater.ForeColor = System.Drawing.Color.Black;
                labelIntoxication.ForeColor = System.Drawing.Color.Black;
            }

            if (onJob)
            {
                if (milSec > 59.8)
                {
                    labelEnergy.ForeColor = System.Drawing.Color.Red;
                }
                if (milSec < 59.8)
                {
                    labelEnergy.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                if (milSec > 59.8)
                {
                    labelEnergy.ForeColor = System.Drawing.Color.Green;
                }
                if (milSec < 59.8)
                {
                    labelEnergy.ForeColor = System.Drawing.Color.Black;
                }
            }
            if (food <= 0 || water <= 0 || energy <= 0)             //Логическое ИЛИ
            {
                if (milSec > 59.8)
                {
                    labelHp.ForeColor = System.Drawing.Color.Red;
                }

                if (milSec < 59.8)
                {

                    labelHp.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        // Работа в такси

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            groupBox4.Enabled = false;
            onJob = true;
            button5.Enabled = false;
            button7.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
            groupBox4.Enabled = true;
            onJob = false;
            button5.Enabled = true;
            button7.Enabled = false;
        }
        //Клиенты такси))
        //Тест репозиториев
        TaxiCustomers[] customers = new TaxiCustomers[32];
        public string GetRaceName(int race)
        {
            switch (race)
            {
                case 0: return "Украина";
                case 1: return "Россия";
                case 2: return "США";
                case 3: return "Япония";
            }
            return "Неизвестно";
        }
        public string GetGenderName(int gender)
        {
            switch (gender)
            {
                case 0: return "Мужик";
                case 1: return "Девушка";
                case 2: return "Трап";
            }
            return "Неизвестно";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            int r = RandomCustomers();
            customers[0] = new TaxiCustomers("Гордон Фримен", 0, 2);
            customers[1] = new TaxiCustomers("Лысый Из Лоста", 0, 2);
            customers[2] = new TaxiCustomers("Китаец Из Лоста", 0, 3);
            customers[3] = new TaxiCustomers("G-MAN", 0, 999);
            customers[4] = new TaxiCustomers("Ozon671Games3", 0, 1);
            customers[5] = new TaxiCustomers("Абдуль", 0, 1);
            customers[6] = new TaxiCustomers("Навальный", 0, 0);
            customers[7] = new TaxiCustomers("Moby (яйценюх)", 0, 0);
            customers[8] = new TaxiCustomers("Кличко", 0, 0);
            RandomCustomers();

            DialogResult dialogResult = MessageBox.Show("Имя: " + customers[r].name + Environment.NewLine
            + "Гражданство: " + GetRaceName(customers[r].race) + Environment.NewLine
            + "Пол: " + GetGenderName(customers[r].gender) + Environment.NewLine
            + "Расстояние: " + customers[r].distance + " метров" + Environment.NewLine
            + "Деньги за поездку: " + customers[r].fare + " руб.", "Упс", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {


                milSec += customers[r].distance / 4;
                exp += customers[r].distance / 7;
                CarDamage();
                ListBoxAdd();
                MoneyManagement();
                

            }

        }
        public void CarDamage()
        {
            int r = RandomCustomers();
            wheels -= customers[r].distance / 4000;
            suspension -= customers[r].distance / 3200;
            engine -= customers[r].distance / 4800;
            carBody -= customers[r].distance / 3800;
            gas -= customers[r].distance / 1600;
            dirt += customers[r].distance / 4000;


        }

        public int RandomCustomers()
        {
            Random rand = new Random();
            int r = rand.Next(0, 9);
            return r;
        }

        public void MoneyManagement()
        {
            int r = RandomCustomers();
            money += customers[r].fare;
        }
        
        // кнопочки
        private void button1_Click(object sender, EventArgs e)
        {
            day++;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            milSec += 600;
            
        }
        

        private void button3_Click_1(object sender, EventArgs e)
        {
            life = false;
            

        }

        // Рандомные ники
        private void button4_Click(object sender, EventArgs e)
        {
           labelNick.Text = NickGetter.GetNick();
        }


        // Кнопки прокачки (SkillUp.cs)
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp();
            skillUp.ace = point;
            skillUp.skill = iq;
            skillUp.SkillManipulated();
            point = skillUp.ace;
            iq = skillUp.skill;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp();
            skillUp.ace = point;
            skillUp.skill = power;
            skillUp.SkillManipulated();
            point = skillUp.ace;
            power = skillUp.skill;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp();
            skillUp.ace = point;
            skillUp.skill = driving;
            skillUp.SkillManipulated();
            point = skillUp.ace;
            driving = skillUp.skill;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp();
            skillUp.ace = point;
            skillUp.skill = speech;
            skillUp.SkillManipulated();
            point = skillUp.ace;
            speech = skillUp.skill;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp();
            skillUp.ace = point;
            skillUp.skill = virus;
            skillUp.SkillManipulated();
            point = skillUp.ace;
            virus = skillUp.skill;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp();
            skillUp.ace = point;
            skillUp.skill = ukraine;
            skillUp.SkillManipulated();
            point = skillUp.ace;
            ukraine = skillUp.skill;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp();
            skillUp.ace = point;
            skillUp.skill = maxHp;
            skillUp.multiplierSkill = 10;
            skillUp.SkillManipulated();
            point = skillUp.ace;
            maxHp = skillUp.skill;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp();
            skillUp.ace = point;
            skillUp.skill = maxFood;
            skillUp.multiplierSkill = 10;
            skillUp.SkillManipulated();
            point = skillUp.ace;
            maxFood = skillUp.skill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp();
            skillUp.ace = point;
            skillUp.skill = maxWater;
            skillUp.multiplierSkill = 10;
            skillUp.SkillManipulated();
            point = skillUp.ace;
            maxWater = skillUp.skill;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp();
            skillUp.ace = point;
            skillUp.skill = maxEnergy;
            skillUp.multiplierSkill = 10;
            skillUp.SkillManipulated();
            point = skillUp.ace;
            maxEnergy = skillUp.skill;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp();
            skillUp.ace = point;
            skillUp.skill = maxIntoxication;
            skillUp.multiplierSkill = 10;
            skillUp.SkillManipulated();
            point = skillUp.ace;
            maxIntoxication = skillUp.skill;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nickSelected = comboBox1.SelectedItem.ToString();
            labelNick.Text = nickSelected;
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            string nickName = NickGetter.GetNick();

            string name = NickGetter.GetName();

            

            string[] rumor1 =
            {
                $"Здарова, {labelNick.Text.ToString()}. ", $"О! Смотрите! {labelNick.Text.ToString()} припёрся. ",
                $"Слыш, {labelNick.Text.ToString()} ну ка подь сюды. ", $"Ну здравствуй уважаемый {labelNick.Text.ToString()} чё надо? ",
                $"Здравствуй {labelNick.Text.ToString()}. Если тебе нужно дать в долг, могу сразу сказать, денег у меня нет. Но зато у меня есть" +
                $" значительный набор умений. Умений, которые я приобрел за свою долгую карьеру. Если ты сейчас забудешь то что я тебе скажу, на этом все" +
                $" закончится. Я не стану тебя искать. И не буду тебя преследовать. Но если нет, я буду тебя искать. Я найду тебя. И я тебя убью. "


            };
            int rum1 = rnd.Next(rumor1.Length);

            string[] rumor2 =
            {
                $"Тут ходят слухи что ", $"Кстати мне вчера {nickName} рассказал что ", $"Я тебе по секрету скажу кое что ", "Слышал чё вчера было тут? Пиздец кароче ",
                $"Охуеть да у тебя на руках целых {money} рублей)) ебать ты лох)) но щас не об этом. "
            };
            int rum2 = rnd.Next(rumor2.Length);

            string[] rumor3 =
            {
                $"{name} оказывается то... это самое... ", $"этот как его блять... А! {name} кароче. ", $"Слышал об {name}? ",
                $"Когда я учился в школе, был у меня один друг по имени {name}. Правда сам он называл себя {nickName} (но все звали его просто дибил). "
            };
            int rum3 = rnd.Next(rumor3.Length);

            string[] rumor4 =
            {
                $"Пидор он вообщем))", $"Он провёз тридцать кило героина в такси! У себя в жопе!", $"А ладно забудь... Иди на хуй кароче)))",
                "Да блять он блять обосрал блять он перданул блять он обосрал свои эти шорты нахуй и пришлось ему от говна их немножко оттереть блять" +
                " и бросить в стирку нахуй и потом жопу ещё поддмыть блять и всё это заняло время бля вооот сейчас надо пойти что-то другое одеть блять" +
                " такая вот хуйня это всё из-за бухла блять бухло слабит типа расслабляет во всех смыслах этого слова ебать",
                "Вчера отцу признался что он гей. Отец выглядел покинутым и лишь спросил: - У тебя парень есть? - Он грустно ответил что есть. Отец спросил еще " +
                "И ты его прямо в пердачелло?. Он кивнул. - Долбишься в сракотан? Опять он грустно кивнул. Теребишь его в попчанский? Ебошишь его в шоколадницу?" +
                "Месишь черное тесто с перцем? Заезжаешь на ночь в Попенгаген? Смотрел фильм Чарли и шоколадная фабрика? Он послал нахуй отца и ушел."
                

            };
            int rum4 = rnd.Next(rumor4.Length);

            DialogResult dialogResult = MessageBox.Show((rumor1[rum1]) + (rumor2[rum2]) + (rumor3[rum3]) + (rumor4[rum4]), "Вы узнаёте хуйню", MessageBoxButtons.OK);
            
        }

        
    }
}
