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
    
    public partial class Пользователи
    {
        public int ID { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Логин { get; set; }
        public int Пароль { get; set; }
        public int IDроли { get; set; }
    
        public virtual Роли Роли { get; set; }
    }
}
