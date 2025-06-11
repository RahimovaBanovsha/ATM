//Console.WriteLine("Hello, World!");
// Exception
//This code will crash before it even reaches the if check: 
//int x = 1234523456789678;
//if(x>int.MaxValue)
//    Console.WriteLine("Out of Range!");

//throw 5; // value type kimi exception atmaq olmaz, compile-time error verecek
//Sebeb: throw ifadəsi yalnız Exception tipindən törəmiş obyektləri atmaq üçün istifadə olunur!
//5 isə int tipindədir, yəni value typedir və System.Exception-dan törəməyib.
//throw new Exception("Message");
//Bu isə tamamilə düzgündür,çünki Exception sinfi System.Exception-dan törəyir(əslində birbaşa budur).
// Exception icindekilere bax *****************************************************************

//try
//{
//    //int x = 100;
//    //Console.WriteLine(x / 0);
//    string? data = null;
//    ArgumentNullException.ThrowIfNullOrWhiteSpace(data);
//}
//catch(DivideByZeroException zex)
//{
//    Console.WriteLine(zex.Message);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
//////////////////////////////////////////////////////////////////////////////////////////////
//try
//{
//	throw new ArgumentNullException();
//}
////catch(ArgumentNullException ex)
////{
////    Console.WriteLine($"Argument: {ex.Message}");
////}
//catch(SystemException ex)
//{
//    Console.WriteLine($"System: {ex.Message}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Exception: {ex.Message}");
//}
///////////////////////////////////////////////////////////////////////////////////////////////
using Lesson11_12.Abstraction_Task.Step1;
using Lesson11_12.Exceptions;
using Lesson11_12.Models;
using System.Net.Http;
//48ci deqiqeye bax! CustomExceptionla bagli qeyd!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//try
//{
//    Dangerous.DangerousMethod();
//}
//catch (DivideByZeroException zex)
//{
//    Console.WriteLine($"Divide: {zex.Message}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Exception: {ex.Message}");
//}
//catch
//{
//    Console.WriteLine($"Error Occured!");
//}
//////////////////////////////////////////////////////////////////////////////////////////////
///Global Scope:
//int[] numbers = { 1, 2, 3, 4, 5 };
//int index = -1;
//try
//{
//	Console.WriteLine(numbers[index]);
//}
//catch(IndexOutOfRangeException iex) when (index > numbers.Length)
//{
//    Console.WriteLine($"Index Out of Range: {index} > {numbers.Length}");
//}
//catch(IndexOutOfRangeException iex) when(index<0)
//{
//    Console.WriteLine($"Out of Range: {index} < 0");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
//////////////////////////////////////////////////////////////////////////////////////////////////
//try
//{
//    try
//    {
//        int number = 100;
//        Console.WriteLine(number / 0);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Inner Exception");
//        Console.WriteLine($"Inner Exception: {ex.Message}");
//        throw new Exception("Dont divide by zero!");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine("Outer Exception");
//    Console.WriteLine($"Outer Exception: {ex.Message}");
//    Console.WriteLine(ex.Source);//namespace-i cixarir
//    Console.WriteLine(ex.StackTrace);//daha deqiq gosterir, line da gosterir
//    Console.WriteLine(ex.HelpLink);
//}
////////////////////////////////////////////////////////////////////////////////////////////////
//try
//{
//	throw new CustomException("User not found", 404);
//}
//catch (CustomException zex)
//{
//    Console.WriteLine(zex.Message);
//    Console.WriteLine(zex.StatusCode);
//}
// 01:19!! Bir daha bax!************************************************************************

////////////////////////////////////////////////////////////////////////////////////////////////

// 01:37:12 Bax Mutleq!*************************************************************************

//var httpClient=new HttpClient();
//try
//{
//    string result=await httpClient.GetStringAsync("https://google.com");
//    Console.WriteLine(result);
//}
//finally
//{
//    httpClient.Dispose();
//}
////////////////////////////////////////////////////////////////////////////////////////////////

// Bu sekilde islenmir eslinde, amma sen esas megzi basa dussen kifayet edir:
/*lock (new object()) ;
try
{
    Monitor.Enter(new object() );
}
finally
{
    Monitor.Exit(new object() );
}*/
///////////////////////////////////////////////////////////////////////////////////////////////

//Syntax Sugar:
//using (var httpClient = new HttpClient()) ;

// Abstaction:

//Step1:
//VictorianFactory factory = new VictorianFactory();
//factory.CreateVictorianSofa();
//factory.CreateVictorianChair();
//factory.CreateVictorianCoffeeChair();

//Step2:
//Lesson11_12.Abstraction_Task.Step2.VictorianFactory factory= new Lesson11_12.Abstraction_Task.Step2.VictorianFactory();
//factory.CreateVictorianSofa();
//factory.CreateModernSofa();
//factory.CreateArtDecoSofa();

//Step3:
//Lesson11_12.Abstraction_Task.Step3.VictorianFactory factory = new Lesson11_12.Abstraction_Task.Step3.VictorianFactory("Modern");
//factory.CreateChair();
//factory.CreateSofa();
//factory.CreateCoffeeChair();

//Step4(Last Step):
//Lesson11_12.Abstraction_Task.Step4.Factory factory = new Lesson11_12.Abstraction_Task.Step4.ModernFactory();
//factory.CreateChair();
//factory.CreateSofa();
//factory.CreateCoffeeChair();
