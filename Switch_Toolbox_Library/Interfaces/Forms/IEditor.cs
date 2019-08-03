﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Library.Forms;
using System.Windows.Forms;

namespace Toolbox.Library
{
    public interface IEditor<T> where T : UserControl
    {
        T OpenForm();
        void FillEditor(UserControl Editor);
    }
}