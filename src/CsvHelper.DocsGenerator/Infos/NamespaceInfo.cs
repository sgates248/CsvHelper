﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CsvHelper.DocsGenerator.Infos
{
	[DebuggerDisplay("Name = {Name}")]
	public class NamespaceInfo : Info
    {
		public AssemblyInfo Assembly { get; private set; }

		public List<TypeInfo> Types { get; private set; } = new List<TypeInfo>();

		public List<TypeInfo> Classes { get; private set; } = new List<TypeInfo>();

		public List<TypeInfo> Interfaces { get; private set; } = new List<TypeInfo>();

		public List<TypeInfo> Enums { get; private set; } = new List<TypeInfo>();

        public NamespaceInfo(AssemblyInfo assemblyInfo, string @namespace, List<Type> types, XElement xmlDocs)
		{
			Assembly = assemblyInfo;

			Name = @namespace;

			foreach (var type in types)
			{
				var typeInfo = new TypeInfo(this, type, xmlDocs);
				Types.Add(typeInfo);

				if (type.IsClass)
				{
					Classes.Add(typeInfo);
				}
				else if (type.IsInterface)
				{
					Interfaces.Add(typeInfo);
				}
				else if (type.IsEnum)
				{
					Enums.Add(typeInfo);
				}
			}
		}
    }
}