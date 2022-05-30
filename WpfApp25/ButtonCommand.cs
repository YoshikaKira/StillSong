﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp25
{
    class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action _action;

        public ButtonCommand(Action _action)
        {
            this._action = _action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
