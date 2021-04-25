using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeTask.Data.Interfaces
{   /// <summary>
    /// 2.2.2 Интерфейс для отображения Названия книги и её Автора
    /// </summary>
    public interface IBook
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string author { get; set; }
    }
}
