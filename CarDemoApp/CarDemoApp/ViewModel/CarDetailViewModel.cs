using System.ComponentModel;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace CarDemoApp.ViewModel
{
    class CarDetailViewModel : INotifyPropertyChanged
    {
        private Stream _pdfDocumentStream;
        public Stream PdfDocumentStream { get { return _pdfDocumentStream; } set { _pdfDocumentStream = value; NotifyPropertyChanged("PdfDocumentStream"); } }
        public event PropertyChangedEventHandler PropertyChanged;

        public CarDetailViewModel()
        {
            //PdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("CarDemoApp.Assets.GIS Succinctly.pdf");
        }
        public CarDetailViewModel(Stream pdfStream)
        {
            PdfDocumentStream = pdfStream;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
