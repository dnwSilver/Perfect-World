using System;
using System.Diagnostics;

using Prosolve.MicroService.Watcher.DataAccess;

using Sharpdev.SDK.Mapper;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Класс для сопоставление полей объекта <see cref="IProcessEntity"/>.
    /// </summary>
    public sealed class ProcessPropertyMapper : IPropertyMapper
    {
        /// <summary>
        /// Метод для определения наименования конечного свойства.
        /// </summary>
        /// <param name="sourcePropertyName">Начальное наименование свойства.</param>
        /// <returns>Конечное наименование свойства.</returns>
        public string GetPropertyModelName(string sourcePropertyName)
        {
            string destinationPropertyName;

            switch(sourcePropertyName)
            {
                case nameof(IProcessEntity.Id.Private):
                    destinationPropertyName = nameof(ProcessDataModel.PrivateId);

                    break;
                
                case nameof(IProcessEntity.Id.Public):
                    destinationPropertyName = nameof(ProcessDataModel.PublicId);

                    break;
                
                case nameof(IProcessEntity.Name):
                    destinationPropertyName = nameof(ProcessDataModel.Name);

                    break;

                default:
                    Debugger.Break();
                    throw new Exception("Маппинг для классов настроен некорректно.");
            }

            return destinationPropertyName;
        }
    }
}
