using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMailSender.Commands;
using WpfMailSender.ViewModels.Base;

namespace WpfMailSender.ViewModels
{
    internal class MyTabSwitcherViewModel : ViewModelBase
    {
        public WpfMailSenderViewModel MainVM { get; internal set; }
        
        public MyTabSwitcherViewModel()
        {
            PreviousCommand = new RelayCommand(OnPreviousCommandExecuted, CanPreviousCommandExecute);
            NextCommand = new RelayCommand(OnNextCommandExecuted, CanNextCommandExecute);

        }

        #region Команды

        public ICommand PreviousCommand { get; }
        private void OnPreviousCommandExecuted(object p)
        {
            
        }
        private bool CanPreviousCommandExecute(object p)
        {
            return true;
        }

        public ICommand NextCommand { get; }
        private void OnNextCommandExecuted(object p)
        {

        }
        private bool CanNextCommandExecute(object p)
        {
            return true;
        }

        #endregion

    }
}
