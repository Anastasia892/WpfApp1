//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Информация_о_косметике
    {
        public int ID_Косметики { get; set; }
        public Nullable<int> Бренд { get; set; }
        public Nullable<int> Страна_изготовления { get; set; }
        public System.DateTime Дата_изготовления { get; set; }
        public string Фото { get; set; }
        public int ID_Тип_косметики { get; set; }
    
        public virtual Бренд Бренд1 { get; set; }
        public virtual Страна Страна { get; set; }
        public virtual Тип_косметики Тип_косметики { get; set; }
    }
}
