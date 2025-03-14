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
using System.Xml;
using System.Xml.Linq;

namespace Coffee_Machine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool AddSugar = false;

        public MainWindow()
        {
            InitializeComponent();

            Menu.Visibility = Visibility.Visible;
            CofeeSelection.Visibility = Visibility.Hidden;
            CoffeeSelectionPageTwo.Visibility = Visibility.Hidden;
            CoffeePreparing.Visibility = Visibility.Hidden;
            CustomDrink.Visibility = Visibility.Hidden;
            Ready.Visibility = Visibility.Hidden;
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

        private async void Espresso_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            EspressoButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            EspressoButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            Drink drink = new Espresso();

            if (AddSugar == true)
                drink = new SugarDecorator(drink);

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

            await drink.MakeDrink(DrinkProgressBar, (val) =>
            {
                if (val == 99)
                {

                    Ready.Visibility = Visibility.Visible;

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
                    CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
                    ReadyDrinkTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);
                }
            });
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

        private async void Latte_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            LatteButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            LatteButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            Drink drink = new Latte();

            if (AddSugar == true)
                drink = new SugarDecorator(drink);

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

            await drink.MakeDrink(DrinkProgressBar, (val) =>
            {
                if (val == 99)
                {

                    Ready.Visibility = Visibility.Visible;

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
                    CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
                    ReadyDrinkTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);
                }
            });
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

        private async void Cappuccino_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            CappuccinoButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            CappuccinoButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            Drink drink = new Cappuccino();

            if (AddSugar == true)
                drink = new SugarDecorator(drink);


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

            await drink.MakeDrink(DrinkProgressBar, (val) =>
            {
                if (val == 99)
                {

                    Ready.Visibility = Visibility.Visible;

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
                    CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
                    ReadyDrinkTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);
                }
            });
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

        private async void PageTwo_PreviewMouseUp(object sender, MouseButtonEventArgs e)
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

        private async void Macchiato_PreviewMouseUp(object sender, MouseButtonEventArgs e) //bug, this is chocolate
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            MacchiatoButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            MacchiatoButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);


            Drink drink = new Macchiato();

            if(AddSugar == true)
                drink = new SugarDecorator(drink);

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

            await drink.MakeDrink(DrinkProgressBar, (val) =>
            {
                if (val == 99)
                {

                    Ready.Visibility = Visibility.Visible;

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
                    CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
                    ReadyDrinkTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);
                }
            });
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

        private async void Chocolate_PreviewMouseUp(object sender, MouseButtonEventArgs e) //bug, this is Macchiato
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            ChocolateButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            ChocolateButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            Drink drink = new Chocolate();

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

            if (DrinkProgressBar.Value == 99)
                MessageBox.Show("Test");

            currentPgeAnim.Completed += currentPgeAnimCompl;
            CoffeeTransformPageTwo.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
            CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);

            await drink.MakeDrink(DrinkProgressBar, (val) =>
            {
                if (val == 99)
                {

                    Ready.Visibility = Visibility.Visible;

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
                    CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
                    ReadyDrinkTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);
                }
            });
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

        private void PreparAnimCompl(object sender, EventArgs e)
        {
            CoffeePreparing.Visibility = Visibility.Hidden;
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

        private async void CupButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            CupButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            CupButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

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

            currentPgeAnim.Completed += customDrinkAnimCompl;
            CustomDrinkTransform.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
            CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);

            string timeText = TimeLable.Content.ToString(); 
            var matchTime = System.Text.RegularExpressions.Regex.Match(timeText, @"\d+");
            int time = matchTime.Success ? int.Parse(matchTime.Value) : 0;
            time *= 4;

            string costText = CostLable.Content.ToString();
            var matchCost = System.Text.RegularExpressions.Regex.Match(costText, @"\d+");
            int cost = matchCost.Success ? int.Parse(matchCost.Value) : 0;

            string name = "Coffee";

            var drink = new UserCustomDrink(name, TimeSpan.FromSeconds(time), cost);
            drink.MakeDrink(DrinkProgressBar);

            ChangeDrinkLabelContent(name);

            await drink.MakeDrink(DrinkProgressBar, (val) =>
            {
                if (val == 99)
                {

                    Ready.Visibility = Visibility.Visible;

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
                    CoffeePreparingTransform.BeginAnimation(TranslateTransform.XProperty, currentPgeAnim);
                    ReadyDrinkTransform.BeginAnimation(TranslateTransform.XProperty, coffeePrepAnim);
                }
            });
        }

        private void customDrinkAnimCompl(object sender, EventArgs e)
        {
            CofeeSelection.Visibility = Visibility.Hidden;
            CustomDrink.Visibility = Visibility.Hidden;
        }

        private void ReadyButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 1,
                To = 0.9,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            ReadyButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            ReadyButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        private void ReadyButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation scaleAnim = new DoubleAnimation
            {
                From = 0.9,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1)
            };

            ReadyButtonScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            ReadyButtonScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            Menu.Visibility = Visibility.Visible;

            DoubleAnimation ReadyAnim = new DoubleAnimation
            {
                From = 0,
                To = -900,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            DoubleAnimation menuAnim = new DoubleAnimation
            {
                From = 900,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            menuAnim.Completed += ReadyDrinkAnimationCompleted;
            ReadyDrinkTransform.BeginAnimation(TranslateTransform.XProperty, ReadyAnim);
            MenuTransform.BeginAnimation(TranslateTransform.XProperty, menuAnim);
        }

        private void ReadyDrinkAnimationCompleted(object sender, EventArgs e)
        { 
            Ready.Visibility= Visibility.Hidden;
        }

        #endregion

        #region Sliders

        private void SugarSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sugar.Opacity = SugarSlider.Value/10;
            int SugarPiece = Convert.ToInt32(SugarSlider.Value/2.5);
            SugarSliderValueLabel.Content = SugarPiece.ToString() + " p";
        }

        private void CoffeeSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CoffeeElipse.Opacity = CoffeeSlider.Value / 100;
            int CoffeeMl = Convert.ToInt32(CoffeeSlider.Value);
            CoffeeSliderValueLabel.Content = CoffeeMl.ToString() + " ml";    

            UpdateTotalCost();

        }

        private void MilkSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MilkElipse.Opacity = MilkSlider.Value / 100;
            int MilkMl = Convert.ToInt32(MilkSlider.Value);
            MilkSliderValueLabel.Content = MilkMl.ToString() + " ml";

            UpdateTotalCost();
        }

        private void FoamSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            FoamElipse.Opacity = FoamSlider.Value / 100;
            int FoamMl = Convert.ToInt32(FoamSlider.Value);
            FoamSliderValueLabel.Content = FoamMl.ToString() + " ml";

            UpdateTotalCost();
        }

        #endregion

        #region CheckBoxes

        void AddSugarPageTwoChecked(object sender, RoutedEventArgs e)
        {
            AddSugar = true;
            EspressoSugar.Opacity = 100;
            LatteSugar.Opacity = 100;
            CappuccinoSugar.Opacity = 100;  
            ChocolateSugar.Opacity = 100;
            MacchiatoSugar.Opacity = 100;
        }

        void AddSugarPageTwoUnChecked(object sender, RoutedEventArgs e)
        {
            AddSugar = false;
            EspressoSugar.Opacity = 0;
            LatteSugar.Opacity = 0;
            CappuccinoSugar.Opacity = 0;
            ChocolateSugar.Opacity = 0;
            MacchiatoSugar.Opacity = 0;
        }

        void AddSugarPageOneChecked(object sender, RoutedEventArgs e)
        {
            AddSugar = true;
            EspressoSugar.Opacity = 100;
            LatteSugar.Opacity = 100;
            CappuccinoSugar.Opacity = 100;
            ChocolateSugar.Opacity = 100;
            MacchiatoSugar.Opacity = 100;
        }

        void AddSugarPageOneUnChecked(object sender, RoutedEventArgs e)
        {
            AddSugar = false;
            EspressoSugar.Opacity = 0;
            LatteSugar.Opacity = 0;
            CappuccinoSugar.Opacity = 0;
            ChocolateSugar.Opacity = 0;
            MacchiatoSugar.Opacity = 0;
        }

        #endregion

        #region Logic

        abstract class Drink
        {
            public string Name { get; set; }
            public TimeSpan TimetoPrepare { get; set; }
            public decimal Cost { get; set; }

            public Drink(string name, TimeSpan time, decimal cost)
            {
                this.Name = name;
                this.TimetoPrepare = time;
                this.Cost = cost;
            }

            public abstract Task MakeDrink(ProgressBar progressBar, Action<double> onProgressChanged = null);
        }


        class Espresso : Drink
        {
            public Espresso() : base("Espresso", TimeSpan.FromSeconds(10), 3.00m) { }

            public override async Task MakeDrink(ProgressBar progressBar, Action<double> onProgressChanged = null)
            {
                progressBar.Value = 1;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                    onProgressChanged?.Invoke(i);
                }
            }
        }

        class Latte : Drink
        {
            public Latte() : base("Latte", TimeSpan.FromSeconds(15), 4.00m) { }

            public override async Task MakeDrink(ProgressBar progressBar, Action<double> onProgressChanged = null)
            {
                progressBar.Value = 1;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                    onProgressChanged?.Invoke(i);
                }
            }
        }

        class Cappuccino : Drink
        {
            public Cappuccino() : base("Cappuccino", TimeSpan.FromSeconds(10), 3.00m) { }

            public override async Task MakeDrink(ProgressBar progressBar, Action<double> onProgressChanged = null)
            {
                progressBar.Value = 1;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                    onProgressChanged?.Invoke(i);
                }
            }
        }

        class Macchiato : Drink
        {
            public Macchiato() : base("Macchiato", TimeSpan.FromSeconds(10), 4.00m) { }

            public override async Task MakeDrink(ProgressBar progressBar, Action<double> onProgressChanged = null)
            {
                progressBar.Value = 1;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                    onProgressChanged?.Invoke(i);
                }
            }
        }

        class Chocolate : Drink
        {
            public Chocolate() : base("Chocolate", TimeSpan.FromSeconds(10), 3.00m) { }

            public override async Task MakeDrink(ProgressBar progressBar, Action<double> onProgressChanged = null)
            {
                progressBar.Value = 1;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                    onProgressChanged?.Invoke(i);
                }
            }
        }

        class UserCustomDrink : Drink
        {
            public UserCustomDrink(string name, TimeSpan timeToPrepare, decimal cost)
                : base(name, timeToPrepare, cost)
            {
            }


            public override async Task MakeDrink(ProgressBar progressBar, Action<double> onProgressChanged = null)
            {   
                progressBar.Value = 1;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                    onProgressChanged?.Invoke(i);
                }
            }
        }

        //-----------------Decorators-------------------//

        class DrinkDecorator : Drink
        {
            protected Drink baseDrink;

            public DrinkDecorator(Drink BaseDrink) : base(BaseDrink.Name, BaseDrink.TimetoPrepare, BaseDrink.Cost)
            {
                this.baseDrink = BaseDrink;
            }

            public override Task MakeDrink(ProgressBar progressBar, Action<double> onProgressChanged = null)
            {
                return baseDrink.MakeDrink(progressBar, onProgressChanged);
            }
        }

        class SugarDecorator : DrinkDecorator
        {
            public SugarDecorator(Drink baseDrink) : base(baseDrink)
            {
                Name += " + Sugar";
                TimetoPrepare += TimeSpan.FromSeconds(2);
            }

            public override async Task MakeDrink(ProgressBar progressBar, Action<double> onProgressChanged = null)
            {
                progressBar.Value = 0;

                int steps = 100;
                int delay = (int)(TimetoPrepare.TotalMilliseconds / steps);

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(delay);
                    progressBar.Value = i;
                    onProgressChanged?.Invoke(i);
                }
            }
        }

        #endregion

        #region other methods

        public void ChangeDrinkLabelContent(string name)
        {
            DrinkNameLabel.Content = "Your " + name + " is being prepared...";
            DrinkReadyLabel.Content = "Your " + name + " is ready!";
        }

        private void UpdateTotalCost()
        {
            int coffeeMl = Convert.ToInt32(CoffeeSlider.Value);
            int milkMl = Convert.ToInt32(MilkSlider.Value);
            int foamMl = Convert.ToInt32(FoamSlider.Value);

            double costPerMl = 0.015;
            double totalCost = (coffeeMl + milkMl + foamMl) * costPerMl;
            double timePerFiftyMl = 0.5;
            double totalTime = (coffeeMl/50 + milkMl/50 + foamMl / 50) * timePerFiftyMl;

            if(totalTime < 1)
                TimeLable.Content = ">1 min";
            else
                TimeLable.Content = totalTime.ToString("F1") + " min";

            CostLable.Content = totalCost.ToString("F2") + " $";
        }

        #endregion
    }
}
