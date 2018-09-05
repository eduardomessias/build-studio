using System;
using System.ComponentModel;

namespace BuildStudio.Core.Data.Base
{
    public interface IEntity: INotifyPropertyChanged
    {
        int Id { get; set; }

        DateTime Creation { get; set; }
        string CreatedBy { get; set; }

        DateTime Update { get; set; }
        string ModifiedBy { get; set; }

        bool Active { get; set; }
    }
}
