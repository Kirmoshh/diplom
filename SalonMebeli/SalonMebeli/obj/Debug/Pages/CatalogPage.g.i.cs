﻿#pragma checksum "..\..\..\Pages\CatalogPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A864343415999CDBDAF7F8DBFEFB8929BB80F92E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SalonMebeli.Pages;
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


namespace SalonMebeli.Pages {
    
    
    /// <summary>
    /// CatalogPage
    /// </summary>
    public partial class CatalogPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxSearch;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboDiscont;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboSort;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockCount;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockBasketInfo;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxProducts;
        
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
            System.Uri resourceLocater = new System.Uri("/SalonMebeli;component/pages/catalogpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\CatalogPage.xaml"
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
            
            #line 10 "..\..\..\Pages\CatalogPage.xaml"
            ((SalonMebeli.Pages.CatalogPage)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TBoxSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\Pages\CatalogPage.xaml"
            this.TBoxSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TBoxSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ComboDiscont = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\..\Pages\CatalogPage.xaml"
            this.ComboDiscont.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboDiscont_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ComboSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 42 "..\..\..\Pages\CatalogPage.xaml"
            this.ComboSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboSort_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBlockCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TextBlockBasketInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.ListBoxProducts = ((System.Windows.Controls.ListBox)(target));
            
            #line 56 "..\..\..\Pages\CatalogPage.xaml"
            this.ListBoxProducts.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxProducts_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 97 "..\..\..\Pages\CatalogPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

