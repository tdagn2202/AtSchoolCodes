using Microsoft.AspNetCore.Components;


namespace revision01.Components.Pages
{
    public class CalculatorLogic : ComponentBase
    {
        public string num1;
        public string num2;
        public string result;



        public void Add()
        {
            result = (Convert.ToDouble(num1) + Convert.ToDouble(num2)).ToString();
        }

        public void Sub()
        {
            result = (Convert.ToDouble(num1) - Convert.ToDouble(num2)).ToString();
        }

        public void Div()
        {
            if (Convert.ToDouble(num2) != 0)
            {
                result = (Convert.ToDouble(num1) / Convert.ToDouble(num2)).ToString();
            }
            else
            {
                result = "Cannot divide by zero!";
            }
        }

        public void Mul()
        {
            result = (Convert.ToDouble(num1) * Convert.ToDouble(num2)).ToString();
        }

        public void clear()
        {
            num1 = "";
            num2 = "";
            result = "";
        }
    }
}
