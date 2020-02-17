// Copyright Bishop(LEE YONG IL). All rights reserved.
// Licensed under the Apache license.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Bishop.DesignPattern.MVVM
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException("Expression is null");

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("Expression is not a 'MemberExpression'");

            var memberInfo = memberExpression.Member as MemberInfo;
            if (memberInfo == null)
                throw new ArgumentException("The member does not access.");

            var propertyInfo = memberInfo as PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentException("The member is not a property.");

            var propertyName = propertyInfo.Name;
            this.OnPropertyChanged(propertyName);
        }
    }
}
