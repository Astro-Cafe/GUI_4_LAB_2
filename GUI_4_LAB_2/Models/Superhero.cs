using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace GUI_4_LAB_2.Models
{
    public enum Aligment
    {
        evil, neutral, good
    }

    public class Superhero : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name,value); }
        }

        private int power;

        public int Power
        {
            get { return power; }
            set { SetProperty(ref power, value); }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }

		private Aligment aligment;

		public Aligment Aligment
        {
			get { return aligment; }
			set { aligment = value; }
		}
        

		public int Cost 
        {
            get
            {
                return speed * power;
            }
        }

        public Superhero GetCopy()
        {
            return new Superhero
            {
                Name = Name,
                power = power,
                speed = speed,
                aligment = aligment
                
            };
        }
    }
}
