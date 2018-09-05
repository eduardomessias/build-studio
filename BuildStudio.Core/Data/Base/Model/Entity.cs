using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BuildStudio.Core.Data.Base.Model
{
    public class Entity : IEntity
    {
        public int Id { get; set; }

        public DateTime Creation { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }

        public DateTime Update { get; set; }
        public string ModifiedBy { get; set; }

        public bool Active { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
