// Copyright Bishop(LEE YONG IL). All rights reserved.
// Licensed under the Apache license.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Bishop.DesignPattern.MVVM
{
    public class RelayCommand : ICommand
    {
        private readonly Action myHandler;
        private bool myIsEnabled;

        public RelayCommand(Action handler)
        {
            myHandler = handler;
        }

        public bool IsEnabled
        {
            get { return myIsEnabled; }
            set
            {
                if (value != myIsEnabled)
                {
                    myIsEnabled = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            myHandler();
        }
    }
}
