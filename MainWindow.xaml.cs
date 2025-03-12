using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Coffee_Machine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Menu.Visibility = Visibility.Visible;
            CofeeSelection.Visibility = Visibility.Hidden;
            CoffeeSelectionPageTwo.Visibility = Visibility.Hidden;
            CoffeePreparing.Visibility = Visibility.Hidden;
            CustomDrink.Visibility = Visibility.Hidden;
        }

        #region Menu

        private void MenuButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 1,
                To = 0.9,  
                Duration = TimeSpan.FromSeconds(0.1)
            };

            MenuButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            MenuButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        private void MenuButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            MenuButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            MenuButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            CofeeSelection.Visibility = Visibility.Visible;

            DoubleAnimation menuAnim = new DoubleAnimation
            {
                From = 0,
                To = -900,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            DoubleAnimation coffeeAnim = new DoubleAnimation
            {
                From = 900,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            menuAnim.Completed += MenuAnimationCompleted;
            MenuTransform.BeginAnimation(TranslateTransform.XProperty, menuAnim);
            CoffeeTransform.BeginAnimation(TranslateTransform.XProperty, coffeeAnim);
        }

        private void MenuAnimationCompleted(object sender, EventArgs e)
        {
            Menu.Visibility = Visibility.Hidden;
        }

        #endregion

        #region chooseCoffeeOne

        private void Espresso_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 1,
                To = 0.9,  
                Duration = TimeSpan.FromSeconds(0.1)
            };

            EspressoButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            EspressoButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        private void Espresso_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            EspressoButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            EspressoButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            var drink = new Espresso();
            ChangeDrinkLabelContent(drink.Name);

            drink.MakeDrink(DrinkProgressBar);

            CoffeePreparing.Visibility = Visibility.Visible;

            DoubleAnimation currentPgeAnim = new DoubleAnimation
            {
                From = 0,
                To = -900,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            DoubleAnimation coffeePrepAnim = new DoubleAnimation
            {
                From = 900,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            currentPgeAnim.Completed += currentPgeAnimCompl;
            CoffeeTransform.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
            CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);
        }


        private void Latte_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 1,
                To = 0.9,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            LatteButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            LatteButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        private void Latte_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            LatteButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            LatteButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            var drink = new Latte();
            ChangeDrinkLabelContent(drink.Name);
            drink.MakeDrink(DrinkProgressBar);

            CoffeePreparing.Visibility = Visibility.Visible;

            DoubleAnimation currentPgeAnim = new DoubleAnimation
            {
                From = 0,
                To = -900,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            DoubleAnimation coffeePrepAnim = new DoubleAnimation
            {
                From = 900,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            currentPgeAnim.Completed += currentPgeAnimCompl;
            CoffeeTransform.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
            CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);
        }



        private void Cappuccino_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 1,
                To = 0.9,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            CappuccinoButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            CappuccinoButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        private void Cappuccino_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            CappuccinoButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            CappuccinoButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            var drink = new Cappuccino();
            ChangeDrinkLabelContent(drink.Name);
            drink.MakeDrink(DrinkProgressBar);

            CoffeePreparing.Visibility = Visibility.Visible;

            DoubleAnimation currentPgeAnim = new DoubleAnimation
            {
                From = 0,
                To = -900,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            DoubleAnimation coffeePrepAnim = new DoubleAnimation
            {
                From = 900,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            currentPgeAnim.Completed += currentPgeAnimCompl;
            CoffeeTransform.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
            CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);
        }



        private void PageTwo_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 1,
                To = 0.9,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            PageTwoButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            PageTwoButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        private void PageTwo_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            PageTwoButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            PageTwoButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            CoffeeSelectionPageTwo.Visibility = Visibility.Visible;

            DoubleAnimation pageOneAnim = new DoubleAnimation
            {
                From = 0,
                To = -1000,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            DoubleAnimation pageTwoAnim = new DoubleAnimation
            {
                From = 1000,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            pageTwoAnim.Completed += PageTwoAnimationCompleted;
            CoffeeTransform.BeginAnimation(TranslateTransform.XProperty, pageOneAnim);
            CoffeeTransformPageTwo.BeginAnimation(TranslateTransform.XProperty, pageTwoAnim);
        }

        private void PageTwoAnimationCompleted(object sender, EventArgs e)
        {
            CofeeSelection.Visibility = Visibility.Hidden;

        }

        #endregion

        #region chooseCofeeTwo
        private void Macchiato_PreviewMouseDown(object sender, MouseButtonEventArgs e) //bug, this is chocolate
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 1,
                To = 0.9,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            MacchiatoButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            MacchiatoButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        private void Macchiato_PreviewMouseUp(object sender, MouseButtonEventArgs e) //bug, this is chocolate
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            MacchiatoButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            MacchiatoButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            var drink = new Macchiato();
            ChangeDrinkLabelContent(drink.Name);
            drink.MakeDrink(DrinkProgressBar);

            CoffeePreparing.Visibility = Visibility.Visible;

            DoubleAnimation currentPgeAnim = new DoubleAnimation
            {
                From = 0,
                To = -900,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            DoubleAnimation coffeePrepAnim = new DoubleAnimation
            {
                From = 900,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            currentPgeAnim.Completed += currentPgeAnimCompl;
            CoffeeTransformPageTwo.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
            CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);
        }

        private void Chocolate_PreviewMouseDown(object sender, MouseButtonEventArgs e) //bug, this is Macchiato
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 1,
                To = 0.9,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            ChocolateButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            ChocolateButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        private void Chocolate_PreviewMouseUp(object sender, MouseButtonEventArgs e) //bug, this is Macchiato
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            ChocolateButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            ChocolateButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            var drink = new Chocolate();
            ChangeDrinkLabelContent(drink.Name);
            drink.MakeDrink(DrinkProgressBar);

            CoffeePreparing.Visibility = Visibility.Visible;

            DoubleAnimation currentPgeAnim = new DoubleAnimation
            {
                From = 0,
                To = -900,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            DoubleAnimation coffeePrepAnim = new DoubleAnimation
            {
                From = 900,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            currentPgeAnim.Completed += currentPgeAnimCompl;
            CoffeeTransformPageTwo.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
            CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);
        }

        private void currentPgeAnimCompl(object sender, EventArgs e)
        {
            CofeeSelection.Visibility = Visibility.Hidden;
            CoffeeSelectionPageTwo.Visibility = Visibility.Hidden;
        }

        private void AddMore_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 1,
                To = 0.9,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            AddMoreButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            AddMoreButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        private void AddMore_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            AddMoreButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            AddMoreButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            CustomDrink.Visibility = Visibility.Visible;

            DoubleAnimation currentPgeAnim = new DoubleAnimation
            {
                From = 0,
                To = -900,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            DoubleAnimation customDrinkAnim = new DoubleAnimation
            {
                From = 900,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            currentPgeAnim.Completed += currentPgeAnimCompl;
            CoffeeTransformPageTwo.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
            CustomDrinkTransform.BeginAnimation(TranslateTransform.XProperty, customDrinkAnim);
        }


        private void PageOne_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 1,
                To = 0.9,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            PageOneButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            PageOneButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        private void PageOne_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            PageOneButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            PageOneButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            CofeeSelection.Visibility = Visibility.Visible;

            DoubleAnimation pageOneAnim = new DoubleAnimation
            {
                From = -1000,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            DoubleAnimation pageTwoAnim = new DoubleAnimation
            {
                From = 0,
                To = 1000,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            pageOneAnim.Completed += PageOneAnimationCompleted;
            CoffeeTransform.BeginAnimation(TranslateTransform.XProperty, pageOneAnim);
            CoffeeTransformPageTwo.BeginAnimation(TranslateTransform.XProperty, pageTwoAnim);
        }

        private void PageOneAnimationCompleted(object sender, EventArgs e)
        {
            CoffeeSelectionPageTwo.Visibility = Visibility.Hidden;
        }
        #endregion

        #region CupPage

        private void CupButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 1,
                To = 0.9,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            CupButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            CupButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        private void CupButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            CupButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            CupButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);


        }

        #endregion

        #region Logic

        abstract class Drink
        {
            public string Name { get; set; }
            public TimeSpan TimetoPrepare { get; }
            public decimal Cost { get; }

            public Drink(string name, TimeSpan time, decimal cost)
            {
                this.Name = name;
                this.TimetoPrepare = time;
                this.Cost = cost;
            }

            public abstract void MakeDrink(ProgressBar progressBar);
        }


        class Espresso : Drink
        {
            public Espresso() : base("Espresso", TimeSpan.FromSeconds(10), 3.00m) { }

            public override async void MakeDrink(ProgressBar progressBar)
            {
                progressBar.Value = 1;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                }
            }
        }

        class Latte : Drink
        {
            public Latte() : base("Latte", TimeSpan.FromSeconds(15), 4.00m) { }

            public override async void MakeDrink(ProgressBar progressBar)
            {
                progressBar.Value = 1;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                }
            }
        }

        class Cappuccino : Drink
        {
            public Cappuccino() : base("Cappuccino", TimeSpan.FromSeconds(10), 3.00m) { }

            public override async void MakeDrink(ProgressBar progressBar)
            {
                progressBar.Value = 1;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                }
            }
        }

        class Macchiato : Drink
        {
            public Macchiato() : base("Macchiato", TimeSpan.FromSeconds(10), 4.00m) { }

            public override async void MakeDrink(ProgressBar progressBar)
            {
                progressBar.Value = 1;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                }
            }
        }

        class Chocolate : Drink
        {
            public Chocolate() : base("Chocolate", TimeSpan.FromSeconds(10), 3.00m) { }

            public override async void MakeDrink(ProgressBar progressBar)
            {
                progressBar.Value = 1;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                }
            }
        }

        #endregion

        #region other methods

        public void ChangeDrinkLabelContent(string name)
        {
            DrinkNameLabel.Content = "Your " + name + " is being prepared...";
        }

        #endregion

    }
}
