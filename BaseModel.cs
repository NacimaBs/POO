using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    /// <summary>
    /// Model de base permettant l'implementation de l'interface INotifyPropertyChanged
    /// </summary>
    [Serializable()]
    public class BaseModel : INotifyPropertyChanged
    {
        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Methode utlisant l'interface INotifyPropertyChanged Pour notifier d'un changement dans une proprieté en xaml
        /// </summary>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
