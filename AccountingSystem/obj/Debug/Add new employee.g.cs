﻿#pragma checksum "..\..\Add new employee.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0D07CCE376E9EBD26C217E640228CB5B144518EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AccountingSystem;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AccountingSystem {
    
    
    /// <summary>
    /// Add_new_employee
    /// </summary>
    public partial class Add_new_employee : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Add new employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LastName;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Add new employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastNameBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Add new employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label startWorking;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Add new employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Add new employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FirstName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Add new employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstNameBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Add new employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker StartDateBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Add new employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Confirm;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Add new employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AccountingSystem;component/add%20new%20employee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Add new employee.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LastName = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.LastNameBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\Add new employee.xaml"
            this.LastNameBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.startWorking = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.FirstName = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.FirstNameBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\Add new employee.xaml"
            this.FirstNameBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StartDateBox = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.Confirm = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\Add new employee.xaml"
            this.Confirm.Click += new System.Windows.RoutedEventHandler(this.AddNewEmpl);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\Add new employee.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
