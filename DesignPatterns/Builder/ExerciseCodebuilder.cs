using System;
using System.Collections.Generic;
using System.Text;

namespace Coding.Exercise
{
    class CodeClass
    {
        string _className;
        List<ClassMemberField> _memberVariables = new List<ClassMemberField>();

        public CodeClass(string className)
        {
            _className = className;
        }

        public void AddField(ClassMemberField newField)
        {
            _memberVariables.Add(newField);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {_className}");
            sb.AppendLine("{");
            foreach(var member in _memberVariables)
            {
                sb.AppendLine(member.ToString());
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    class ClassMemberField
    {
        string FieldName;
        string FieldType;
        string Visibility;
        int _indentationSpaceCount = 2;

        public ClassMemberField(string fieldName, string fieldType)
        {
            FieldName = fieldName;
            FieldType = fieldType;
            Visibility = "public";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(new string(' ', _indentationSpaceCount));
            sb.Append($"{Visibility} {FieldType} {FieldName};");
            return sb.ToString();
        }
    }

    public class CodeBuilder
    {
        CodeClass _codeClass;

        public CodeBuilder(string className)
        {
            _codeClass = new CodeClass(className);
        }

        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            ClassMemberField classMemberField = new ClassMemberField(fieldName, fieldType);
            _codeClass.AddField(classMemberField);
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_codeClass.ToString());
            return sb.ToString();
        }
    }

    class ExerciseCodebuilder
    {
        public static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
