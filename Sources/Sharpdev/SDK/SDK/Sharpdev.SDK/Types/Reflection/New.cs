using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Sharpdev.SDK.Types.Reflection
{
    /// <summary>
    ///     Набор вспомогательных методов для создания экземпляров заданного типа
    /// </summary>
    public static class New
    {
        /// <summary>
        ///     Создаем экземпляр заданного типа.
        /// </summary>
        /// <typeparam name="T">Тип экземпляра.</typeparam>
        /// <returns>Экземпляр заданного типа <typeparamref name="T" />.</returns>
        public static T Instance<T>()
        {
            return (T)Instance(typeof(T));
        }

        /// <summary>
        ///     Создаем экземпляр заданного типа.
        /// </summary>
        /// <typeparam name="T">Тип экземпляра.</typeparam>
        /// <typeparam name="TArg">Тип аргумента.</typeparam>
        /// <param name="argument">Аргумент конструктора.</param>
        /// <returns>Экземпляр заданного типа <typeparamref name="T" />.</returns>
        public static T Instance<T, TArg>(TArg argument)
        {
            return (T)Instance(typeof(T), argument);
        }

        /// <summary>
        ///     Создаем экземпляр заданного типа.
        /// </summary>
        /// <typeparam name="T">Тип экземпляра.</typeparam>
        /// <typeparam name="TArg1">Тип первого аргумента.</typeparam>
        /// <typeparam name="TArg2">Тип второго аргумента.</typeparam>
        /// <param name="argument1">Первый аргумент конструктора.</param>
        /// <param name="argument2">Второй аргумент конструктора.</param>
        /// <returns>Экземпляр заданного типа <typeparamref name="T" />.</returns>
        public static T Instance<T, TArg1, TArg2>(TArg1 argument1, TArg2 argument2)
        {
            return (T)Instance(typeof(T), argument1, argument2);
        }

        /// <summary>
        ///     Создаем экземпляр заданного типа.
        /// </summary>
        /// <typeparam name="T">Тип экземпляра.</typeparam>
        /// <typeparam name="TArg1">Тип первого аргумента.</typeparam>
        /// <typeparam name="TArg2">Тип второго аргумента.</typeparam>
        /// <typeparam name="TArg3">Тип третьего аргумента.</typeparam>
        /// <param name="argument1">Первый аргумент конструктора.</param>
        /// <param name="argument2">Второй аргумент конструктора.</param>
        /// <param name="argument3">Третий аргумент конструктора.</param>
        /// <returns>Экземпляр заданного типа <typeparamref name="T" />.</returns>
        public static T Instance<T, TArg1, TArg2, TArg3>(TArg1 argument1, TArg2 argument2, TArg3 argument3)
        {
            return (T)Instance(typeof(T), argument1, argument2, argument3);
        }

        /// <summary>
        ///     Создаем экземпляр заданного типа.
        /// </summary>
        /// <typeparam name="T">Тип экземпляра.</typeparam>
        /// <typeparam name="TArg1">Тип первого аргумента.</typeparam>
        /// <typeparam name="TArg2">Тип второго аргумента.</typeparam>
        /// <typeparam name="TArg3">Тип третьего аргумента.</typeparam>
        /// <typeparam name="TArg4">Тип четвёртого аргумента.</typeparam>
        /// <param name="argument1">Первый аргумент конструктора.</param>
        /// <param name="argument2">Второй аргумент конструктора.</param>
        /// <param name="argument3">Третий аргумент конструктора.</param>
        /// <param name="argument4">Четвёртый аргумент конструктора.</param>
        /// <returns>Экземпляр заданного типа <typeparamref name="T" />.</returns>
        public static T Instance<T, TArg1, TArg2, TArg3, TArg4>(TArg1 argument1,
                                                                TArg2 argument2,
                                                                TArg3 argument3,
                                                                TArg4 argument4)
        {
            return (T)Instance(typeof(T), argument1, argument2, argument3, argument4);
        }

        /// <summary>
        ///     Создаем экземпляр заданного типа.
        /// </summary>
        /// <param name="type">Тип экземпляра.</param>
        /// <returns>Экземпляр заданного типа <paramref name="type" />.</returns>
        public static object Instance(Type type)
        {
            return Instance<TypeToIgnore>(type, null);
        }

        /// <summary>
        ///     Создаем экземпляр заданного типа.
        /// </summary>
        /// <typeparam name="TArg">Тип аргумента.</typeparam>
        /// <param name="type">Тип экземпляра.</param>
        /// <param name="argument">Аргумент конструктора.</param>
        /// <returns>Экземпляр заданного типа <paramref name="type" />.</returns>
        public static object Instance<TArg>(this Type type, TArg argument)
        {
            return Instance<TArg, TypeToIgnore>(type, argument, null);
        }

        /// <summary>
        ///     Создаем экземпляр заданного типа.
        /// </summary>
        /// <typeparam name="TArg1">Тип первого аргумента.</typeparam>
        /// <typeparam name="TArg2">Тип второго аргумента.</typeparam>
        /// <param name="type">Тип экземпляра.</param>
        /// <param name="argument1">Первый аргумент конструктора.</param>
        /// <param name="argument2">Второй аргумент конструктора.</param>
        /// <returns>Экземпляр заданного типа <paramref name="type" />.</returns>
        public static object Instance<TArg1, TArg2>(this Type type, TArg1 argument1, TArg2 argument2)
        {
            return Instance<TArg1, TArg2, TypeToIgnore>(type, argument1, argument2, null);
        }

        /// <summary>
        ///     Создаем экземпляр заданного типа.
        /// </summary>
        /// <typeparam name="TArg1">Тип первого аргумента.</typeparam>
        /// <typeparam name="TArg2">Тип второго аргумента.</typeparam>
        /// <typeparam name="TArg3">Тип третьего аргумента.</typeparam>
        /// <param name="type">Тип экземпляра.</param>
        /// <param name="argument1">Первый аргумент конструктора.</param>
        /// <param name="argument2">Второй аргумент конструктора.</param>
        /// <param name="argument3">Третий аргумент конструктора.</param>
        /// <returns>Экземпляр заданного типа <paramref name="type" />.</returns>
        public static object Instance<TArg1, TArg2, TArg3>(this Type type,
                                                           TArg1 argument1,
                                                           TArg2 argument2,
                                                           TArg3 argument3)
        {
            return Instance<TArg1, TArg2, TArg3, TypeToIgnore>(type, argument1, argument2, argument3, null);
        }

        /// <summary>
        ///     Создаем экземпляр заданного типа.
        /// </summary>
        /// <typeparam name="TArg1">Тип первого аргумента.</typeparam>
        /// <typeparam name="TArg2">Тип второго аргумента.</typeparam>
        /// <typeparam name="TArg3">Тип третьего аргумента.</typeparam>
        /// <typeparam name="TArg4">Тип четвёртого аргумента.</typeparam>
        /// <param name="type">Тип экземпляра.</param>
        /// <param name="argument1">Первый аргумент конструктора.</param>
        /// <param name="argument2">Второй аргумент конструктора.</param>
        /// <param name="argument3">Третий аргумент конструктора.</param>
        /// <param name="argument4">Четвёртый аргумент конструктора.</param>
        /// <returns>Экземпляр заданного типа <paramref name="type" />.</returns>
        public static object Instance<TArg1, TArg2, TArg3, TArg4>(this Type type,
                                                                  TArg1 argument1,
                                                                  TArg2 argument2,
                                                                  TArg3 argument3,
                                                                  TArg4 argument4)
        {
            return InstanceCreationFactory<TArg1, TArg2, TArg3, TArg4>.CreateInstanceOf(
                type,
                argument1,
                argument2,
                argument3,
                argument4);
        }


        /// <summary>
        ///     Для возможности работы с разным количеством аргументов, используем данный тип как флаг
        ///     для того, чтобы игнорировать аргумент данного типа.
        /// </summary>
        private class TypeToIgnore
        {
        }

        private static class InstanceCreationFactory<TArg1, TArg2, TArg3, TArg4>
        {
            private static readonly ConcurrentDictionary<Type, Func<TArg1, TArg2, TArg3, TArg4, object>> Cache =
                new ConcurrentDictionary<Type, Func<TArg1, TArg2, TArg3, TArg4, object>>();

            public static object CreateInstanceOf(Type type, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
            {
                var ctor = Cache.GetOrAdd(type, CreateConstructor);

                return ctor(arg1, arg2, arg3, arg4);
            }

            private static Func<TArg1, TArg2, TArg3, TArg4, object> CreateConstructor(Type type)
            {
                Type[] argumentTypes =
                {
                    typeof(TArg1),
                    typeof(TArg2),
                    typeof(TArg3),
                    typeof(TArg4)
                };

                // Формируем коллекцию аргументов конструктора, фильтруя те аргументы,
                // которые имеют тип TypeToIgnore
                var constructorArgumentTypes = argumentTypes.Where(t => t != typeof(TypeToIgnore)).ToArray();

                ParameterExpression[] lambdaParameterExpressions =
                {
                    Expression.Parameter(typeof(TArg1), "param1"),
                    Expression.Parameter(typeof(TArg2), "param2"),
                    Expression.Parameter(typeof(TArg3), "param3"),
                    Expression.Parameter(typeof(TArg4), "param4")
                };

                var constructorParameterExpressions =
                    lambdaParameterExpressions.Take(constructorArgumentTypes.Length).ToArray();

                return constructorParameterExpressions.Length == 0
                    ? CreateConstructor(type, lambdaParameterExpressions)
                    : CreateConstructor(type,
                                        constructorArgumentTypes,
                                        lambdaParameterExpressions,
                                        constructorParameterExpressions);
            }

            private static Func<TArg1, TArg2, TArg3, TArg4, object> CreateConstructor(Type type,
                                                                                      ParameterExpression[]
                                                                                          lambdaParameterExpressions)
            {
                var expr = type.IsValueType
                    ? Expression.Convert(Expression.Default(type), typeof(object))
                    : (Expression)Expression.New(type);

                return Expression.Lambda<Func<TArg1, TArg2, TArg3, TArg4, object>>(expr, lambdaParameterExpressions)
                                 .Compile();
            }

            private static Func<TArg1, TArg2, TArg3, TArg4, object> CreateConstructor(Type type,
                                                                                      Type[] constructorArgumentTypes,
                                                                                      ParameterExpression[]
                                                                                          lambdaParameterExpressions,
                                                                                      ParameterExpression[]
                                                                                          constructorParameterExpressions)
            {
                // Ищем конструктор, удовлетворяющий данному набору аргументов
                var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public,
                                                      null,
                                                      CallingConventions.HasThis,
                                                      constructorArgumentTypes,
                                                      new ParameterModifier[0]);

                if (constructor == null)
                {
                    var args = constructorArgumentTypes.Select(t => t.Name).ToArray();
                    string method = $"ctor({string.Join(", ", args)})";

                    throw new MissingMethodException(type.Name, method);
                }

                var constructorCallExpression =
                    Expression.New(constructor, constructorParameterExpressions.ToArray<Expression>());
                var body = type.IsValueType
                    ? Expression.Convert(constructorCallExpression, typeof(object))
                    : (Expression)constructorCallExpression;

                var constructorCallingLambda = Expression
                                               .Lambda<Func<TArg1, TArg2, TArg3, TArg4, object>>(
                                                   body,
                                                   lambdaParameterExpressions)
                                               .Compile();

                return constructorCallingLambda;
            }
        }
    }
}
