using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer
{
    public partial class MainWindow : Window
    {
        private ViewModelExample VMExample { get; set; } = new ViewModelExample() { Name = "Jan Paweł II Papież", Age = 2137 };
    }

    class ViewModelExample : INotifyPropertyChanged
    {
        private string name;
        private int age;

        private ExampleCommand command;


        public ExampleCommand Command
        {
            get
            {
                if(command == null)
                {
                    command = new ExampleCommand(this);
                }
                return command;
            }
            set
            {
                command = value;
            }
        }


        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    class ExampleCommand : ICommand
    {
        private ViewModelExample vMField;
        public event EventHandler CanExecuteChanged;

        public ExampleCommand(ViewModelExample VMField) => this.vMField = VMField;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vMField.Name = DateTime.Now.ToString();
        }
    }
}
