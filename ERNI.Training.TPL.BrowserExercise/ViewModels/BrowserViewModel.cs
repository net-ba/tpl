using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ERNI.Training.TPL.BrowserExercise.Model;

namespace ERNI.Training.TPL.BrowserExercise.ViewModels
{
    public class BrowserViewModel : ViewModelBase
    {
        private readonly RelayCommand _goCommand;
        private readonly RelayCommand _stopCommand;
        private readonly ObservableCollection<ImageViewModel> _imageViewModels = new ObservableCollection<ImageViewModel>();
        private readonly HtmlProcessor _htmlProcessor;

        public BrowserViewModel(HtmlProcessor htmlProcessor)
        {
            if (htmlProcessor == null)
            {
                throw new ArgumentNullException(nameof(htmlProcessor));
            }

            _goCommand = new RelayCommand(OnGoCommand, CanExecuteGoCommand);
            _stopCommand = new RelayCommand(OnStopCommand, CanExecuteStopCommand);
            _htmlProcessor = htmlProcessor;

            _url = "http://github.com";
        }

        private string _url;

        public string Url
        {
            get { return _url; }
            set
            {
                if (SetValue(value, nameof(Url), ref _url))
                {
                    _goCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _htmlContent;

        public string HtmlContent
        {
            get { return _htmlContent; }
            private set { SetValue(value, nameof(HtmlContent), ref _htmlContent); }
        }

        public ICommand GoCommand
        {
            get { return _goCommand; }
        }

        public ICommand StopCommand
        {
            get { return _stopCommand; }
        }

        public IReadOnlyList<ImageViewModel> Images
        {
            get { return _imageViewModels; }
        }

        private CancellationTokenSource _cancellationTokenSource;

        public CancellationTokenSource CancellationTokenSource
        {
            get { return _cancellationTokenSource; }
            set
            {
                if (_cancellationTokenSource != null)
                {
                    _cancellationTokenSource.Cancel();
                    _cancellationTokenSource.Dispose();
                }

                _cancellationTokenSource = value;
            }
        }

        private void OnGoCommand(object parameter)
        {
            try
            {
                // TODO: Implement OnGoCommand
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanExecuteGoCommand(object parameter)
        {
            return !string.IsNullOrEmpty(Url);
        }

        private void OnStopCommand(object parameter)
        {
            try
            {
                // TODO: Implement OnStopCommand
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanExecuteStopCommand(object parameter)
        {
            return true;
        }
    }
}
