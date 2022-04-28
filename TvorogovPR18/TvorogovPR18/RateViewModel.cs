using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;



namespace TvorogovPR18
{
    public class RateViewModel : INotifyPropertyChanged
    {
        private string text;
        private bool found;
        private decimal number;
        private string type;
        private DateTime date;
        private string response;

        public string Text
        {
            get { return text; }
            private set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public bool Found
        {
            get { return found; }
            private set
            {
                found = value;
                OnPropertyChanged("Found");
            }
        }
        public decimal Number
        {
            get { return number; }
            private set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
        public string Type
        {
            get { return type; }
            private set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        public DateTime Date
        {
            get { return date; }
            private set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public ICommand LoadDataCommand { protected set; get; }

        public RateViewModel()
        {
            this.LoadDataCommand = new Command(LoadData);
        }

        private async void LoadData()
        {
            string url = "http://numbersapi.com/random/year?json";

            try
            {
                using (var WebClient = new WebClient())
                {
                   response = WebClient.DownloadString(url);
                }

                var rateInfo = JsonConvert.DeserializeObject<RateInfo>(response);
                this.Text = rateInfo.Text;
                this.Found = rateInfo.Found;
                this.Number = rateInfo.Number;
                this.Type = rateInfo.Type;
                this.Date = rateInfo.Date;
            }
            catch (Exception ex)
            { }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
