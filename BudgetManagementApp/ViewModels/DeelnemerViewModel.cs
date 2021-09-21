using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BudgetManagementApp.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.ViewModel
{
    class DeelnemerViewModel //: INotifyPropertyChanged
    {
        /*
        #region Private Variables
        private readonly Deelnemer dlnObject;
        private readonly ObservableCollection<Deelnemer> deelnemers;
        private readonly DeelnemerManager deelnemerManager;
        private readonly ICommand addDeelnemerCmd;
        private readonly ICommand deleteDeelnemerCmd; 
        #endregion
        public ObservableCollection<string> Dagdelen { get; private set; }
       

        #region constructor
        public DeelnemerViewModel()
        {
            Dagdelen = new ObservableCollection<string>() { "maandagochtend", "maandagmiddag", "dinsdagochtend", "dinsdagmiddag", "woensdagochtend", "woensdagmiddag", "donderdagochtend", "donderdagmiddag", "vrijdagochtend", "vrijdagmiddag" };          
            dlnObject = new Deelnemer();

            deelnemerManager = new DeelnemerManager();
            deelnemers = new ObservableCollection<Deelnemer>();
            addDeelnemerCmd = new RelayCommand(Add, CanAdd);
            deleteDeelnemerCmd = new RelayCommand(Delete, CanDelete);
        }
        #endregion

        #region Properties


        private string _selectedDagdeel = null;
        public string SelectedDagdeel
        {
            get { return _selectedDagdeel; }
            set
            {
                _selectedDagdeel = value;
                dlnObject.Aanwezig.Add(value);
                OnPropertyChanged("SelectedDagdeel");
            }
        }

        public int Id
        {
            get { return dlnObject.Id; }
            set
            {
                dlnObject.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Voornaam
        {
            get { return dlnObject.Voornaam; }
            set
            {
                dlnObject.Voornaam = value;
                OnPropertyChanged("Voornaam");
            }
        }

        public string Werkplek
        {
            get { return dlnObject.Werkplek; }
            set
            {
                dlnObject.Werkplek = value;
                OnPropertyChanged("Werkplek");
            }
        }

        public List<string> Aanwezig
        {
            get { return dlnObject.Aanwezig; }
            set
            {
                dlnObject.Aanwezig = value;
                OnPropertyChanged("Aanwezig");
            }
        }

        public ObservableCollection<Deelnemer> Deelnemers { get { return deelnemers; } }

        public Deelnemer SelectedDeelnemer
        {
            set
            {
                Id = value.Id;
                Voornaam = value.Voornaam;
                Werkplek = value.Werkplek;
                Aanwezig = value.Aanwezig;
            }
        }
        #endregion

        #region Commands

        public ICommand AddDeelnemerCmd { get { return addDeelnemerCmd; } }
        public ICommand DeleteDeelnemerCmd { get { return deleteDeelnemerCmd; } }
        #endregion

        public bool CanAdd(object obj)
        {
            //Enable the Button only if the mandatory fields are filled
            if (Voornaam != string.Empty && Werkplek != string.Empty)
                return true;
            return false;
        }

        public void Add(object obj)
        {         
            var deelnemer = new Deelnemer { Voornaam = Voornaam, Werkplek = Werkplek, Aanwezig = Aanwezig };            
            if (deelnemerManager.Add(deelnemer))
            {
                Deelnemers.Add(deelnemer);
                //string txt = string.Join(String.Empty,Aanwezig);
                //MessageBox.Show(txt);
                //ResetDeelnemer();
            }
            else
                MessageBox.Show("Vul correcte waardes in!");
                
        }

        #region DeleteCommand        
        private bool CanDelete(object obj)
        {
            //Enable the Button only if the patients exist
            if (Deelnemers.Count > 0)
                return true;
            return false;
        }
        
        private void Delete(object obj)
        {
            //Delete patient will be successfull only if the patient with this ID exists.
            if (!deelnemerManager.Remove(Id))
                MessageBox.Show("Deelnemer met dit id bestaat niet!");
            else
            {
                //Remove the patient from our collection as well.
                deelnemers.RemoveAt(GetIndex(Id));
                ResetDeelnemer();
                MessageBox.Show("Deelnemer succesvol verwijderd !");
            }
        }

        #endregion

        #region Private Methods
        private void ResetDeelnemer()
        {
            Id = 0;
            Voornaam = string.Empty;
            Werkplek = string.Empty;
            Aanwezig.Clear();
        }

        private int GetIndex(int Id)
        {
            for (int i = 0; i < Deelnemers.Count; i++)
                if (Deelnemers[i].Id == Id)
                    return i;
            return -1;
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        */
    }
}
