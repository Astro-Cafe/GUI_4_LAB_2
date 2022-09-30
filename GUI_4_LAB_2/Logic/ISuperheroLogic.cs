using GUI_4_LAB_2.Models;
using System.Collections.Generic;

namespace GUI_4_LAB_2.Logic
{
	public interface ISuperheroLogic
	{
		int AllCost { get; }
		double AVGPower { get; }
		double AVGSpeed { get; }

		void AddToBattlefield(Superhero sh);
		void CreateSuperhero();
		void EditSuperhero(Superhero sh);
		void RemoveFromBattlefield(Superhero sh);
		void Save(Superhero sh);
		void SetupCollections(IList<Superhero> hq, IList<Superhero> bf);
	}
}