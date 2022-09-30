using GUI_4_LAB_2.Models;
using GUI_4_LAB_2.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_4_LAB_2.Logic
{
	public class SuperheroLogic : ISuperheroLogic
	{
		IList<Superhero> hq;
		IList<Superhero> battlefield;
		IMessenger messenger;
		ISuperheroEditorService editorService;

		public SuperheroLogic(IMessenger mess, ISuperheroEditorService service)
		{
			this.messenger = mess;
			this.editorService = service;
		}

		public int AllCost
		{
			get
			{
				return battlefield.Count == 0 ? 0 : battlefield.Sum(t => t.Cost);
			}
		}

		public double AVGPower
		{
			get
			{
				return Math.Round(battlefield.Count == 0 ? 0 : battlefield.Average(t => t.Power), 2);
			}
		}

		public double AVGSpeed
		{
			get
			{
				return Math.Round(battlefield.Count == 0 ? 0 : battlefield.Average(t => t.Speed), 2);
			}
		}

		public void SetupCollections(IList<Superhero> hq, IList<Superhero> bf)
		{
			this.hq = hq;
			this.battlefield = bf;
		}

		public void AddToBattlefield(Superhero sh)
		{
			battlefield.Add(sh);
			messenger.Send("Superhero deployed!", "SHINFO");
			hq.Remove(sh);
		}

		public void RemoveFromBattlefield(Superhero sh)
		{
			battlefield.Remove(sh);
			messenger.Send("Superhero retrieved!", "SHINFO");
			hq.Add(sh);
		}

		public void EditSuperhero(Superhero sh)
		{
			editorService.Edit(sh);
		}

		public void CreateSuperhero()
		{
			editorService.Create();
		}

		public void Save(Superhero sh)
		{
			hq.Add(sh);
		}

	}
}
