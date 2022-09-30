using GUI_4_LAB_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_4_LAB_2.Services
{
    public class SuperheroEditorViaWindow : ISuperheroEditorService
    {
		public void Create()
		{
            //WINDOW POPUP
            Superhero sh = new Superhero();
            new SuperheroEditor(sh,true).ShowDialog();
        }

		public void Edit(Superhero sh)
        {
            //WINDOW POPUP

            new SuperheroEditor(sh,false).ShowDialog();
        }
    }
}
