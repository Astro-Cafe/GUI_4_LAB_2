using GUI_4_LAB_2.Logic;
using GUI_4_LAB_2.Models;
using GUI_4_LAB_2.Shared;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_4_LAB_2.ViewModels
{
    public class SuperheroEditorViewModel
    {
        ISuperheroLogic logic;
        public Superhero Current { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public SuperheroEditorViewModel() : this(IsInDesignMode? null : Ioc.Default.GetService<ISuperheroLogic>())
        {

        }

		public SuperheroEditorViewModel(ISuperheroLogic logic)
		{
            this.logic = logic;
		}
        
        public void Setup(Superhero superhero)
        {
            this.Current = superhero;
        }

        public void Save(string name,int power,int speed,Aligment aligment, bool creatorMode)
		{
            Current.Name = name;
            Current.Power = power;
            Current.Speed = speed;
            Current.Aligment = aligment;
			if (creatorMode)
                logic.Save(Current);
		}

    }
}