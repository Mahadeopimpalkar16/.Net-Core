using System.Reflection;

namespace ReflectionAPI
{
    internal class Program
    {
        static void Main1()
        {
            Assembly asm = Assembly.LoadFile(@"D:\Cdac Data\Cdac_Hyd\ASP.Net\Class_Codes\Day1\bin\Debug\net7.0\ClassBasics.dll");
            Console.WriteLine(asm.GetName().Name);

            Type[] arrTypes = asm.GetTypes();

            foreach (Type t in arrTypes)
            {
                Console.WriteLine("   " + t.Name);
                MethodInfo[] arrMethods = t.GetMethods();
                foreach (MethodInfo m in arrMethods)
                {
                    Console.WriteLine("      " + m.Name);
                    ParameterInfo[] arrParams = m.GetParameters();
                    foreach (ParameterInfo p in arrParams)
                    {
                        Console.WriteLine("         " + p.Name);

                    }
                }

            }


            Console.ReadLine();
        }

    }
}
