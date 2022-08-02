using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace avaloniaListTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // InitializeComponent();
            // DataContext = this;

            BuildComponents();
        }

        public List<string> List => new List<string> { "Item 1", "Item 2", "Item 3" };

        private void BuildComponents()
        {
            var button = new Button()
            {
                Content = "Click me"
            };

            var list = new ListBox();
            list.DataTemplates.Add(new FuncDataTemplate<string>(
                (name, _) =>
                    new Button()
                    {
                        Content = name,
                    }
                , true));

            list.Items = List;

            var flyout = new Flyout()
            {
                Content = list,
            };

            button.Flyout = flyout;

            var panel = new Panel();
            panel.Children.Add(button);
            Content = panel;
        }

        private IControl CreateItemContent(string name)
        {
            Button onlyAllButton = new Button()
            {
                Content = "Button",
            };
            return onlyAllButton;
        }
    }
}