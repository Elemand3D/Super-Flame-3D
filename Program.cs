using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorWinForm
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            /*
             * Топовые идеи:
             * 1. Опция посмотреть телевизор = -1 iq, +1 знание украины.
             * 2. Клиенты такси имеют: 
             * (Имя), (Фамилию), (Номер телефона +7-(оператор)-???-??-??), (болезнь короной: да/нет), 
             * (украинец: да/нет), (предпочтение: помолчать/попиздеть/послушать музыку),
             * (пьяный да/нет), (наличие маски да/нет)
             * Чем больше iq игрока - тем больше шансов понять предпочтения клиента
             * Чем больше силы игрока - тем больше шансов усмирить пьяного клиента
             * Чем больше вождение игрока - тем качественней будет поездка (больше качества = выше оценка)
             * Чем больше харизма игрока - тем качественней будет поездка для любителей попиздеть и больш ешеансов усмирить пьяного клиента
             * Чем больше стойкость к вирусу - тем меньше шансов заразится. (маска -20% шанса на заражение, маска у тебя и у пассажира -80% шанса на заражение)
             * Чем больше знаний об украине - тем качественней будет поезка у украинцев.
             * Чем выше загрязнение машины тем менее качественная поездка.
             * 3. Нельзя возить клиентов если: 
             * (общее состояние машины < 30%), (грязь > 80%), (интоксикация > 80%)
             */

        }
    }
}
