using System.Collections.ObjectModel;
using System.ComponentModel;
//using static Android.Content.ClipData;

namespace TDMPW_412_3P_PR02;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    DateTime fecha = DateTime.Now;
    string pendiente = "";
    string estado = "";

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private ObservableCollection<Tarea> toDoList;

    public ObservableCollection<Tarea> ToDoList
    {
        get { return toDoList; }
        set
        {
            toDoList = value;
            OnPropertyChanged(nameof(ToDoList));
        }
    }


    public MainPage()
	{
		InitializeComponent();
        BindingContext = this;
        toDoList = new ObservableCollection<Tarea>();
        listaTareas.ItemsSource = ToDoList;
        
        
    }

    void btnAgregar_Clicked(System.Object sender, System.EventArgs e)
    {
        pendiente = txtTarea.Text;
        if (!string.IsNullOrEmpty(pendiente))
        {

            estado = "PENDIENTE";
            Tarea homework = new Tarea(pendiente, estado, fecha.ToString());
            ToDoList.Add(homework);
            listaTareas.ItemsSource = toDoList;
            txtTarea.Text = "";
        }
        else {
            
            ShowAlert("¡Cuidado!", "No puedes agregar una tarea vacía");
        }
    }

    void btnOk_Clicked(System.Object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;

        var item = btn.BindingContext as Tarea;

        if (item != null)
        {
            item.status = "COMPLETADO";
            item.IsTachado = true;
        }
        
    }

    void btnEliminar_Clicked(System.Object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;

        var item = btn.BindingContext as Tarea;

        if (item != null)
        {
            ToDoList.Remove(item);
        }
    }

    private async void ShowAlert(string title, string message)
    {
        await Application.Current.MainPage.DisplayAlert(title, message, "Aceptar");
        
    }

}


