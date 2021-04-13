using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorWinForm
{
	class TaxiCustomers
	{
		public string name;
		public double distance;
		public double fare;
		public int dickLength;
		public int gender;  //0 - мужик, 1 - телка
		public int race;    //0 - украина, 1 - россия, 2 - США, 3 - ЯПонец

		public TaxiCustomers(string n, int g, int r)
		{
			Random rand = new Random();
			
			name = n;
			race = r;
			gender = g;
			distance = rand.Next(90, 6999);
			fare = distance / 20;
			dickLength = rand.Next(5, 20);
			
		}

		
	}
}
