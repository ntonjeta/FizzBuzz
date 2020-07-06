namespace FizzBuzz

module FizzBuzz  =
    let fizzbuzz (x:int) = 
        match x with 
        | 3 -> "Fizz"
        | 5 -> "Buzz"
        | _ -> string x
