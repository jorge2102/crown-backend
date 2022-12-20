using CrownBackend.Domain.DTOs;
using CrownBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownBackend.Domain.Interfaces.Services
{
    public interface IArrayBinaryService
    {
        ConvertArrayBinaryResponse ConvertToBinaryOrdered(ConvertArrayBinaryRequest arrayBinay);
    }
}
