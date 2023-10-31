using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfRechner.Commands;

/*
 * wir wollen keine Abhängungen zwischen View und Viewmodel sondern nur ein Databinding
 * Jede ViewModel-Klasse wir von BaseViewmodel abgeleitet
 * 
 * Reihenfolge:
 * 
 * 1) Window-Konstruktor wird aufgerufen
 * 2) this.Datacontext = _viewModel (hier wird intern auch eine anmeldung der View am Event
 *    der ViewModel-Klasse gemacht)
 * 3) Ein Property, das in der View angezeigt wird wird verändert
 * 4) durch die Implementierung des Set() wird OnPropertyChanged aufgerufen
 * 5) OnPropertyChanged() löst die Delegates am Event aus
 * 6) Die View zeichnet den Teil neu, der mit dem Property verbunden war ({Binding Ergebnis})
 */


namespace WpfRechner.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
       

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
