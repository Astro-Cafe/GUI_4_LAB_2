using GUI_4_LAB_2.Logic;
using GUI_4_LAB_2.Models;
using GUI_4_LAB_2.Shared;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_4_LAB_2.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        ISuperheroLogic logic;
        public ObservableCollection<Superhero> HQ { get; set; }
        public ObservableCollection<Superhero> Battlefield { get; set; }


        private Superhero selectedFromHq;
        public Superhero SelectedFromHq
        {
            get { return selectedFromHq; }
            set
            {
                SetProperty(ref selectedFromHq, value);
                (AddToBattlefieldCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditSuperheroCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Superhero selectedFromBattlefield;
        public Superhero SelectedFromBattlefield
        {
            get { return selectedFromBattlefield; }
            set
            {
                SetProperty(ref selectedFromBattlefield, value);
                (RemoveFromBattlefieldCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddToBattlefieldCommand { get; set; }
        public ICommand RemoveFromBattlefieldCommand { get; set; }
        public ICommand EditSuperheroCommand { get; set; }
        public ICommand CreateSuperheroCommand { get; set; }

        public int AllCost
        {
            get
            {
                return logic.AllCost;
            }
        }
        public double AVGPower
        {
            get
            {
                return logic.AVGPower;
            }
        }
        public double AVGSpeed
        {
            get
            {
                return logic.AVGSpeed;
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
			: this(IsInDesignMode ? null : Ioc.Default.GetService<ISuperheroLogic>())
        {

        }

        public MainWindowViewModel(ISuperheroLogic logic)
        {
            this.logic = logic;

            HQ = new ObservableCollection<Superhero>();
            Battlefield = new ObservableCollection<Superhero>();

            //HQ = JsonSerializer.Deserialize<ObservableCollection<Superhero>>("HQData.json");
            //Battlefield = JsonSerializer.Deserialize<ObservableCollection<Superhero>>("BattlefieldData.json");

            ;



            logic.SetupCollections(HQ, Battlefield);

            AddToBattlefieldCommand = new RelayCommand(
                () => logic.AddToBattlefield(selectedFromHq),
                () => SelectedFromHq != null
                );

            RemoveFromBattlefieldCommand = new RelayCommand(
                () => logic.RemoveFromBattlefield(selectedFromBattlefield),
                () => SelectedFromBattlefield != null
                );

            EditSuperheroCommand = new RelayCommand(
                () => logic.EditSuperhero(SelectedFromHq),
                () => SelectedFromHq != null
                );

            CreateSuperheroCommand = new RelayCommand(
                () => logic.CreateSuperhero()
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "SHINFO", (recepient, msg) =>
            {
                OnPropertyChanged("AllCost");
                OnPropertyChanged("AVGSpeed");
                OnPropertyChanged("AVGPower");
            });
        }

        public void ExportClosingData()
		{

            string hqJsonString = JsonSerializer.Serialize(HQ);
            string battlefieldJsonString = JsonSerializer.Serialize(Battlefield);
            File.WriteAllText("HQData.json", hqJsonString);
            File.WriteAllText("BattlefieldData.json", battlefieldJsonString);
        }
    }
}
