using System;
using System.ComponentModel;

namespace TDMPW_412_3P_PR02
{
	public class Tarea: INotifyPropertyChanged
    {
        private string _status;
        private string _tarea;
        private string _fecha;
        private bool _isTachado;

        public bool IsTachado
        {
            get { return _isTachado; }
            set
            {
                if (_isTachado != value)
                {
                    _isTachado = value;
                    OnPropertyChanged("IsTachado");
                }
            }
        }

        public string status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged("status");
                }
            }
        }

        public string tarea
        {
            get { return _tarea; }
            set
            {
                if (_tarea != value)
                {
                    _tarea = value;
                    OnPropertyChanged("tarea");
                }
            }
        }

        public string fecha
        {
            get { return _fecha; }
            set
            {
                if (_fecha != value)
                {
                    _fecha = value;
                    OnPropertyChanged("fecha");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Tarea(string tarea, string status, string fecha)
		{
			this.tarea = tarea;
			this.status = status;
			this.fecha = fecha;
		}
	}
}

