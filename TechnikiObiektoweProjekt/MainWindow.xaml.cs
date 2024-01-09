using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TechnikiObiektoweProjekt;

namespace WpfTwoPatterns
{
    public partial class MainWindow : Window
    {
        private SortingContext sortingContext;

        public MainWindow()
        {
            InitializeComponent();
            sortingContext = SortingContext.Instance;
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text;
                List<int> numbers = input.Split(',').Select(int.Parse).ToList();

                if (StrategyComboBox.SelectedItem != null)
                {
                    string selectedStrategy = ((ComboBoxItem)StrategyComboBox.SelectedItem).Content.ToString();

                    ISortStrategy sortStrategy = null;

                    switch (selectedStrategy)
                    {
                        case "Bubble Sort":
                            sortStrategy = new TimingDecorator(new BubbleSortStrategy());
                            break;
                        case "Quick Sort":
                            sortStrategy = new TimingDecorator(new QuickSortStrategy());
                            break;
                        case "Merge Sort":
                            sortStrategy = new TimingDecorator(new MergeSortStrategy());
                            break;
                        case "Selection Sort":
                            sortStrategy = new TimingDecorator(new SelectionSortStrategy());
                            break;
                        default:
                            throw new ArgumentException("Unsupported sorting strategy");
                    }

                    if (sortStrategy != null)
                    {
                        sortingContext = SortingContext.Instance;

                        sortingContext.SetStrategy(sortStrategy);
                        sortingContext.ExecuteSort(numbers);

                        ResultTextBlock.Text = $"Sorted numbers: {string.Join(", ", numbers)}\nSorting time: {sortingContext.SortingTime} nanoseconds";
                    }
                }
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = $"Error: {ex.Message}";
            }
        }
    }
}
