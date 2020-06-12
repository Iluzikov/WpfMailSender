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
            MainVM.SelectedTab--;
        }
        private bool CanPreviousCommandExecute(object p)
        {
            return MainVM.SelectedTab > 0;
        }

        public ICommand NextCommand { get; }
        private void OnNextCommandExecuted(object p)
        {
            MainVM.SelectedTab++;
        }
        private bool CanNextCommandExecute(object p)
        {
            return MainVM.SelectedTab < MainVM.TabItemMax;
        }

        #endregion

    }
}
