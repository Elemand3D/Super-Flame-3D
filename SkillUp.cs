using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorWinForm
{
    class SkillUp
    {
        public int ace;
        public int skill;
        public int multiplierSkill;

        public SkillUp(int a, int s, int m)
        {
            ace = a;
            skill = s;
            multiplierSkill = m;
        }
        public void SkillManipulated()
        {
            if (ace > 0)
            {
                ace--;
                skill += multiplierSkill;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Недостаточно очков умений, очки начисляются за каждый уровень", "Упс", MessageBoxButtons.OK);
            }
        }
    }
}
