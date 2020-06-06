using System;
using System.Windows;
using System.Windows.Controls;

namespace TabSwitcher
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private bool _bHidebtnPrevious = false;
        private bool _bHidebtnNext = false;

        public bool IsHidebtnPrevious
        {
            get { return _bHidebtnPrevious; }
            set
            {
                _bHidebtnPrevious = value;
                SetButtons();
            }
        }
        public bool IsHidebtnNext
        {
            get { return _bHidebtnNext; }
            set
            {
                _bHidebtnNext = value;
                SetButtons();
            }
        }

        private void BtnNextTrueBtnPreviousFalse()
        {
            btnNext.Visibility = Visibility.Hidden;
            btnPrevious.Visibility = Visibility.Visible;
            btnPrevious.Width = 229;
            btnPrevious.HorizontalAlignment = HorizontalAlignment.Stretch;
            btnNext.Width = 0;
        }
        private void BtnPreviousTrueBtnNextFalse()
        {
            btnPrevious.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;
            btnNext.Width = 229;
            btnNext.HorizontalAlignment = HorizontalAlignment.Stretch;
            btnPrevious.Width = 0;
        }
        private void BtnNextFalseBtnPreviousFalse()
        {
            btnNext.Visibility = Visibility.Visible;
            btnPrevious.Visibility = Visibility.Visible;
            btnNext.Width = 115;
            btnPrevious.Width = 115;
        }
        private void BtnNextTrueBtnPreviousTrue()
        {
            btnNext.Visibility = Visibility.Hidden;
            btnPrevious.Visibility = Visibility.Hidden;
        }

        private void SetButtons()
        {
            if (_bHidebtnPrevious && _bHidebtnNext) BtnNextTrueBtnPreviousTrue();
            else if (!_bHidebtnPrevious && !_bHidebtnNext) BtnNextFalseBtnPreviousFalse();
            else if (!_bHidebtnPrevious && _bHidebtnNext) BtnNextTrueBtnPreviousFalse();
            else if (_bHidebtnPrevious && !_bHidebtnNext) BtnPreviousTrueBtnNextFalse();
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler btnNextClick;
        public event RoutedEventHandler btnPreviousClick;

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            btnNextClick?.Invoke(sender, e);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            btnPreviousClick?.Invoke(sender, e);
        }
    }
}
