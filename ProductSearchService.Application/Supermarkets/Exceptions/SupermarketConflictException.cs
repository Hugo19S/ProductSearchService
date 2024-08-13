using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductSearchService.Application.Supermarkets.Exceptions;

public class SupermarketConflictException(string name) : Exception($"O supermarket com o nome {name} já existe.");