using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMakerDemo
{
	public class Coffee
	{
		private int espressoShots;
		private int cupsOfMilk;
		private int cupsOfIce;
		private List<Sweetener> sweetenerList = new List<Sweetener>();

		public int GetEspressoShots()
		{
			return espressoShots;
		}
		public void SetEspressoShots(int espressoShots)
		{
			this.espressoShots = espressoShots;
		}
		public int GetCupsOfMilk()
		{
			return cupsOfMilk;
		}
		public void SetCupsOfMilk(int cupsOfMilk)
		{
			this.cupsOfMilk = cupsOfMilk;
		}
		public int GetCupsOfIce()
		{
			return cupsOfIce;
		}
		public void SetCupsOfIce(int cupsOfIce)
		{
			this.cupsOfIce = cupsOfIce;
		}
		public List<Sweetener> GetSweetenerList()
		{
			return sweetenerList;
		}
		public void SetSweetenerList(List<Sweetener> sweetenerList)
		{
			this.sweetenerList = sweetenerList;
		}
	}
}
