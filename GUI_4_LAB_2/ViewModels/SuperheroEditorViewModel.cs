using GUI_4_LAB_2.Models;
using GUI_4_LAB_2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GUI_4_LAB_2.ViewModels
{
    public class SuperheroEditorViewModel
    {
        public Superhero Current { get; set; }

        public SuperheroEditorViewModel()
        {

        }
        
        public void Setup(Superhero superhero)
        {
            this.Current = superhero;
        }

    }
}