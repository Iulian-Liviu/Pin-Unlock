using Pin_Unlock.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pin_Unlock.ViewModels
{
    public class PinPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //pin code as string 

        protected void RaisePropertyChanged([CallerMemberName] string key = null)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(key));
            }
        }

        protected void RaisePropertiesChanged(params string[] keys)
        {
            if (keys != null)
            {
                foreach (string key in keys)
                {
                    var propertyChanged = PropertyChanged;
                    if (propertyChanged != null)
                    {
                        propertyChanged(this, new PropertyChangedEventArgs(key));
                    }
                }
            }
        }

        public Func<IList<char>, bool> ValidatorFunc { get; }

       


        public ICommand ErrorCommand { get; }

        public ICommand SuccessCommand { get; }

        // check if match this
        private string code = "0101";

        public PinPageViewModel()
        {

            // Modify this based on input (char) (think of some way to check)
            ValidatorFunc = (arg) =>
            {
                //TODO Find a way to check for a custom code

                var r = string.Join(string.Empty, arg);

                if (r == code)
                {
                    return true;
                }

                //return false
                return false;
            };

            ErrorCommand = new Command(() =>
            {
                Debug.WriteLine("Entered PIN is wrong");
            });

            SuccessCommand = new Command(() =>
            {
                Debug.WriteLine("Entered PIN is correct");
                Application.Current.MainPage.Navigation.PushAsync(new WelcomePage());
            });
        }

    }
}
