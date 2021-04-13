using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorWinForm
{
    static class NickGetter
    {
        static string[] nickNames =
           {
                "Супер_Байкер_3D", "femboy", "Gnida", "KiSeK...^._.^...", "куколдрес", "хуй уменьшается", "сидоджи", "Аллах на травелах",
                "VIP Sex Energy VIP", "чЕбYпЕЛь=))))", "это гильдия, братан!", "$KYpidar", "CbIpOCTb_oT_HoCkA", "Your perdAk is under AttAck",
                "SvYt@yA_]{aRtOsHkA", "[Х]o4y B kJIaH Ho 9 E6JIaH", "Sosok-Admina", "BoЗbMy B РoT 3a 6yTEP6poT", "}{a|{eR_MaZaFa|{eR", "|’|uCe4Ka",
                "СкОлЬзКаЯ МоЧаЛкА", "Кура-с ИнтелеКтоМ", "бля внатуре хуй подымаеца", "Ебучий Случий", "Жак ебать_его_в_жопу фреско", "Penis",
                "Flame_ControL", "DOLBIT_NORMALNO", "Kuro", "Sony", "CTX", "ELEMAND", "TPAXER666", "GoPnIK_V_S4ND494H", "Mamka", "4iJIinu3Дpuk",
                "m1cr0_4elik", "null", "float", "adDIDAS", "произошла неизвестная ошибка...", "КАЗАХ228", "СуПеР_нЯшКа", "3D", "НиКсЕлЬ_пИкСеЛь",
                "Марти МакФуфел", "doctor sex", "engineer gaming", "ПОЛУПОКЕР", "пудипай", "SUPERb DRAG 3D", "admin", "АХАХАХАХАХАХАХАХАХАХАХАХАХАХА",
                "СтЕтХаМ", "забаньте меня", "5UP3R_}{0}{0JI", "упал с лестницы и пёрнул", "assassin777rus", "S.T.A.L.K.E.R", "Казахстан Супер Гуд",
                "nigger", "такой ник уже существует...", "ник добавлен...", "нихуя он умный", "Тодд Говард", "Годд Товард", "тРАХтынБёрг", "Far Cry 2",
                "}{отт@бь)4", "xota6", "пигси", "Самый Гейский Гей", "супер гнида 3д", "куда ты лезешь хуесосина", "Сан Саныч))", "DяDя Ванya",
                "Rейсист", "Супер-Мега-Член", "ФОШИСТ", "Не трольте", "кодер на минималках", "ГЛОБАЛ", "паша хуицепс", "Лохозавр", "Футбольчик",
                "Фанат доты 2", "Гейб", "Freeman", "ватник", "grand the slayer_XxX", "скайпидор", "Обожаю тарков", "я не пидор", "Пися Резанный",
                "Т0нNроВ@ннbIй_177rus", "Смени ник по братски", "брат", "oKUROk", "МНОГОЧЛЕН))", "Кто прочитал тот - гей!",
            };

        static string[] name =
            {
                "Васян", "Путин", "Директор нашего автопарка", "Мэддисон", "Скайшедоу", "СТХ", "Sony", "Лысый из лоста", "Уолтер Уайт",
                "Юрий Быков", "Юрий Хованский", "Влад А4", "Камикадзе Д"
            };
        
        public static string GetNick()
        {
            Random rnd = new Random();
            int nickName = rnd.Next(nickNames.Length);
            return nickNames[nickName];
        }
        public static string GetName()
        {
            Random rnd = new Random();
            int name1 = rnd.Next(name.Length);
            return name[name1];
        }
    }
}
