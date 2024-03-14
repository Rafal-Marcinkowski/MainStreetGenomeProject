using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainStreetGenomeProject.MVVM.ViewModels;
public class MainViewModel : BaseViewModel
{
    public ICommand StartCommand =>
        new RelayCommand(() =>
        {

        });
}
