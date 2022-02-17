using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace calculatorFull
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, View.IOnClickListener
    {
        public int count = 0;
        public Button number1, number2, number3, number4, number5, number6, number7, number8, number9, number0, number00, add, sub, mul, div, percent, decima, equals, allClear, clear;
        public TextView expression, solution;
        public EditText userInput;
        public double input = 0, result = 0, multi = 1, counter2 = 1;
        public int counter = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            _uiReference();
        }
        public void _uiReference()
        {
            //Referencing the ui
            number1 = (Button)FindViewById(Resource.Id.numberOneButton);
            number1.SetOnClickListener(this);
            number2 = (Button)FindViewById(Resource.Id.numberTwoButton);
            number2.SetOnClickListener(this);
            number3 = (Button)FindViewById(Resource.Id.numberThreeButton);
            number3.SetOnClickListener(this);
            number4 = (Button)FindViewById(Resource.Id.numberFourButton);
            number4.SetOnClickListener(this);
            number5 = (Button)FindViewById(Resource.Id.numberFiveButton);
            number5.SetOnClickListener(this);
            number6 = (Button)FindViewById(Resource.Id.numberSixButton);
            number6.SetOnClickListener(this);
            number7 = (Button)FindViewById(Resource.Id.numberSevenButton);
            number7.SetOnClickListener(this);
            number8 = (Button)FindViewById(Resource.Id.numberEightButton);
            number8.SetOnClickListener(this);
            number9 = (Button)FindViewById(Resource.Id.numberNineButton);
            number9.SetOnClickListener(this);
            number0 = (Button)FindViewById(Resource.Id.numberZeroButton);
            number0.SetOnClickListener(this);
            number00 = (Button)FindViewById(Resource.Id.numberDoubleZeroButton);
            number00.SetOnClickListener(this);
            decima = (Button)FindViewById(Resource.Id.decimalButton);
            decima.SetOnClickListener(this);
            add = (Button)FindViewById(Resource.Id.addButton);
            add.SetOnClickListener(this);
            mul = (Button)FindViewById(Resource.Id.multiplyButton);
            mul.SetOnClickListener(this);
            sub = (Button)FindViewById(Resource.Id.subtractButton);
            sub.SetOnClickListener(this);
            div = (Button)FindViewById(Resource.Id.divisionButton);
            div.SetOnClickListener(this);
            equals = (Button)FindViewById(Resource.Id.equalsButton);
            equals.SetOnClickListener(this);
            allClear = (Button)FindViewById(Resource.Id.allClearButton);
            allClear.SetOnClickListener(this);
            clear = (Button)FindViewById(Resource.Id.clearButton);
            clear.SetOnClickListener(this);
            percent = (Button)FindViewById(Resource.Id.percentButton);
            percent.SetOnClickListener(this);
            expression = (TextView)FindViewById(Resource.Id.expressiontextView);
            expression.SetOnClickListener(this);
            solution = (TextView)FindViewById(Resource.Id.equalsTextView);
            solution.SetOnClickListener(this);
            userInput = (EditText)FindViewById(Resource.Id.userInputEditText);
            userInput.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            //Taking In values from user in the Text view
            if ((v.FindViewById(v.Id) as Button) == number1)
                userInputMethod(number1);

            if ((v.FindViewById(v.Id) as Button) == number2)
                userInputMethod(number2);

            if ((v.FindViewById(v.Id) as Button) == number3)
                userInputMethod(number3);

            if ((v.FindViewById(v.Id) as Button) == number4)
                userInputMethod(number4);

            if ((v.FindViewById(v.Id) as Button) == number5)
                userInputMethod(number5);

            if ((v.FindViewById(v.Id) as Button) == number6)
                userInputMethod(number6);

            if ((v.FindViewById(v.Id) as Button) == number7)
                userInputMethod(number7);

            if ((v.FindViewById(v.Id) as Button) == number8)
                userInputMethod(number8);

            if ((v.FindViewById(v.Id) as Button) == number0)
                userInputMethod(number0);

            if ((v.FindViewById(v.Id) as Button) == number9)
                userInputMethod(number9);

            if ((v.FindViewById(v.Id) as Button) == number00)
                userInputMethod(number00);

            if ((v.FindViewById(v.Id) as Button) == decima)
            {  //to have only one decimal point at a time we use count
                if (count == 0)
                {
                    userInputMethod(decima);
                    count++;
                }
                return;
            }
            //below code lines are used to take operator input
            if ((v.FindViewById(v.Id) as Button) == percent)
            {
                if (userInput.Text == "")
                    input = double.Parse(solution.Text);
                else if (userInput.Text != "")
                    input = double.Parse(userInput.Text);
                else
                    return;
                if (expression.Text == "/")
                    result = result * 100;
                else
                    result = input / 100;
                solution.Text = result.ToString();
            }
            if ((v.FindViewById(v.Id) as Button) == div)
            {
                expression.Text = div.Text;
                performDivision();
            }
            if ((v.FindViewById(v.Id) as Button) == clear)
            {
                if (userInput.Text == "")
                    userInput.Text = "";
                else
                    userInput.Text = userInput.Text.Substring(0, userInput.Text.Length - 1);
            }
            if ((v.FindViewById(v.Id) as Button) == add)
            {
                expression.Text = add.Text;
                performAddition();
            }
            if ((v.FindViewById(v.Id) as Button) == mul)
            {
                expression.Text = mul.Text;
                performMultiplication();
            }
            if ((v.FindViewById(v.Id) as Button) == sub)
            {
                expression.Text = sub.Text;
                performSubtraction();
            }
            if ((v.FindViewById(v.Id) as Button) == div)
            {
                expression.Text = div.Text;
                performDivision();
            }
            if ((v.FindViewById(v.Id) as Button) == equals)
            {
                if (expression.Text == "+")
                    performAddition();
                if (expression.Text == "/")
                {
                    multi = double.Parse(userInput.Text);
                    multi = input / multi;
                    userInput.Text = "";
                    solution.Text = multi.ToString();
                }
                if (expression.Text == "-")
                {
                    result = double.Parse(userInput.Text);
                    result = input - result;
                    userInput.Text = "";
                }
                if (expression.Text == "*")
                {
                    performMultiplication();
                    solution.Text = multi.ToString();
                    return;
                }
                solution.Text = result.ToString();
            }
            if ((v.FindViewById(v.Id) as Button) == allClear)
                _clearAllOfIt();
        }
        public void performDivision()
        {
            if(userInput.Text=="")
            {
                input = double.Parse(solution.Text);

            }
            else
            {
                input = double.Parse(userInput.Text);
            }

        }
        public void performMultiplication()
        {
            if (userInput.Text == "")
            {
                input = double.Parse(solution.Text);
                multi = 1;
            }
            else
                input = double.Parse(userInput.Text);
            multi = input * multi;
            userInput.Text = "";
        }
        public void performSubtraction()
        {
            if(userInput.Text=="")
            input = double.Parse(solution.Text);
            else
            input = double.Parse(userInput.Text);
            userInput.Text = "";

        }
        public void performAddition()
        {
            if (userInput.Text == "")
            {
                input = double.Parse(solution.Text);
                result = 0;
            }
            else
                input = double.Parse(userInput.Text);
            result = input + result;
            userInput.Text = "";
        }
        public void userInputMethod(Button tempButton)
        {
            userInput.Text = userInput.Text + tempButton.Text;
        }
        public void _clearAllOfIt()
        {
            counter2 = 1;
            counter = 0;
            multi = 1;
            result = 0;
            input = 0;
            solution.Text = "";
            expression.Text = "";
            userInput.Text = "";
        }
    }
}

//if (userInput.Text == "")
//    input = double.Parse(solution.Text);
//else
//    input = double.Parse(userInput.Text);
//if (counter == 0)
//{
//    result = input - result;
//    counter++;
//}
//else
//{
//    result = result - input;
//}
//userInput.Text = "";

