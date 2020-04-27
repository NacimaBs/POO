using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Clubtennismvvm.Models;

namespace Clubtennismvvm.ModelsVues
{
    public class SimpleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private bool canExecute;
        private Action<object> action;
       
        private Action<BindingList<MembreModel>, ListeMembreModelVue.DelegateTri> trierPar;
        private Action<BindingList<MembreModel>, ListeMembreModelVue.DelegateTri, object> trierPar1;

        public SimpleCommand(Action<object> action)
        {
            this.action = action;
            
        }

        public SimpleCommand(Action<BindingList<MembreModel>, ListeMembreModelVue.DelegateTri> trierPar)
        {
            
            this.trierPar = trierPar;
        }

        public SimpleCommand(Action<BindingList<MembreModel>, ListeMembreModelVue.DelegateTri, object> trierPar1)
        {
           
            this.trierPar1 = trierPar1;
        }

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            if(CanExecuteChanged!=null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public virtual void Execute(object parameter)
        {
          
            this.action(parameter);
        }
    }
}
