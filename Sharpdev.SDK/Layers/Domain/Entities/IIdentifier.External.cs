namespace Sharpdev.SDK.Layers.Domain.Entities
{
    /// <summary>
    ///     Идентификатор бизнес сущности. Состоит из трёх частей:  public,  private,  external.
    /// </summary>
    /// <typeparam name="TOwner">Владелец идентификатора.</typeparam>
    /// <typeparam name="TExternalType">Тип внешнего идентификатора.</typeparam>
    /// <remarks>
    ///     <see cref="External" />
    ///     Идентификатор  пришедший в нашу систему извне.  Понятия не имеем какого он типа и что в
    ///     себе содержит.  Фантазия у разработчиков  может  быть  абсолютно  разная. Идентификатор
    ///     может быть в виде:
    ///     - числа (524773)
    ///     - строки (CU-332772)
    ///     - набора байтов (0xBB489DF2A2905D504CF003ADDFFAC621)
    ///     - 128-битный идентификатор (6F9619FF-8B86-D011-B42D-00CF4FC964FF)
    /// </remarks>
    public interface IIdentifier<TOwner, out TExternalType> : IIdentifier<TOwner>
        where TOwner : IEntity<TOwner>
        where TExternalType : struct
    {
        /// <summary>
        ///     Идентификатор внешней системы. Генерируется не в сервисе.
        /// </summary>
        /// <returns>Значение внешнего идентификатор.</returns>
        TExternalType External { get; }
    }
}
