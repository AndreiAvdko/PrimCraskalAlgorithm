﻿#pragma checksum "..\..\GenerateRandomGraphWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E32FC161C858DE25D0174E86A54C9434335B877B0DADCD69A4D91628E2D2546E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PrimCraskalAlgorithm;
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


namespace PrimCraskalAlgorithm {
    
    
    /// <summary>
    /// GenerateRandomGraphWindow
    /// </summary>
    public partial class GenerateRandomGraphWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 70 "..\..\GenerateRandomGraphWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox minVertexCount;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\GenerateRandomGraphWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox maxVertexCount;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\GenerateRandomGraphWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox minEdgeCount;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\GenerateRandomGraphWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox maxEdgeCount;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\GenerateRandomGraphWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox maxLimitOfEdgeWeight;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\GenerateRandomGraphWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button generateGraphButton;
        
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
            System.Uri resourceLocater = new System.Uri("/PrimCraskalAlgorithm;component/generaterandomgraphwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GenerateRandomGraphWindow.xaml"
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
            this.minVertexCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.maxVertexCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.minEdgeCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.maxEdgeCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.maxLimitOfEdgeWeight = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.generateGraphButton = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\GenerateRandomGraphWindow.xaml"
            this.generateGraphButton.Click += new System.Windows.RoutedEventHandler(this.generateGraphButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

