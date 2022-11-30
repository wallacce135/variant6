using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Variant_6.Classes;

namespace Variant_6
{
    internal class Program
    {
        public static Element[] elements;
        public static Register register;
        public static Register reg1;
        public static Register reg2;
        static void Main(string[] args)
        {
            elements = new Element[3];
            elements[0] = new Combination(6);
            elements[1] = new Memmory();
            elements[2] = new Memmory();

            
            register = new Register();
            reg1 = new Register();
            reg2 = new Register();

            char Key;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Использование класса: \"Комбинационный элемент\" \n");
                Console.WriteLine("2. Использование класса: \"Память\" \n");
                Console.WriteLine("3. Использование класса: \"Регистр\" \n");
                Console.WriteLine("4. Выход из приложения");

                Key = Console.ReadKey(true).KeyChar;

                switch (Key)
                {
                    case '1':
                        {
                            CombinationUse();
                            break;
                        }
                    case '2':
                        {
                            MemmoryUse();
                            break;
                        }
                    case '3':
                        {
                            RegisterUse();
                            break;
                        }
                }
            }
            while (Key != '4');
        }

        public static void CombinationUse()
        {
            Combination el = (Combination)elements[0];
            char Key;

            do
            {
                Console.WriteLine("\t\t\tКласс: \"Комбинационный элемент\"\n");
                Console.WriteLine("1. Задать значения на входах.\n");
                Console.WriteLine("2. Получить значение со входа.\n");
                Console.WriteLine("3. Получить значение с выхода.\n");
                Console.WriteLine("4. Вернуться в меню.");

                Key = Console.ReadKey().KeyChar;

                switch (Key)
                {
                    case '1':
                        {
                            Console.Clear();
                            Console.WriteLine("Введите значения на входах в формате XXXXXX\n");
                            Console.WriteLine("0 - false ; 1 - true\n");

                            string buffer;
                            buffer = Console.ReadLine();
                            bool[] temp = new bool[el.m_enterPointsP];
                            try
                            {
                                for (int i = 0; i < el.m_enterPointsP; i++)
                                {
                                    if (buffer[i] == '0') temp[i] = false; else temp[i] = true;
                                    if (el.SetEnterPoints(temp)) Console.WriteLine("Значения успешно заданы!"); else Console.WriteLine("Ошибка при установке значений!");
                                    Console.ReadKey();
                                }
     
                            }
                            catch (Exception e) 
                            {
                                Console.WriteLine("Ошибка: " + e.Message);
                            }
                            Console.WriteLine("Нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                        }
                    case '2':
                        {
                            Console.Clear();
                            bool error, value;
                            do
                            {
                                Console.WriteLine("Введите номер входа: ");
                                string input = Console.ReadLine();
                                if (input.Length > 1) Console.WriteLine("Неверно заданы значения");
                                else
                                {
                                    try
                                    {
                                        int a = Convert.ToInt32(input);
                                        value = el.getValues(a, out error);
                                        Console.WriteLine("Значение на выходе: " + a + ": " + value);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Ошибка: " + ex.Message);
                                    }
                                }
                            } while (Console.ReadKey().Key != ConsoleKey.Escape);
                            break;
                        }
                    case '3':
                        {
                            Console.Clear();
                            Console.WriteLine("Значение на выходе элемента " + el.m_nameP + ": " + el.Result().ToString());
                            Console.WriteLine("Нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                        }
                }

            } while (Key != '4');
        }

        public static void MemmoryUse()
        {
            char Key;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\tКласс: \"Память\"\n");
                Console.WriteLine("1.Задать значения на входах Т - триггера.\n");
                Console.WriteLine("2.Получить значение со входа Т - триггера.\n");
                Console.WriteLine("3. Получить значение с выхода Т - триггера.\n");
                Console.WriteLine("4. Проверка метода Equals.\n");
                Console.WriteLine("5. Вернуться в меню.");

                Key = Console.ReadKey().KeyChar;
                Memmory mem1 = (Memmory)elements[1];
                Memmory mem2 = (Memmory)elements[2];

                switch (Key)
                {
                    case '1':
                        {
                            Console.Clear();
                            Console.WriteLine("Введите значение на входах в формате XX");
                            Console.WriteLine("0 - false ; 1 - true\n");
                            string buffer;
                            bool[] temp2 = new bool[mem1.m_enterPointsP];
                            try
                            {
                                buffer = Console.ReadLine();
                                for (int i = 0; i < mem1.m_enterPointsP; i++)
                                {
                                    if (buffer[i] == '0')
                                    {
                                        temp2[i] = false;
                                    }
                                    else
                                    {
                                        temp2[i] = true;
                                    }
                                    if (mem1.SetValues(temp2))
                                    {
                                        Console.WriteLine("Значения успешно заданы!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ошибка, проверьте правильность заполнения!");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ошибка: " + ex.Message);
                            }
                            Console.WriteLine("Нажмите для продолжения...");
                            break;
                        }
                    case '2':
                        {
                            Console.Clear();
                            bool error, value;
                            do
                            {
                                Console.WriteLine("Введите номер входа (0 - вход установки, 1 - вход сброса) ");
                                string buffer = Console.ReadLine();
                                try
                                {
                                    int input = Convert.ToInt32(buffer);
                                    value = mem1.GetValues(input, out error);
                                    if (!error) Console.WriteLine("Значения на входе: " + value.ToString());
                                    else Console.WriteLine("Входа с таким номером не существует");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Ошибка: " + ex.Message);
                                }
                                Console.WriteLine("нажмите Escape для выхода в меню");
                            } while (Console.ReadKey().Key != ConsoleKey.Escape);
                            break;
                        }
                    case '3':
                        {
                            Console.Clear();
                            mem1.GetResult();
                            Console.WriteLine("Значение на прямом выходе :" + mem1.GetOutput().ToString());
                            Console.WriteLine("Значение на инверсном выходе :" + mem1.GetNOutput().ToString());
                            Console.ReadKey();
                            break;
                        }
                    case '4':
                        {
                            Console.Clear();
                            Console.WriteLine("Введите значение на входе первого триггера в формате XX");
                            Console.WriteLine("0 - false, 1 - true");
                            string buffer;
                            bool[] temp2 = new bool[mem1.m_enterPointsP];
                            try
                            {
                                buffer = Console.ReadLine();
                                for (int i = 0; i < mem1.m_enterPointsP; i++)
                                {
                                    if (buffer[i] == '0') temp2[i] = false;
                                    else if (buffer[i] == '1') temp2[i] = true;

                                    if (mem1.SetValues(temp2)) Console.Write("Значения успешно заданы");
                                    else
                                    {
                                        Console.WriteLine("Ошибка, значения не заданы");
                                        Console.WriteLine("Нажмите для продолжения...");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ошибка: " + ex.Message);
                                Console.WriteLine("Нажмите для продолжения");
                                Console.ReadKey();
                            }
                            mem1.GetResult();




                            Console.WriteLine("Введите значение на входе второго триггера в формате XX");
                            Console.WriteLine("0 - false, 1 - true");
                            try
                            {
                                buffer = Console.ReadLine();
                                for (int i = 0; i < mem2.m_enterPointsP; i++)
                                {
                                    if (buffer[i] == '0') temp2[i] = false;
                                    else if (buffer[i] == '1') temp2[i] = true;

                                    if (mem2.SetValues(temp2)) Console.WriteLine("Значения успешно заданы");
                                    else
                                    {
                                        Console.WriteLine("Ошибка, значения не заданы");
                                        Console.WriteLine("Нажмите для продолжения...");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ошибка: " + ex.Message);
                                Console.WriteLine("Нажмите для продолжения");
                                Console.ReadKey();
                            }
                            mem2.GetResult();

                            if (mem1.Equals(mem2)) Console.WriteLine("Триггеры эквивалентны");
                            else
                            {
                                Console.WriteLine("Триггеры не эквивалентны");
                                Console.WriteLine("Нажмите для продолжения");
                                Console.ReadKey();
                                break;
                            }
                            break;
                        }
                }

            } while (Key != '5');
        }


        public static void RegisterUse()
        {
            char Key;
            do

            {

                Console.Clear();

                Console.WriteLine("\tКласс \"Регистр\"");

                Console.WriteLine("\n1.Задать значения на входах регистра.");

                Console.WriteLine("\n2.Получить значение с заданного выхода регистра.");

                Console.WriteLine("\n3.Получить значение на выходе регистра.");

                Console.WriteLine("\n4. Проверка метода Equals.");

                Console.WriteLine("\n5. Вернуться в меню.");

                Key = Console.ReadKey().KeyChar;



                switch (Key)

                {

                    case '1':

                        {

                            Console.Clear();

                            Console.WriteLine("Установление значений на входе 10 Т-триггеров.");

                            Console.WriteLine("Введите 20 цифр (0 - false, 1 - true),\n каждая из которых будет задавать значение для одного из триггеров");

                            String buf;

                            bool[] tmp1 = new bool[20];

                            try

                            {

                                buf = Console.ReadLine();

                                for (int i = 0; i < 20; i++)

                                    if (buf[i] == '0')

                                        tmp1[i] = false;

                                    else

                                        tmp1[i] = true;

                                if (register.SetValues(tmp1))

                                {

                                    Console.WriteLine("Значения успешно установленны!");

                                    for (int i = 0; i < 20; i++)

                                        Console.WriteLine(tmp1[i]);

                                }

                                else

                                {

                                    Console.WriteLine("Ошибка! Значения не установленны!");

                                    for (int i = 0; i < 20; i++)

                                        Console.WriteLine(tmp1[i]);

                                }

                            }

                            catch (Exception e)

                            {

                                Console.WriteLine("Ошибка! " + e.Message);

                            }

                            Console.WriteLine("Для продолжения нажмите любую клавишу...");

                            Console.ReadKey();

                            break;

                        }

                    case '2':

                        {

                            Console.Clear();

                            bool Error, Value;
                            do
                            {
                                Console.WriteLine("Введите номер выхода регистра(от 0 до 9):");
                                String buf = Console.ReadLine();
                                if (buf.Length > 1)
                                    Console.WriteLine("Триггер с таким номером не существоет");
                                else
                                    try
                                    {
                                        int a = Convert.ToInt32(buf);
                                        Value = register.GetOutput(a, out Error);
                                        if (!Error)
                                            Console.WriteLine("Значение у выбраного триггера на выходе: " + Value.ToString());
                                        else
                                            Console.WriteLine("Триггер С таким номером не существует!");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Ошибка! " + e.Message);
                                    }

                                Console.WriteLine("Для выхода нажмите ESC, для повтора нажмите любую клавишу...");
                            } while (Console.ReadKey().Key != ConsoleKey.Escape);
                            break;
                        }

                    case '3':
                        {
                            Console.Clear();
                            Console.WriteLine("Значение регистра: " + register.Result());
                            Console.WriteLine("Для продолжения нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                        }

                    case '4':
                        {
                            Console.Clear();
                            Console.WriteLine("Установление значения на входе 10 Т-триггеров.");
                            Console.WriteLine("Введите 20 цифр (логические 1 или 0) каждая из которых будет означать значение на входе. Лишние символы не учитываются");
                            String tmp;
                            bool[] tmp2 = new bool[20];

                            try
                            {
                                bool f = false;
                                tmp = Console.ReadLine();
                                for (int i = 0; i < 20; i++)
                                    if (tmp[i] == '0')
                                        tmp2[i] = false;
                                    else if (tmp[i] == '1')
                                        tmp2[i] = true;
                                    else { f = true; break; }
                                if ((reg1.SetValues(tmp2) && (f == false)))
                                    Console.WriteLine("Значения на входе регистра установлены.");
                                else

                                {
                                    Console.WriteLine("Ошибка при установлении значений на входе.");
                                    Console.WriteLine("Для выхода нажмите любую клавишу...");
                                    Console.ReadKey(true);
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ошибка: " + e.Message);
                                Console.WriteLine("Для выхода нажмите любую клавишу...");
                                Console.ReadKey(true);
                                break;

                            }
                            reg1.Result();
                            Console.WriteLine("Задайте значения для второго регистра.\n");

                            // второй регистр
                            try

                            {
                                bool f = false;
                                tmp = Console.ReadLine();
                                for (int i = 0; i < 20; i++)
                                    if (tmp[i] == '0')
                                        tmp2[i] = false;
                                    else if (tmp[i] == '1')
                                        tmp2[i] = true;
                                    else { f = true; break; }
                                if ((reg2.SetValues(tmp2) && (f == false)))
                                    Console.WriteLine("Значения на входе регистра установлены.");
                                else
                                {
                                    Console.WriteLine("Ошибка при установлении значений на входе.");
                                    Console.WriteLine("Для выхода нажмите любую клавишу...");
                                    Console.ReadKey(true);
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ошибка: " + e.Message);
                                Console.WriteLine("Для выхода нажмите любую клавишу...");
                                Console.ReadKey(true);
                                break;
                            }
                            reg2.Result();
                            if (reg1.Equals(reg2)) Console.WriteLine("\nРегистры равны");
                            else
                                Console.WriteLine("\nРегистры разные");
                            Console.WriteLine("\nДля выхода нажмите любую клавишу...");
                            Console.ReadKey(true);
                            break;

                        }

                }

            } while (Key != '4');

        }


    }
}
