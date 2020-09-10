using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Challenger.Core.IL
{
    public class HelloWorld : IHelloWorld
    {
        public void PrintHelloWorld()
        {
            const string AssemblyName = "HelloWorldAssembly";
            const string ModuleName = "HelloWorldModule";
            const string TypeName = "HelloWorldPrinter";
            const string MethodName = "Print";

            var domain = Thread.GetDomain();
            var assemblyName = new AssemblyName() { Name = AssemblyName };

            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(ModuleName);
            var typeBuilder = moduleBuilder.DefineType(TypeName);
            var methodBuilder = typeBuilder.DefineMethod(MethodName, MethodAttributes.Public);

            var ilGenertor = methodBuilder.GetILGenerator();

            var str = "Hello World";
            var writeLineMethod = typeof(Console).GetMethod(nameof(Console.WriteLine), new[] { typeof(string) });

            ilGenertor.Emit(OpCodes.Ldstr, str);
            ilGenertor.EmitCall(OpCodes.Call, writeLineMethod, null);
            ilGenertor.Emit(OpCodes.Ret);

            // class HelloWorldPrinter { public void Print() { Console.WriteLine("Hello World"); } }

            var type = typeBuilder.CreateTypeInfo();
            var inst = Activator.CreateInstance(type);
            _ = type.InvokeMember(MethodName, BindingFlags.InvokeMethod, null, inst, new object[0]);
        }
    }
}
