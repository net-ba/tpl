using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ERNI.Training.TPL.BrowserExercise.ViewModels
{
    public class ImageViewModel : ViewModelBase
    {
        private readonly byte[] _imageBytes;
        private readonly BitmapImage _bitmapImage;

        public ImageViewModel(byte[] imageBytes)
        {
            if (imageBytes == null)
            {
                throw new ArgumentNullException(nameof(imageBytes));
            }

            _imageBytes = imageBytes;
            _bitmapImage = new BitmapImage();
            _bitmapImage.BeginInit();
            _bitmapImage.DownloadCompleted += BitmapImageOnDownloadCompleted;
            _bitmapImage.DecodeFailed += BitmapImageOnDecodeFailed;
            _bitmapImage.DownloadFailed += BitmapImageOnDownloadFailed;
            _bitmapImage.StreamSource = new MemoryStream(_imageBytes, false);
            _bitmapImage.EndInit();
        }

        public double Height
        {
            get
            {
                try
                {
                    return _bitmapImage.Height;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public double Width
        {
            get
            {
                try
                {
                    return _bitmapImage.Width;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        private void BitmapImageOnDownloadCompleted(object sender, EventArgs e)
        {
            RaisePropertyChanged(nameof(Height));
            RaisePropertyChanged(nameof(Width));
        }

        private void BitmapImageOnDownloadFailed(object sender, ExceptionEventArgs e)
        {
            MessageBox.Show(e.ErrorException.ToString());
        }

        private void BitmapImageOnDecodeFailed(object sender, ExceptionEventArgs e)
        {
            MessageBox.Show(e.ErrorException.ToString());
        }

        public ImageSource ImageSource
        {
            get { return _bitmapImage; }
        }
    }
}
