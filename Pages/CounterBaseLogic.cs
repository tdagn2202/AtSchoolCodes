using Microsoft.AspNetCore.Components;


namespace BlazorApp1.Pages;


public class CounterBase : ComponentBase {
    public string num1;
    public string num2;
    public string result;
    public int currentCount = 0;

    public void IncrementCount()
    {
        currentCount++;
    }

    public void Add(){
        result = (Convert.ToDouble(num1) + Convert.ToDouble(num2)).ToString();
    }
    public void Subtract(){
        result = (Convert.ToDouble(num1) - Convert.ToDouble(num2)).ToString();
    }
    public void Multiple(){
        result = (Convert.ToDouble(num1) * Convert.ToDouble(num2)).ToString();
    }
    public void Divide(){
        if(Convert.ToDouble(num2) != 0){
            result = (Convert.ToDouble(num1) / Convert.ToDouble(num2)).ToString();
        } else {
            result = "Cannot divide by zero!";
        }
    }
}


