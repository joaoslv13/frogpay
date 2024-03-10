using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.Shared
{
    public static class EntityUpdater
    {
        public static void UpdateEntityFromAnother<T>(T entity, T dto)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var dtoValue = property.GetValue(dto);
                var entityValue = property.GetValue(entity);

                if (dtoValue != null && !Equals(dtoValue, entityValue))
                {
                    property.SetValue(entity, dtoValue);
                }
            }
        }
    }
}
