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
using System.Linq;
using System.Text;
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
        //public ICommand CreateSuperheroCommand { get; set; }

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

            HQ.Add(new Superhero
            {
                Name = "Dora The Destroyer",
                Power = 10,
                Speed = 5,
                Aligment =Aligment.good

            });
            HQ.Add(new Superhero
            {
                Name = "Chadler",
                Power = 10,
                Speed = 10,
                Aligment = Aligment.neutral

            });
            HQ.Add(new Superhero
            {
                Name = "Csillámfaszláma",
                Power = 1,
                Speed = 3,
                Aligment = Aligment.evil

            });

            Battlefield.Add(HQ[0].GetCopy());
            Battlefield.Add(HQ[1].GetCopy());



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

            Messenger.Register<MainWindowViewModel, string, string>(this, "SHINFO", (recepient, msg) =>
            {
                OnPropertyChanged("AllCost");
                OnPropertyChanged("AVGSpeed");
                OnPropertyChanged("AVGPower");
            });
        }
    }
}
