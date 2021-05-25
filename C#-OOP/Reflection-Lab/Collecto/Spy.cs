using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | 
                BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }


        public string AnalyzeAccessModifiers(string className)
        {

            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in methodInfos.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"All Private Methods of Class: {className}");
            //sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            MethodInfo[] methodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (MethodInfo method in methodsInfo.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (MethodInfo method in methodsInfo.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
