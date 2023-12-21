using Newtonsoft.Json;
using System.ComponentModel;

namespace Teacher_s_Journal.Models
{
    class Student : INotifyPropertyChanged
    {
        private string? _name;
        [JsonProperty(PropertyName = "name")]
        public string? Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string? _group;
        [JsonProperty(PropertyName = "group")]
        public string? Group
        {
            get { return _group; }
            set
            {
                if (_group == value) return;
                _group = value;
                OnPropertyChanged("Group");
            }
        }

        private string? _score;
        [JsonProperty(PropertyName = "score")]
        public string? Score
        {
            get { return _score; }
            set
            {
                if (_score == value) return;
                _score = value;
                OnPropertyChanged("Score");
            }
        }

        private string? _comms;
        [JsonProperty(PropertyName = "comments")]
        public string? Comms
        {
            get { return _comms; }
            set
            {
                if (_comms == value) return;
                _comms = value;
                OnPropertyChanged("Comms");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
