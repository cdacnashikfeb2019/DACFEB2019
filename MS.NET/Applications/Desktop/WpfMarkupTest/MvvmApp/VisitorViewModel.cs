using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmApp
{
    using System.Windows.Input;

    public class VisitorViewModel : MvvmSupport.ViewModelBase
    {
        private VisitorModel model = new VisitorModel();

        private string nameToRegister;

        public string NameToRegister
        {
            get => nameToRegister;
            set => SetProperty(ref nameToRegister, value);
        }

        public IEnumerable<Visitor> Visitors => model.ReadVisitors();

        private bool CanExecuteRegister(object parameter)
        {
            return nameToRegister?.Length >= 3;
        }

        private void ExecuteRegister(object parameter)
        {
            model.WriteVisitor(nameToRegister);
            OnPropertyChanged(() => Visitors);
        }

        public ICommand Register => DispatchCommand();
    }
}
