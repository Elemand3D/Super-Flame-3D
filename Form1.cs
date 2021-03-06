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


        


        //WindowsMediaPlayer soundPlayer = new WindowsMediaPlayer();



        Player player1;

        public Form1()
        {
            InitializeComponent();
            player1 = new Player();
            // player.URL = "Ninurta.mp3";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // player.controls.play();
            
        }

        public void ListBoxAdd()
        {
            if (player1.food <= 0 || player1.water <= 0 || player1.energy <= 0)
            {
                listBox1.Items.Insert(0, "Здоровью нанесён урон!");
            }
            if (player1.exp > 9999)
            {
                listBox1.Items.Insert(0, "Уровень повышен! Добавлено очко!");
            }
            if (player1.wheels <= 0 )
            {
                listBox1.Items.Insert(0, "Не хватает колёс!");
            }
            if (player1.suspension <= 0)
            {
                listBox1.Items.Insert(0, "Подвеска слишком занижена! (Разъёбана)");
            }
            if (player1.engine <= 0 || player1.gas <= 0)
            {
                listBox1.Items.Insert(0, "Машина не заводится!");
            }
            if (player1.carBody <= 0)
            {
                listBox1.Items.Insert(0, "В тачке дырки размером с пассажира!");
            }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)       // Таймер 10 мс.
        {
            TimeLogic();
            player1.ParametersLogic(milSec);
            LabelUpdate();
            LabeColorUpdate();


            
            progressBar1.Value = (int)player1.exp;
            


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


            labelDay.Text = ($"День: {day}");                                 // Обновлять лейбл дня.
            milSec += 0.01d;                                            // Добавить 0.01 секунды.

        }
        
       
        public void LabelUpdate()
        {
            // Обновление параметров игрока.
            labelHp.Text = ($"hp:{player1.hp}%");
            labelMaxHp.Text = ($"Max Hp: {player1.maxHp}%");

            Double f = Math.Round(player1.food , 1);
            labelFood.Text = ($"Еда:{f}%");
            labelMaxFood.Text = ($"Макс. Еды: {player1.maxFood}%");

            Double w = Math.Round(player1.water, 1);
            labelWater.Text = ($"Вода:{w}%");
            labelMaxWater.Text = ($"Макс. Воды: {player1.maxWater}%");

            Double e = Math.Round(player1.energy, 1);
            labelEnergy.Text = ($"Энергия:{e}%");
            labelMaxEnergy.Text = ($"Макс. Энергии: {player1.maxEnergy}%");

            Double i = Math.Round(player1.intoxication, 1);
            labelIntoxication.Text = ($"Интоксикация:{i}%");
            labelMaxIntoxication.Text = ($"Макс. Интоксикации: {player1.maxIntoxication}%");

            Double mo = Math.Round(player1.money, 1);
            labelMoney.Text = ($"Деньги:{mo} руб.");
            Double de = Math.Round(player1.debt, 1);
            linkDebt.Text = ($"Долг: {de} руб.");

            // Обновление скиллов игрока.
            labelIQ.Text = ($"IQ:{player1.iq}");
            labelPower.Text = ($"Сила:{player1.power}");
            labelDriving.Text = ($"Вождение:{player1.driving}");
            labelSpeech.Text = ($"Харизма:{player1.speech}");
            labelVirus.Text = ($"коронавирусу:{player1.virus}");
            labelUkraine.Text = ($"Украины:{player1.ukraine}");

            // Обновление прокачки игрока.
            labelLevel.Text = ($"Уровень: {player1.level}");
            Double ex = Math.Round(player1.exp, 0);
            labelExp.Text = ($"exp: {ex}/10000");
            labelPoint.Text = ($"Нераспределённых очков:{player1.point}");

            // Обновление состояния машины.
            Double wh = Math.Round(player1.wheels, 1);
            labelWheels.Text = ($"Колёса: {wh}%");
            Double su = Math.Round(player1.suspension, 1);
            labelSuspension.Text = ($"Подвеска: {su}%");
            Double en = Math.Round(player1.engine, 1);
            labelEngine.Text = ($"Двигатель: {en}%");
            Double cb = Math.Round(player1.carBody, 1);
            labelCarBody.Text = ($"Кузов: {cb}%");
            Double di = Math.Round(player1.dirt, 1);
            labelDirt.Text = ($"Грязь: {di}%");
            Double ga = Math.Round(player1.gas, 1);
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

            if (player1.onJob)
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
            if (player1.food  <= 0 || player1.water <= 0 || player1.energy <= 0)             //Логическое ИЛИ
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
            player1.onJob = true;
            button5.Enabled = false;
            button7.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
            groupBox4.Enabled = true;
            player1.onJob = false;
            button5.Enabled = true;
            button7.Enabled = false;
        }
        //Клиенты такси
        TaxiCustomers[] customers = new TaxiCustomers[32];
        public string GetRaceName(int race)
        {
            switch (race)
            {
                case 0: return "Украина";
                case 1: return "Россия";
                case 2: return "США";
                case 3: return "Япония";
                case 4: return "Латвия, Рига";
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
            ListBoxAdd();
            if (player1.workingCar)
            {
                int r = RandomCustomers();
                customers[0] = new TaxiCustomers("Гордон Фримен", 0, 2);
                customers[1] = new TaxiCustomers("Лысый Из Лоста", 0, 2);
                customers[2] = new TaxiCustomers("Китаец Из Лоста", 0, 3);
                customers[3] = new TaxiCustomers("G-MAN", 0, 0);
                customers[4] = new TaxiCustomers("Ozon671Games3", 0, 1);
                customers[5] = new TaxiCustomers("Абдуль", 0, 1);
                customers[6] = new TaxiCustomers("Навальный", 0, 0);
                customers[7] = new TaxiCustomers("Moby (яйценюх)", 0, 0);
                customers[8] = new TaxiCustomers("Кличко", 0, 0);
                customers[9] = new TaxiCustomers("Геральт Из Ривии", 0, 4);
                customers[10] = new TaxiCustomers("Макс Пейн", 0, 2);
                RandomCustomers();

                TaxiForm newForm = new TaxiForm();
                newForm.label1.Text = customers[r].name;
                newForm.life = player1.life; // Передача ссылки на бул ЛАЙФ охуеть а че так можно было?
                newForm.ShowDialog();
                //DialogResult dialogResult = MessageBox.Show("Имя: " + customers[r].name + Environment.NewLine
                //+ "Гражданство: " + GetRaceName(customers[r].race) + Environment.NewLine
                //+ "Пол: " + GetGenderName(customers[r].gender) + Environment.NewLine
                //+ "Расстояние: " + customers[r].distance + " метров" + Environment.NewLine
                //+ "Деньги за поездку: " + customers[r].fare + " руб.", "Упс", MessageBoxButtons.YesNo);

                if (player1.life)
                {
                    milSec += customers[r].distance / 4;
                    player1.exp += customers[r].distance / 7;
                    CarDamage();
                    MoneyManagement();
                    player1.life = false;
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Машине пизда, кажись пора в автосервис", "Блять!", MessageBoxButtons.OK);
            }
        }
        public int RandomCustomers()
        {
            Random rand = new Random();
            int r = rand.Next(11);
            return r;
        }
        // Машина дамажится от дистанции
        public void CarDamage()
        {
            int r = RandomCustomers();
            player1.wheels -= customers[r].distance / 4000;
            player1.suspension -= customers[r].distance / 3200;
            player1.engine -= customers[r].distance / 4800;
            player1.carBody -= customers[r].distance / 3800;
            player1.gas -= customers[r].distance / 1600;
            player1.dirt += customers[r].distance / 4000;


        }

        
        // Деньги прибавляются от дистанции
        public void MoneyManagement()
        {
            int r = RandomCustomers();
            player1.money += customers[r].fare;
        }
        
        // кнопочки
        private void button1_Click(object sender, EventArgs e)
        {
            day++;
            
        }
        // Чилить 10 минут
        private void button2_Click(object sender, EventArgs e) 
        {
            milSec += 600;
            
        }
        

        private void button3_Click_1(object sender, EventArgs e)
        {
            player1.wheels -= 10;
            

        }

        // Рандомные ники
        private void button4_Click(object sender, EventArgs e)
        {
           labelNick.Text = NickGetter.GetNick();
        }


        // Кнопки прокачки (SkillUp.cs)
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp(player1.point, player1.iq, 1);
            skillUp.SkillManipulated();
            player1.point = skillUp.ace;
            player1.iq = skillUp.skill;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp(player1.point, player1.power, 1);
            skillUp.SkillManipulated();
            player1.point = skillUp.ace;
            player1.power = skillUp.skill;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp(player1.point, player1.driving, 1);
            skillUp.SkillManipulated();
            player1.point = skillUp.ace;
            player1.driving = skillUp.skill;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp(player1.point, player1.speech, 1);
            skillUp.SkillManipulated();
            player1.point = skillUp.ace;
            player1.speech = skillUp.skill;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp(player1.point, player1.virus, 1);
            skillUp.SkillManipulated();
            player1.point = skillUp.ace;
            player1.virus = skillUp.skill;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp(player1.point, player1.ukraine, 1);
            skillUp.SkillManipulated();
            player1.point = skillUp.ace;
            player1.ukraine = skillUp.skill;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp(player1.point, player1.maxHp, 10);
            skillUp.multiplierSkill = 10;
            skillUp.SkillManipulated();
            player1.point = skillUp.ace;
            player1.maxHp = skillUp.skill;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp(player1.point, player1.maxFood, 10);
            skillUp.SkillManipulated();
            player1.point = skillUp.ace;
            player1.maxFood = skillUp.skill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp(player1.point, player1.maxWater, 10);
            skillUp.SkillManipulated();
            player1.point = skillUp.ace;
            player1.maxWater = skillUp.skill;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp(player1.point, player1.maxEnergy, 10);
            skillUp.SkillManipulated();
            player1.point = skillUp.ace;
            player1.maxEnergy = skillUp.skill;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SkillUp skillUp = new SkillUp(player1.point, player1.maxIntoxication, 10);
            skillUp.SkillManipulated();
            player1.point = skillUp.ace;
            player1.maxIntoxication = skillUp.skill;
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

            string offensiveNickname = NickGetter.GetOffensiveNickname();




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
                $"Охуеть да у тебя на руках целых {player1.money} рублей)) ебать ты лох)) но щас не об этом. "
            };
            int rum2 = rnd.Next(rumor2.Length);

            string[] rumor3 =
            {
                $"{name} оказывается то... это самое... ", $"этот как его блять... А! {name} кароче. ", $"Слышал о челике по имени {name}? ",
                $"Когда я учился в школе, был у меня один друг по имени {name}. Правда сам он называл себя {nickName} (но все звали его просто {offensiveNickname}). ",
                $"Помнишь того чела? Имя у него такое дибильное ещё... {name} чтоли или как то так."
            };
            int rum3 = rnd.Next(rumor3.Length);

            string[] rumor4 =
            {
                $"Пидор он вообщем))", $"Он провёз тридцать кило героина в такси! У себя в жопе!", $"А ладно забудь... Иди на хуй кароче)))",
                "Да блять он блять обосрал блять он перданул блять он обосрал свои эти шорты нахуй и пришлось ему от говна их немножко оттереть блять" +
                " и бросить в стирку нахуй и потом жопу ещё поддмыть блять и всё это заняло время бля вооот сейчас надо пойти что-то другое одеть блять" +
                " такая вот хуйня это всё из-за бухла блять бухло слабит типа расслабляет во всех смыслах этого слова ебать",
                $"Кароч {name} вчера отцу признался что он гей. Его отец выглядел покинутым и лишь спросил: - У тебя парень есть? - {name} грустно ответил что есть. Его отец спросил еще " +
                $"И ты его прямо в пердачелло?. {name} кивнул. - Долбишься в сракотан? Опять {name} грустно кивнул. Теребишь его в попчанский? Ебошишь его в шоколадницу?" +
                $"Месишь черное тесто с перцем? Заезжаешь на ночь в Попенгаген? Смотрел фильм Чарли и шоколадная фабрика? {name} послал нахуй отца и ушел."


            };
            int rum4 = rnd.Next(rumor4.Length);

            DialogResult dialogResult = MessageBox.Show((rumor1[rum1]) + (rumor2[rum2]) + (rumor3[rum3]) + (rumor4[rum4]), "Вы узнаёте хуйню", MessageBoxButtons.OK);
            
        }
        // автосервис
        private void button9_Click(object sender, EventArgs e)
        {
            player1.money -= 100;
            player1.gas += player1.maxGas;
            player1.wheels += player1.maxWheels;
            player1.suspension += player1.maxSuspension;
            player1.carBody += player1.maxCarBody;
            player1.workingCar = true;
        }
    }
}
