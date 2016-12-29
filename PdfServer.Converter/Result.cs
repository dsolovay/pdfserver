using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfServer.Converter {
    public class Result<S, E> {
        public bool success { get; set; }
        public S data { get; set; }
        public E error { get; set; }

        public Result<S, E> Bind<T>(T data, Func<T, Result<S, E>> action) {
            if (success) {
                return action(data);
            } else {
                return this;
            }
        }
    }

    public class Option<T> {
        public bool success { get; set; }
        public T data { get; set; }

        public static Option<T> Some(T data) => 
            new Option<T> {
                success = true,
                data = data
            };

        public static Option<T> None() =>
            new Option<T> {
                success = false,
                data = default(T)
            };

        public Option<T> Bind<R>(R data, Func<R, Option<T>> action) {
            if (success) {
                return action(data);
            } else {
                return this;
            }
        }
    }
}