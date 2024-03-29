﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GuiSamples.Wpf
{
    /// <summary>
    /// Thank you to https://stackoverflow.com/questions/3739059/prism-idataerrorinfo-validation-with-dataannotation-on-viewmodel-entities
    /// </summary>
    public abstract class BindableDataErrorInfoBase : BindableBase, IDataErrorInfo
    {
        #region IDataErrorInfo Members

        public Dictionary<string, string> ErrorDictionary = new Dictionary<string, string>();

        public string Error
        {
            get { return ErrorDictionary.Values.Count < 1 ? String.Empty: String.Join(", ", ErrorDictionary.Values); }
        }

        public string this[string columnName]
        {
            get
            {
                if (ErrorDictionary.ContainsKey(columnName))
                    return ErrorDictionary[columnName];
                return null;
            }
        }

        #endregion
    }
}